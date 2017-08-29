using Fluxy.Core.Models.Video;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fluxy.Data.ExtentedDTO
{
    public class PrivateVideoExtend : PrivateVideo
    {
        public string FromUserId { get; set; }
        [ForeignKey("FromUserId")]
        public virtual ApplicationUser FromUser { get; set; }

        public string ToUserId { get; set; }
        [ForeignKey("ToUserId")]
        public virtual ApplicationUser ToUser { get; set; }
    }
}
