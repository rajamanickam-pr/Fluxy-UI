using Fluxy.ViewModels.Categories;
using Fluxy.ViewModels.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fluxy.ViewModels.Video
{
    public class VideoAttributesViewModel
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
        public string ShortName { get; set; }
        public string Url { get; set; }
        public string Length { get; set; }
        public string Tags { get; set; }
        public string Description { get; set; }
        public string VideoId { get; set; }
        
        public byte[] Thumbunail { get; set; }

        public bool IsPublicVideo { get; set; }
        public bool IsAdultContent { get; set; }
        public bool IsAllowFullScreen { get; set; }
        public long ViewCount { get; set; }

        public string SubcategoryId { get; set; }
        [ForeignKey("SubcategoryId")]
        public virtual SubCategoryViewModel SubCategory { get; set; }

        public string LanguageId { get; set; }
        [ForeignKey("LanguageId")]
        public virtual LanguageViewModel Language { get; set; }

        public string VideoSettingsId { get; set; }
        [ForeignKey("VideoSettingsId")]
        public virtual VideoSettingsViewModel VideoSettings { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual Data.ApplicationUser ApplicationUser { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}