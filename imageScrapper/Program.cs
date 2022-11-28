
using imageScrapper;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Xml;

bool badInput = true;
string userURL = string.Empty;
//TODO add more file formats
do
{
    Console.WriteLine("Welcome \n depending on your internet speed, and amount of urls this could take a while.\nThe estimated time left posted during the downloading phase is simply an estimate and should be treated as an estimate.\n Please paste the file location in! Excepted File formats: .TXT");
    var userInput = Console.ReadLine();

    if (File.Exists(userInput))
    {
        badInput = false;
        userURL = userInput;
        
    }
} while (badInput);


var txtParsedURL = TxtParser.UrlToListAsync(userURL);
badInput = true;
string userSaveLocation = string.Empty;
do
{
    
    Console.WriteLine("Where would you like the pictures to be saved? Click enter to save to desktop in a folder.");
    var userInput = Console.ReadLine();

    if (File.Exists(userInput))
    {
        badInput = false;
        userSaveLocation = userInput;

    }
    if(userInput == null || userInput =="")
    {
        badInput = false;
        userSaveLocation = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    }
} while (badInput);
Stopwatch stopwatch= Stopwatch.StartNew();
int i = 1;
List<TimeSpan> timeList = new List<TimeSpan>();
foreach (var s in txtParsedURL)
{
    stopwatch.Restart();
    stopwatch.Start();
    Console.WriteLine(i+ " out of "+txtParsedURL.Count+ " have been downloaded");
    Parallel.Invoke(() => BrowserManager.DownloadImage(s,null, userSaveLocation));
    i++;
    Console.Clear();
    stopwatch.Stop();
    var timeTaken = stopwatch.Elapsed;
    var timeRemaining = timeTaken * (txtParsedURL.Count - i);
    timeRemaining = timeRemaining / 60;
    timeList.Add(timeRemaining);
    double timeLeft = 0;
    foreach(var t in timeList)
    {
        timeLeft = timeLeft + t.TotalSeconds;
    }

    Console.WriteLine("Approximately " + ((int)(timeLeft/timeList.Count)) + " min remaining");
}