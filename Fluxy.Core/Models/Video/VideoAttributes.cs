using Fluxy.Core.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxy.Core.Models.Video
{
    public class VideoAttributes:AuditableEntity<long>
    {
        public string Title { get; set; }
        public string ShortName { get; set; }
        public string Url { get; set; }
        public string Length { get; set; }
        public int FrameWidth { get; set; }
        public int FrameHeight { get; set; }
        public int ViewCount { get; set; }
        public string Tags { get; set; }
        public Bitmap Thumbunail { get; set; }

        public int SubcategoryId { get; set; }
        public int LanguageId { get; set; }

    }
}
