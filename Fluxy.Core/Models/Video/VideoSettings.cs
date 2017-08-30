using Fluxy.Core.Common;

namespace Fluxy.Core.Models.Video
{
    public class VideoSettings : AuditableEntity<string>
    {
        public string Name { get; set; }
        public int FrameWidth { get; set; }
        public int FrameHeight { get; set; }
        public string FrameFilters { get; set; }

        public virtual VideoAttributes VideoAttributes { get; set; }
    }
}
