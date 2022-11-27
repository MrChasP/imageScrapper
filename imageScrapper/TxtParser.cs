using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imageScrapper
{
    public class TxtParser
    {
        public static List<string> UrlToList(string url)
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
                    if(s.Contains("https"))
                    {
                        urlList.Add(s); 
                    }
                }var test = ThingsToRemove(urlList);
                for(int i =0; i < 10; i++)
                {
                    test = ThingsToRemove(test);
                    txtDocument = test;
                }
                
                
            
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return txtDocument;
        }
        //TODO CLEAN UP FUNCTION MAKE IT JUST THE LOOPING PATERN AT THE END!
        public static List<string> ThingsToRemove(List<string> messy)
        {
            List<string> charToRemove = new();
            List<string> tempDump = new();
            List<string> cleanedUp = new();
            charToRemove.Add("<");
            charToRemove.Add(">");
            charToRemove.Add("img");
            charToRemove.Add("class");
            charToRemove.Add("thumb-image");
            charToRemove.Add(@"""");
            charToRemove.Add("=");
            charToRemove.Add("src");



            foreach(string s in messy)
            {
                if (s.Contains("https"))
                {
                    if (s.Contains("images"))
                    {
                        cleanedUp.Add(s);

                    }
                    
                }
            }

            tempDump = cleanedUp;
            List<string> randomDeleteMe = new();
            foreach(string s in charToRemove)
            {
                cleanedUp.RemoveAll(t => t == s);
            }
            tempDump = new();
            foreach(string c in cleanedUp)
            {
                var temp = c.Split(@"=");
                foreach(string s in temp)
                {
                    if (s.Contains("https"))
                    {
                        var temp2 = s.Split(" ");
                        foreach(string j in temp2)
                        {
                            if (j.Contains("https"))
                            {
                                tempDump.Add(j);
                            }
                        }
                        
                    }
                }
            }
            cleanedUp = tempDump;
            tempDump = new();
            foreach(string c in cleanedUp)
            {
                var temp = c.Split("\r");
                foreach(string s in temp)
                {
                    if (s.Contains("https"))
                    {
                        tempDump.Add(s);
                    }
                }
            }
            cleanedUp = tempDump;
            tempDump = new();
            foreach(string c in cleanedUp)
            {
                var temp = c.Split("\"");
                foreach(string s in temp)
                {
                    if (s.Contains("https"))
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
                    if (s.Contains("https"))
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
