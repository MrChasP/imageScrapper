using System;
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

		settings.IgnoreWhitespace = true;
		settings.IgnoreComments = true;
		settings.ConformanceLevel = ConformanceLevel.Fragment;
		settings.DtdProcessing = DtdProcessing.Parse;
		XmlReader xmlReader= XmlReader.Create(url, settings);
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(xmlReader);
		
		var usefulInformation = xmlDocument.GetElementsByTagName("wp:attachment_url");
		var usefulTest = xmlDocument.GetElementsByTagName("sqs-image-shape-container-element");
        String lastTagName = "";
		xmlReader.MoveToContent();
        while (xmlReader.Read() )
		{
			switch(xmlReader.NodeType)
			{
				case XmlNodeType.Element:
					lastTagName = xmlReader.Name;
					if(lastTagName == "<no script>")
					{
						Console.WriteLine(lastTagName); 
					}
				break;
			}
		}



		var testTemp = xmlDocument.SelectNodes(@"//noscript");
		foreach(var useful in usefulTest)
		{
			Console.WriteLine(useful.ToString());
		}

		return usefulInformation;
		//var fullTextOutput = xmlReader.ReadContentAsString();
		//fullTextOutput= fullTextOutput.Trim();
		//var usefulOutput = fullTextOutput.Split("<img src=\"");
        

	}
}
