using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace imageScrapper
{
    /// <summary>
    /// This class will be utalized to open and navigate to the website along with downloading the image
    /// @Author: Chas Phyle
    /// </summary>
    internal class BrowserManager
    {
        /// <summary>
        /// 
        /// </summary>
        private string _url;
        public static void DownloadImage(string url)
        {
            WebClient webClient = new WebClient();
            string cwd = Environment.CurrentDirectory;
            var firstPartofDirectory = cwd.Split(@"\source\");
            string newDirectory = firstPartofDirectory[0]+@"\pictures\schoolPictures" ;
            
            if(Directory.Exists(newDirectory))
            {
                var allFiles = Directory.GetFiles(newDirectory);
                var imageName = "image " + allFiles.Length;
                webClient.DownloadFile(url, imageName + ".jpg");

            }
            else
            {
                Directory.CreateDirectory(newDirectory);
                var allFiles = Directory.GetFiles(newDirectory);
                var imageName = "image " + allFiles.Length;
                webClient.DownloadFile(url, imageName + ".jpg");
            }
        }
    }
}
