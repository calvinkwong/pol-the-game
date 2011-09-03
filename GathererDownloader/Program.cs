using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace ScaricaSpoilers
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}

    public static string XmlEncode(string str)
    {
      return str.Replace("&", "&#38;").Replace("Æ", "&#198;").Replace("â", "&#226;");
      //XmlDocument doc = new XmlDocument();
      //XmlNode node = doc.AppendChild(doc.CreateElement("xml"));
      //node.InnerText = str;
      //StringWriter writer = new StringWriter();
      //XmlTextWriter xml_writer = new XmlTextWriter(writer);
      //node.WriteContentTo(xml_writer);
      //return writer.ToString();
    }
	}
}