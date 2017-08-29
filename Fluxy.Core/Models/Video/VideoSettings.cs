using Fluxy.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxy.Core.Models.Video
{
    public class VideoSettings : AuditableEntity<string>
    {
        public int FrameWidth { get; set; }
        public int FrameHeight { get; set; }
        public string FrameFilters { get; set; }

        public virtual VideoAttributes VideoAttributes { get; set; }
    }
}
