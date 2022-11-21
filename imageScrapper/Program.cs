// See https://aka.ms/new-console-template for more information
using imageScrapper;
using System.Xml;

var url = "https://images.squarespace-cdn.com/content/v1/5db4e539e4d7794c5fdd065f/1597094574604-9EKGYTJ3IS2P3LP9UXAM/IMG_20200122_111211_Original.jpg";
Console.WriteLine("Hello, World!");
//var allURLS = XmlParserContext.SOMETHING HERE ;
foreach(string urlString:){ 
Parallel.Invoke(() => BrowserManager.DownloadImage(urlString));}
