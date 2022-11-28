using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace imageScrapper
{
    /// <summary>
    /// This class will be utalized to open and navigate to the website along with downloading the image
    /// 
    /// </summary>
    internal class BrowserManager
    {
        
        private static string _url = String.Empty;

        /// <summary>
        /// Downloads the image to a new directory in the users Picture folder
        /// !!!WARNING!!! ONLY WORKS ON WINDOWS
        /// </summary>
        /// <param name="url">URL of the location of the .jpg</param>
        public static void DownloadImage([Optional] string url, [Optional] Uri uri, string userSaveLocation)
        {
            bool badInput = true;
            
            //TODO handle if the uri bad
            try
            {
                if (url == null) {
                    url = uri.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
            //TODO Should be HttpClient webClient = new HttpClient(); However, the HttpClient does not have a method for download content and will need some more work!
            WebClient webClient = new WebClient();
            
            
            string newDirectory = String.Empty;
            
             newDirectory = userSaveLocation+@"\yourPictures" ;
             _url = newDirectory;
            
             Directory.CreateDirectory(newDirectory);
             Directory.SetCurrentDirectory(newDirectory);
             var allFiles = Directory.GetFiles(newDirectory);
             var imageName = "image " + allFiles.Length+".jpg";

            try
            {
                webClient.DownloadFile(url, imageName);
                
            }
            catch (WebException e)
            {
                ErrorLog(url);
                Console.WriteLine("Hey heads up I couldn't download image at url: " + url+ " \n the browser threw the "+e.Message+" error!");
            }
                
           
        }
        public static void ErrorLog(string URL)
        {
            File.AppendText(_url + "\\ImageDownloaderErrorList.txt").WriteLine("The following URL did not work: "+URL);
        }
    }
}
