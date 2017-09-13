using Fluxy.ViewModels.Banners;
using Fluxy.ViewModels.Video;
using System.Collections.Generic;

namespace Fluxy.ViewModels.Home
{
    public class HomeViewModel
    {
        public IList<VideoAttributesViewModel> RecentVideos { get; set; }
        public IList<VideoAttributesViewModel> PopularVideos { get; set; }
        public IList<VideoAttributesViewModel> General { get; set; }
        public IList<VideoAttributesViewModel> Infotainment { get; set; }
        public IList<VideoAttributesViewModel> Entertainment { get; set; }
        public List<BannerDetailsViewModel> Banners { get; set; }
    }
}