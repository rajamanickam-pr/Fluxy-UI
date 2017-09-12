using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fluxy.Areas.Admin.Models
{
    public class AdminViewModel
    {
        public int TotalRegisteredUsers { get; set; }
        public int AdultVideosCount { get; set; }
        public int PrivateVideosCount { get; set; }
        public int PublicVideosCount { get; set; }

    }
}