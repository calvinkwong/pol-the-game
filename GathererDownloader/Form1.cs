using System;
using System.Linq;
using System.Data.OleDb;
using System.Web;
using System.IO;
using System.Xml;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ScaricaSpoilers
{
	public partial class Form1 : Form
	{
    private const string URL = @"http://gatherer.wizards.com/Pages/Search/Default.aspx?";
    const string DB_CONNECTIONSTRING_ITA = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=""Magic_Cards_2003.mdb""";

		public Form1()
		{
			InitializeComponent();

		}

    private void mBtnDownloadList_Click(object sender, EventArgs e)
    {
      mList.Items.Clear();
      ListViewItem item;

      XmlDocument xSet = new XmlDocument();
      xSet.Load("mtg.polDb");
      XmlDocument xSetLang = new XmlDocument();
      xSetLang.Load("mtg_lang.polDb");

      foreach(XmlNode nodeSet in xSet.DocumentElement.SelectNodes("card_sets/item"))
      {
        string code = nodeSet.Attributes["code"].Value;
        if(code == "MBS")
        {
          XmlNode nodeSetLang = xSetLang.DocumentElement.SelectSingleNode(
            string.Format("card_sets_lang/item[@code='{0}' and @language='ENG']", code));
          item = new ListViewItem(code);
          DownloadList(code, nodeSetLang.Attributes["name"].Value);
          item.SubItems.Add("OK");
          mList.Items.Add(item);
          mList.EnsureVisible(mList.Items.Count - 1);
          Application.DoEvents();
        }
      }
      MessageBox.Show("OK");
    }

		private void mBtnDownLoadSpoiler_Click(object sender, EventArgs e)
		{
      XmlDocument xSet = new XmlDocument();
      xSet.Load("mtg.polDb");
      XmlDocument xSetLang = new XmlDocument();
      xSetLang.Load("mtg_lang.polDb");
      SpoilerDownloader downloader = new SpoilerDownloader();
      downloader.DownloadSpoiler(xSet, xSetLang, mList, mProgress);
      MessageBox.Show("OK");
    }

    private void DownloadList(string setCode, string setName)
    {
      string line;
      bool writeLine = false;

      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
          URL +
          "output=checklist&sort=cn+&set=[\"" + HttpUtility.UrlEncode(setName) + "\"]");
      request.MaximumAutomaticRedirections = 4;
      request.MaximumResponseHeadersLength = 4;
      request.Credentials = CredentialCache.DefaultCredentials;
      HttpWebResponse response = (HttpWebResponse)request.GetResponse();
      StringBuilder str = new StringBuilder();
      try
      {
        using(Stream receiveStream = response.GetResponseStream())
        {
          using(StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
          {
            while(!readStream.EndOfStream)
            {
              line = readStream.ReadLine();
              if(!writeLine && line.Trim() == "<table cellspacing=\"0\" cellpadding=\"2\" class=\"checklist\">")
                writeLine = true;
              if(writeLine)
                str.AppendLine(Program.XmlEncode(line));
              if(writeLine && line.Trim() == "</table>")
                break;
            }
          }
        }
      }
      finally
      {
        response.Close();
      }
      XmlDocument xSource = new XmlDocument();
      xSource.LoadXml(str.ToString());
      XmlDocument xDest = new XmlDocument();
      xDest.LoadXml("<list />");
      foreach(XmlNode node in xSource.SelectNodes("//tr[@class='cardItem']"))
      {
        string name = node.SelectSingleNode("td[@class='name']").InnerText;
        string id = node.SelectSingleNode("td[@class='name']/a/@href").InnerText.Split('=').Last();
        string color = node.SelectSingleNode("td[@class='color']").InnerText;
        XmlNode nodeCard = xDest.CreateNode(XmlNodeType.Element, "card", string.Empty);
        nodeCard.Attributes.Append(xDest.CreateAttribute("name")).InnerText = name;
        nodeCard.Attributes.Append(xDest.CreateAttribute("id")).InnerText = id;
        nodeCard.Attributes.Append(xDest.CreateAttribute("color")).InnerText = color;
        xDest.DocumentElement.AppendChild(nodeCard);
      }
      string setPath = setCode;
      if(!Directory.Exists(setPath))
        Directory.CreateDirectory(setPath);
      File.Delete(Path.Combine(setPath, "list.xml"));
      xDest.Save(Path.Combine(setPath, "list.xml"));
    }

    private void btnImportIta_Click(object sender, EventArgs e)
    {
      XmlDocument xSet = new XmlDocument();
      xSet.Load("mtg.polDb");
      XmlDocument xSetLang = new XmlDocument();
      xSetLang.Load("mtg_lang.polDb");

      XmlDocument xFileITACards = new XmlDocument();
      xFileITACards.LoadXml("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?><archive />");
      string fileITAContent = File.ReadAllText("rule-cards-italian.html", Encoding.GetEncoding("ISO-8859-1"));
      string[] fileITACards = fileITAContent.Split(new string[] { "<B><A" }, StringSplitOptions.RemoveEmptyEntries);
      foreach(var fileITACard in fileITACards.Skip(1))
      {
        var xmlContent = fileITACard.Substring(0, fileITACard.IndexOf("</TABLE>") + "</TABLE>".Length) + "</UL>";
        xmlContent = "<B><A" + xmlContent
          .Replace("RIGHT", "\"RIGHT\"")
          .Replace("disc", "\"disc\"")
          .Replace("</TR></TD>", "</TD></TR>")
          .Replace("<p>", "")
          .Replace("<BR{", "<BR />")
          ;
        XmlNode itaNode = xFileITACards.CreateElement("card");
        itaNode.InnerXml = xmlContent;
        xFileITACards.DocumentElement.AppendChild(itaNode);
      }
      xFileITACards.Save("rule-cards-italian.xml");

      //OleDbConnection connITA = new OleDbConnection(DB_CONNECTIONSTRING_ITA);
      //connITA.Open();
      foreach(XmlNode nodeSet in xSet.DocumentElement.SelectNodes("card_sets/item"))
      {
        string setCode = nodeSet.Attributes["code"].Value;
        string setName = xSetLang.DocumentElement.SelectSingleNode("card_sets_lang/item[@code='" + setCode + "' and @language='ITA']/@name").InnerText;
        string cardsPath = "cards\\" + setCode + ".xml";
        string cardsEngPath = "cards\\" + setCode + ".eng.xml";
        string cardsItaPath = "cards\\" + setCode + ".ita.xml";

        if(setCode != "MBS")
          continue;

        XmlDocument xCards = new XmlDocument();
        xCards.Load(cardsPath);
        XmlDocument xCardsEng = new XmlDocument();
        xCardsEng.Load(cardsEngPath);
        XmlDocument xCardsIta = new XmlDocument();
        xCardsIta.Load(cardsEngPath);

        xCardsIta.DocumentElement.Attributes["name"].Value = setName;

        //Dictionary<string, XmlNode> nodeLangById = new Dictionary<string, XmlNode>();
        //foreach(XmlNode n in xCardsEng.DocumentElement.ChildNodes)
        //  nodeLangById.Add(n["id"].InnerText, n);

        ListViewItem item = new ListViewItem(setCode);
        ListViewItem.ListViewSubItem subItem = item.SubItems.Add("...");
        mList.Items.Add(item);
        mList.EnsureVisible(mList.Items.Count - 1);
        this.Refresh();
        Application.DoEvents();

        CreaSetIta(setCode, xCards, xCardsEng, xCardsIta, /*connITA, */xFileITACards);

        xCardsIta.Save(cardsItaPath);

        subItem.Text = "OK";
        this.Refresh();
        Application.DoEvents();

      }

      MessageBox.Show(this, "Operazione completata");
    }

    private void CreaSetIta(string setCode, XmlDocument xCards, XmlDocument xCardsEng, XmlDocument xCardsIta, /*OleDbConnection connITA, */XmlDocument xFileITACards)
    {
      foreach(XmlNode cardNode in xCards.DocumentElement.SelectNodes("item"))
      {
        string[] codiciMancanti = File.ReadAllLines("Set_Mancanti.txt");
        if(!codiciMancanti.Contains(setCode))
        {
          string setITA = DecodificaCodiceSet(setCode);
          if(setITA.Length == 0)
            throw new Exception("Set " + setCode + " sconosciuto!");

          string nameEng = xCardsEng.SelectSingleNode("/cards/item[id='" + cardNode["id"].InnerText + "']")["name"].InnerText;

          XmlNode xFileITANode = xFileITACards.DocumentElement.SelectSingleNode("card[I=" + GenerateConcatForXPath("(" + nameEng + ")") + "]");
          if(xFileITANode != null)
          {
            xCardsIta.SelectSingleNode("/cards/item[id='" + cardNode["id"].InnerText + "']")["name"].InnerText = 
              xFileITANode.SelectSingleNode("B/A").InnerText;

            var text = xFileITANode.SelectSingleNode("UL/TABLE/TR[2]/TD").InnerText;
            text = text.Substring(text.IndexOf(": ") + ": ".Length);
            if(cardNode["type"].InnerText == "CRE" || cardNode["type"].InnerText == "ARC" || cardNode["type"].InnerText == "LCR" || cardNode["type"].InnerText == "SCR" || cardNode["type"].InnerText == "SAC")
            {
              int i = text.IndexOf(". ");
              if(text.Substring(0, i).Contains('/'))
                text = text.Substring(text.IndexOf(". ") + ". ".Length);
            }
            xCardsIta.SelectSingleNode("/cards/item[id='" + cardNode["id"].InnerText + "']")["text"].InnerText =
              NormalizzaTesto(text);

            xCardsIta.SelectSingleNode("/cards/item[id='" + cardNode["id"].InnerText + "']")["flavorText"].InnerText = "";
          }

          //OleDbCommand cmdITA = new OleDbCommand("SELECT Nome_Carta, Tipo, Testo FROM Magic_Cards WHERE English = ? AND Set = ?", connITA);
          //cmdITA.Parameters.Add("@English", OleDbType.LongVarWChar, 50).Value = xCardsEng.SelectSingleNode("/cards/item[id='" + cardNode["id"].InnerText + "']")["name"].InnerText;
          //cmdITA.Parameters.Add("@Set", OleDbType.LongVarWChar, 50).Value = setITA;

          //using(OleDbDataReader rdrITA = cmdITA.ExecuteReader())
          //{
          //  if(rdrITA.Read())
          //  {
          //    xCardsIta.SelectSingleNode("/cards/item[id='" + cardNode["id"].InnerText + "']")["name"].InnerText = rdrITA["Nome_Carta"].ToString();
          //    xCardsIta.SelectSingleNode("/cards/item[id='" + cardNode["id"].InnerText + "']")["text"].InnerText = NormalizzaTesto(rdrITA["Testo"].ToString());
          //    xCardsIta.SelectSingleNode("/cards/item[id='" + cardNode["id"].InnerText + "']")["flavorText"].InnerText = "";
          //  }
          //}
        }
      }
    }

    private string DecodificaCodiceSet(string setCode)
    {
      string itaCode = "";
      using(StreamReader fileCodici = File.OpenText("Codifica_set_ita.txt"))
      {
        while(!fileCodici.EndOfStream)
        {
          string line = fileCodici.ReadLine().Trim();
          if(line.Length > 0)
          {
            string[] codici = line.Split('=');
            if(codici[1] == setCode)
              itaCode = codici[0];
          }
        }
      }
      return itaCode;
    }

    private string NormalizzaTesto(string text)
    {
      text = text.Replace(" ; ", "\n");
      text = text.Replace("{TAP}", "{T}");
      text = text.Replace("{V}", "{G}");
      text = text.Replace("{B}", "{W}");
      text = text.Replace("{N}", "{B}");
      text = text.Replace("{L}", "{U}");

      return text;
    }

    private static string GenerateConcatForXPath(string a_xPathQueryString)
    {
      string returnString = string.Empty;
      string searchString = a_xPathQueryString;
      char[] quoteChars = new char[] { '\'', '"' };

      int quotePos = searchString.IndexOfAny(quoteChars);
      if(quotePos == -1)
      {
        returnString = "'" + searchString + "'";
      }
      else
      {
        returnString = "concat(";
        while(quotePos != -1)
        {
          string subString = searchString.Substring(0, quotePos);
          returnString += "'" + subString + "', ";
          if(searchString.Substring(quotePos, 1) == "'")
          {
            returnString += "\"'\", ";
          }
          else
          {
            //must be a double quote
            returnString += "'\"', ";
          }
          searchString = searchString.Substring(quotePos + 1,
                           searchString.Length - quotePos - 1);
          quotePos = searchString.IndexOfAny(quoteChars);
        }
        returnString += "'" + searchString + "')";
      }
      return returnString;
    }

	}
}