using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Fluxy.Core.Helpers
{
    public static class ImageHelpers
    {
        public static async Task<byte[]> GetYouTubeThumbnail(string videoId, string friendlyTitle)
        {
            if (!string.IsNullOrWhiteSpace(videoId))
            {
                var url = $"https://img.youtube.com/vi/{videoId}/hqdefault.jpg";
                WebClient wc = new WebClient();
                byte[] originalData = await wc.DownloadDataTaskAsync(new System.Uri(url));

                var fileName = System.Web.Hosting.HostingEnvironment.MapPath($"~/Images/{friendlyTitle}{".png"}");
                if (!File.Exists(fileName))
                {
                    using (MemoryStream ms = new MemoryStream(originalData))
                    {
                        Image.FromStream(ms).Save(fileName);
                    }
                }
                return originalData;
            }
            return null;
        }

        public static void GetThumbnail(byte[] imgArray, string friendlyTitle)
        {
            if (imgArray.Length > 0)
            {
                var fileName = System.Web.Hosting.HostingEnvironment.MapPath($"~/Images/{friendlyTitle}{".png"}");
                if (!File.Exists(fileName))
                {
                    using (MemoryStream ms = new MemoryStream(imgArray))
                    {
                        Image.FromStream(ms).Save(fileName);
                    }
                }
            }
        }
    }
}
