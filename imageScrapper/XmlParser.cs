using Microsoft.Win32;
using System;
using System.Reflection.PortableExecutable;
using System.Xml;


internal class XmlParser
{
	public XmlParser(string url)
	{
		

        Reader(url);

	}

	public static XmlNodeList Reader(string url)
	{
		XmlReaderSettings settings = new XmlReaderSettings();
		XmlNodeList xmlNode;

		settings.IgnoreWhitespace = true;
		settings.IgnoreComments = true;
		settings.ConformanceLevel = ConformanceLevel.Fragment;
		
		XmlReader xmlReader= XmlReader.Create(url, settings);
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(xmlReader);
		List<Object> listBox1= new List<Object>();
		xmlDocument.ReadNode(xmlReader);

		

		var test = xmlReader.Read();
		while (xmlReader.Read())
        {
            switch (xmlReader.NodeType)
            {
				case XmlNodeType.Element:
                    listBox1.Add("<" + xmlReader.Name + ">");
					
                    break;
				case XmlNodeType.Text:
                    listBox1.Add(xmlReader.Value);
                    break;
                case XmlNodeType.EndElement:
                    listBox1.Add("");
                    break;
            }
        }

        var usefulInformation = xmlDocument.GetElementsByTagName("wp:attachment_url");



		var testInfo = xmlDocument.ReadNode(xmlReader);

		
    


		xmlReader.Close();



		var testTemp = xmlDocument.SelectNodes(@"//noscript");
	

		var desktopLocation = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
		
		Directory.SetCurrentDirectory(desktopLocation);
		var files = Directory.GetFiles(desktopLocation.ToString());
		if (!files.Contains(desktopLocation + @"\SchoolUrls"))
		{ Console.WriteLine("this is a test inside");
			Directory.CreateDirectory(desktopLocation.ToString() + @"\SchoolUrls");
			var urlTxtFile = desktopLocation.ToString() + @"\SchoolUrls";

            using (var sw = new StreamWriter(urlTxtFile+@"\newTest.txt", true))
			{
				foreach (XmlNode useful in usefulInformation)
				{
                    var temp = useful.InnerText;
                    sw.WriteLine(temp);
                }
				Console.WriteLine(sw.ToString());
			}

		}
		else
		{
            using (var sw = new StreamWriter(url, true))
            {
				sw.WriteLine("First 5072 URLs useing the wp:atatchment_url method");
                foreach (XmlNode useful in usefulInformation)
                {
					var temp = useful.InnerText;	
                    sw.WriteLine(temp);
                }
                Console.WriteLine(sw.ToString());
            }
		
        }		

		return usefulInformation;
		//var fullTextOutput = xmlReader.ReadContentAsString();
		//fullTextOutput= fullTextOutput.Trim();
		//var usefulOutput = fullTextOutput.Split("<img src=\"");
        

	}
}
