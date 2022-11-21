// See https://aka.ms/new-console-template for more information
using imageScrapper;

Console.WriteLine("Hello, World!");
string cwd = Environment.CurrentDirectory;
var firstPartofDirectory = cwd.Split(@"\source\");
string newDirectory = firstPartofDirectory[0];
Console.WriteLine(newDirectory + @"\pictures");
//BrowserManager.DownloadImage("https://images.squarespace-cdn.com/content/v1/5db4e539e4d7794c5fdd065f/1597094574604-9EKGYTJ3IS2P3LP9UXAM/IMG_20200122_111211_Original.jpg");

