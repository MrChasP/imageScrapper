﻿using System;
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
    /// @Author: Chas Phyle
    /// </summary>
    internal class BrowserManager
    {
        
        private string _url;
        /// <summary>
        /// Downloads the image to a new directory in the users Picture folder
        /// !!!WARNING!!! ONLY WORKS ON WINDOWS
        /// </summary>
        /// <param name="url">URL of the location of the .jpg</param>
        public static void DownloadImage([Optional]string url, [Optional] Uri uri)
        {
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
            WebClient webClient = new WebClient();
            string cwd = Environment.CurrentDirectory;
            var firstPartofDirectory = cwd.Split(@"\source\");
            string newDirectory = firstPartofDirectory[0]+@"\Pictures\schoolPictures" ; //Needs to change for general release!
            
            if(Directory.Exists(newDirectory))
            {   
                Directory.SetCurrentDirectory(newDirectory);
                var allFiles = Directory.GetFiles(newDirectory);
                var imageName = "image " + allFiles.Length+".jpg";
                webClient.DownloadFile(url, imageName);
                
            }
            else
            {
                Directory.CreateDirectory(newDirectory);
                Directory.SetCurrentDirectory(newDirectory);
                var allFiles = Directory.GetFiles(newDirectory);
                var imageName = "image " + allFiles.Length;
                webClient.DownloadFile(url, imageName + ".jpg");
            }
        }
    }
}
