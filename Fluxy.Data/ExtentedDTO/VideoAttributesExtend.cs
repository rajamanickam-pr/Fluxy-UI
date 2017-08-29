using Fluxy.Core.Models.Common;
using Fluxy.Core.Models.Localization;
using Fluxy.Core.Models.Video;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxy.Data.ExtentedDTO
{
    public class VideoAttributesExtend : VideoAttributes
    {
        public string SubcategoryId { get; set; }
        [ForeignKey("SubcategoryId"), Column(Order = 1)]
        public virtual SubCategory SubCategory { get; set; }

        public string LanguageId { get; set; }
        [ForeignKey("LanguageId"), Column(Order = 2)]
        public virtual Language Language { get; set; }

        public string VideoSettingsId { get; set; }
        [ForeignKey("VideoSettingsId"), Column(Order = 3)]
        public virtual VideoSettings VideoSettings { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId"), Column(Order = 4)]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
