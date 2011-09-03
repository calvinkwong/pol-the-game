using System;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Threading;

namespace ScaricaSpoilers
{
  public class SpoilerDownloader
  {
    private const string CARDS_DIRPATH = @".";
    private const string URL_SPOILER = @"http://gatherer.wizards.com/Pages/Card/Details.aspx?multiverseid=";
    ListView mList;

    public void DownloadSpoiler(XmlDocument xSet, XmlDocument xSetLang, ListView list, ProgressBar progressBar)
    {
      mList = list;

      ListViewItem item;

      if(Directory.Exists("cards"))
        Directory.Delete("cards", true);
      Directory.CreateDirectory("cards");
      foreach(XmlNode nodeSet in xSet.DocumentElement.SelectNodes("card_sets/item"))
      {
        string setCode = nodeSet.Attributes["code"].Value;
        string setName = xSetLang.DocumentElement.SelectSingleNode("card_sets_lang/item[@code='" + setCode + "' and @language='ENG']/@name").InnerText;

        //if(setCode != "MBS")
        //  continue;

        string cardsPath = "cards\\" + setCode + ".xml";
        string cardsLangPath = "cards\\" + setCode + ".eng.xml";
        if(File.Exists(cardsPath))
          File.Delete(cardsPath);
        if(File.Exists(cardsLangPath))
          File.Delete(cardsLangPath);
        XmlDocument xCards = new XmlDocument();
        xCards.LoadXml("<cards />");
        XmlDocument xCardsLang = new XmlDocument();
        xCardsLang.LoadXml("<cards />");


        DateTime setDate = XmlConvert.ToDateTime(nodeSet.Attributes["releaseDate"].Value, "yyyy-MM-ddTHH:mm:ss");
        xCards.DocumentElement.Attributes.Append(xCards.CreateAttribute("releaseDate")).Value = setDate.ToString("yyyy-MM-ddTHH:mm:ss");
        xCards.DocumentElement.Attributes.Append(xCards.CreateAttribute("code")).Value = setCode;

        xCardsLang.DocumentElement.Attributes.Append(xCardsLang.CreateAttribute("name")).Value = setName;

        string contentTextPath = Path.Combine(Path.Combine(CARDS_DIRPATH, setCode), "CONTENT.txt");
        string contentXmlPath = Path.Combine(Path.Combine(CARDS_DIRPATH, setCode), "CONTENT.xml");
        string listPath = Path.Combine(Path.Combine(CARDS_DIRPATH, setCode), "list.xml");

        item = new ListViewItem(setCode);
        ListViewItem.ListViewSubItem subItem = item.SubItems.Add("Working...");
        mList.Items.Add(item);
        mList.EnsureVisible(mList.Items.Count - 1);
        Application.DoEvents();

        progressBar.Minimum = 0;
        progressBar.Step = 1;
        progressBar.Value = 0;

        XmlDocument xCardList = new XmlDocument();
        xCardList.Load(listPath);
        XmlDocument xContent = new XmlDocument();
        string allContent;
        if(!File.Exists(contentTextPath))
        {
          // download page content
          subItem.Text = "Downloading...";
          mList.FindForm().Refresh();
          Application.DoEvents();
          
          allContent = string.Empty;

          xContent.LoadXml("<content />");
          progressBar.Maximum = xCardList.SelectNodes("//card").Count;
          foreach(XmlNode cardNode in xCardList.SelectNodes("//card"))
          {
            string id = cardNode.SelectSingleNode("@id").InnerText;
            string content = Download(URL_SPOILER + id);
            allContent += content;
            XmlNode nodeContent = xContent.ImportNode(GetDocument(content).DocumentElement, true);
            xContent.DocumentElement.AppendChild(nodeContent);
            progressBar.PerformStep();
            mList.FindForm().Refresh();
            Application.DoEvents();
          }

          File.WriteAllText(contentTextPath, allContent);
          xContent.Save(contentXmlPath);
          subItem.Text = "OK!";
          mList.FindForm().Refresh();
          Application.DoEvents();
        }

        subItem.Text = "Creating...";
        mList.FindForm().Refresh();
        Application.DoEvents();

        xContent.Load(contentXmlPath);
        progressBar.Value = 0;
        progressBar.Maximum = xContent.DocumentElement.SelectNodes("td").Count;
        XmlNodeList cardListNodes = xCardList.DocumentElement.SelectNodes("card");
        XmlNodeList contentNodes = xContent.DocumentElement.SelectNodes("td");
        for(int i = 0; i < cardListNodes.Count; i++)
        {
          SpoilerReader spoilerReader = new SpoilerReader(cardListNodes[i].SelectSingleNode("@name").InnerText, 
            cardListNodes[i].SelectSingleNode("@color").InnerText);
          spoilerReader.CreateCardNode(contentNodes[i], xCards, xCardsLang, setCode, setDate, i + 1);
          progressBar.PerformStep();
          mList.FindForm().Refresh();
          Application.DoEvents();
        }
        subItem.Text = "OK!";
        mList.FindForm().Refresh();
        Application.DoEvents();

        xCards.Save(cardsPath);
        xCardsLang.Save(cardsLangPath);
      }
    }

    XmlDocument GetDocument(string content)
    {
      XmlDocument xSource = new XmlDocument();
      StringBuilder str = new StringBuilder();
      using(StringReader readStream = new StringReader(content))
      {
        bool writeLine = false;
        string line;
        while((line = readStream.ReadLine()) != null)
        {
          if(!writeLine && line.Trim() == "<td id=\"ctl00_ctl00_ctl00_MainContent_SubContent_SubContent_rightCol\" class=\"rightCol\">")
            writeLine = true;
          if(writeLine)
            //str.AppendLine(line
            //  .Replace("&", "&amp;")
            //  .Replace("Æ", "AE")
            //  .Replace("â", "a")
            //  .Replace("<i>", string.Empty)
            //  .Replace("</i>", string.Empty));
            str.AppendLine(Program.XmlEncode(line)
              .Replace("<</", "&lt;</")
              .Replace("<i>", string.Empty)
              .Replace("</i>", string.Empty));
          if(writeLine && line.Trim() == "</td>")
            break;
        }
      }
      xSource.LoadXml(str.ToString());
      return xSource;
    }

    private string Download(string url)
    {
      bool exit = false;
      string content = null;
      int count = 1;
      while(!exit)
      {
        try
        {
          HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
          request.MaximumAutomaticRedirections = 4;
          request.MaximumResponseHeadersLength = 4;
          request.Credentials = CredentialCache.DefaultCredentials;
          HttpWebResponse response = (HttpWebResponse)request.GetResponse();
          try
          {
            using(Stream receiveStream = response.GetResponseStream())
            using(StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
              content = readStream.ReadToEnd();
          }
          finally
          {
            response.Close();
          }
          exit = true;
        }
        catch
        {
          if(count == 3)
            throw;
          else
            count++;
        }
      }
      return content;
    }
  }
}
