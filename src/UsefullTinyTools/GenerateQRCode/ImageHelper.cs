using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;

namespace GenerateQRCode
{
    public static class ImageHelper
    {
        public static Image UrlToImage( string url )
        {
            using WebClient mywebclient = new WebClient();
            byte[] Bytes = mywebclient.DownloadData(url);
            using MemoryStream ms = new MemoryStream(Bytes);
            Image outputImg = Image.FromStream(ms);
            return outputImg;
        }

    }
}
