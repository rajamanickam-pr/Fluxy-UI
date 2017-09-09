using Fluxy.ViewModels.Video;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fluxy.ViewModels.Home
{
    public class HomeViewModel
    {
        public IPagedList<VideoAttributesViewModel> RecentVideos { get; set; }
        public IPagedList<VideoAttributesViewModel> PopularVideos { get; set; }
    }
}