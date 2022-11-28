using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace imageScrapper
{
    public class TxtParser
    {
        private static List<string> _listOfHolding = new List<string>();
        /// <summary>
        /// Used to parse the Urls out of a .txt file!
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static List<string> UrlToListAsync(string url)
        {
            var txtDocument = new List<string>();
            var urlList = new List<string>();
            string txtFile;
            char[] outPut;
            StringBuilder builder = new StringBuilder();
            
            try
            {  
                txtFile = File.ReadAllText(url);
                var messyPart = txtFile.Split("<");
                txtDocument = messyPart.ToList();

                foreach(string s in txtDocument)
                {
                    if(s.Contains("https") || s.Contains("http"))
                    {
                        urlList.Add(s); 
                    }
                }
                var test = XmlSyntaxCleaning(urlList);

                for (int i = 0; i < 10; i++)
                {
                    test = XmlSyntaxCleaning(test);
                    txtDocument = test;
                }



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Would you like to save a file with all of the URLS? Y/N");
            var userInput = Console.ReadLine();
            //TODO setup a question to ask them where they would like to save the file
            if(userInput == "y" || userInput== "yes"||userInput =="Y") 
            {
                Console.WriteLine("File will be saved to your desktop!");
                CopyToFile(txtDocument,null);
            }
          
            return txtDocument;
        }
        public static async Task CopyToFile(List<string> list, string? fileSaveLocation)
        {
            if (fileSaveLocation == null)
            {
                fileSaveLocation = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            await File.WriteAllLinesAsync(fileSaveLocation + "\\AllURLImages.txt", list);

        }
        //TODO CLEAN UP FUNCTION MAKE IT JUST THE LOOPING PATERN AT THE END!
        public static List<string> XmlSyntaxCleaning(List<string> messy)
        {

            List<string> tempDump = new();
            List<string> cleanedUp = new();
       
          
            foreach (string s in messy)
            {
                if (s.Contains("https")||s.Contains("http"))
                {
                    if (s.Contains("images"))
                    {
                        cleanedUp.Add(s);
                    }
                    
                }
            }
            tempDump = cleanedUp;
            tempDump = new();
            foreach (string c in cleanedUp)
            {
                    var temp = c.Split("=");
                    foreach (string s in temp)
                    {
                        if (s.Contains("https") || s.Contains("http"))
                        {
                            tempDump.Add(s);
                        }
                    }
            }
            cleanedUp = tempDump;
            tempDump = new();
            foreach (string c in cleanedUp)
            {
                var temp = c.Split("\"");
                foreach (string s in temp)
                {
                    if (s.Contains("https") || s.Contains("http"))
                    {
                        tempDump.Add(s);
                    }
                }
            }
            cleanedUp = tempDump;
            tempDump = new();
            foreach (string c in cleanedUp)
            {
                var temp = c.Split(@"""");
                foreach (string s in temp)
                {
                    if (s.Contains("https") || s.Contains("http"))
                    {
                        tempDump.Add(s);
                    }
                }
            }
            cleanedUp = tempDump;
            tempDump = new();
            foreach (string c in cleanedUp)
            {
                var temp = c.Split(">");
                foreach (string s in temp)
                {
                    if (s.Contains("https") || s.Contains("http"))
                    {
                        tempDump.Add(s);
                    }
                }
            }
            cleanedUp = tempDump;
            cleanedUp = DuplicationCheck(cleanedUp);
            return cleanedUp;

        }
        public static List<string> DuplicationCheck(List<string> messy)
        {
            List<string> final = new();
           
             var test = messy.Distinct();
            return final = test.ToList();

        }
    }
}
