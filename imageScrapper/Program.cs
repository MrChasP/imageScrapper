﻿// See https://aka.ms/new-console-template for more information
using imageScrapper;
using System.Data.SqlTypes;
using System.Xml;

//Console.WriteLine("Hello, World!");
//string cwd = Environment.CurrentDirectory;
//var firstPartofDirectory = cwd.Split(@"\source\");
//string newDirectory = firstPartofDirectory[0];
//Console.WriteLine(newDirectory + @"\pictures");
////BrowserManager.DownloadImage("https://images.squarespace-cdn.com/content/v1/5db4e539e4d7794c5fdd065f/1597094574604-9EKGYTJ3IS2P3LP9UXAM/IMG_20200122_111211_Original.jpg");


var url = @"D:\WebScrapper\squarespaceCrap\squarespaceCrap.xml";
var url2 = @"C:\Users\elk85\OneDrive\Desktop\xmlToTXT.txt";
var test = TxtParser.UrlToList(url2);
var urls = XmlParser.Reader(url);

Random testValue = new Random();
int i = 0;
foreach(XmlNode t in urls)
{
    var temp = t.InnerText;
    if (test.Contains(temp))
    {
        Console.WriteLine("Test: "+i+" Found image!");
    }
    i++;
}


//int i = 0;
//foreach (string s in test)
//{
//    Console.WriteLine(i);
//    Parallel.Invoke(() => BrowserManager.DownloadImage(s));
//    i++;
//}