using Fluxy.Core.Models.Localization;
using Fluxy.Core.Models.Video;
using System.ComponentModel.DataAnnotations.Schema;
using Fluxy.Core.Models.Categories;

namespace Fluxy.Data.ExtentedDTO
{
    public class VideoAttributesExtend : VideoAttributes
    {
        public string CategoryId { get; set; }
        [ForeignKey("CategoryId"), Column(Order = 1)]
        public virtual Category Category { get; set; }

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
