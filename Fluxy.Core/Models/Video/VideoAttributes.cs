using Fluxy.Core.Common;

namespace Fluxy.Core.Models.Video
{
    public class VideoAttributes : AuditableEntity<string>
    {
        public string Title { get; set; }
        public string ShortName { get; set; }
        public string Url { get; set; }
        public string Length { get; set; }
        public string Tags { get; set; }
        public string Description { get; set; }

        public byte[] Thumbunail { get; set; }

        public bool IsPublicVideo { get; set; }
        public bool IsAdultContent { get; set; }
        public bool IsAllowFullScreen { get; set; }
        public long ViewCount { get; set; }
    }
}
