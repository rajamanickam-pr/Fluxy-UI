using System.Collections.Generic;

namespace Fluxy.ViewModels.Video
{
    public class ShowVideoViewModel
    {
        public VideoAttributesViewModel SelectedVideo { get; set; }
        public IEnumerable<VideoAttributesViewModel> RecentlyAdded { get; set; }
        public IEnumerable<VideoAttributesViewModel> PopularVideo { get; set; }
        public IEnumerable<VideoAttributesViewModel> UserMayLike { get; set; }
    }
}