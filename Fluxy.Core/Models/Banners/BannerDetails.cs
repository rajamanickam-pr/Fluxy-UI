using Fluxy.Core.Common;

namespace Fluxy.Core.Models.Banners
{
    public class BannerDetails : AuditableEntity<string>
    {
        public byte[] Image { get; set; }              
        public string Headline { get; set; }
        public string Slogans { get; set; }
        public string ButtonText { get; set; }
        public string Name { get; set; }
    }
}
