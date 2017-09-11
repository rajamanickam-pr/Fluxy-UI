using Fluxy.ViewModels.Categories;
using Fluxy.ViewModels.Localization;
using Fluxy.ViewModels.Mail;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fluxy.ViewModels.Video
{
    public class VideoAttributesViewModel
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string ShortName { get; set; }
        [Required]
        [DataType(DataType.Url)]
        [RegularExpression(@"^(?:https?:\/\/)?(?:www\.)?youtube\.com\/watch\?(?=.*v=((\w|-){11}))(?:\S+)?$", ErrorMessage = "Url should be from youtube.")]
        public string Url { get; set; }
        public string Length { get; set; }
        public string Tags { get; set; }
        [Required]
        public string Description { get; set; }
        public string VideoId { get; set; }
        
        public byte[] Thumbunail { get; set; }

        public bool IsPublicVideo { get; set; }
        public bool IsAdultContent { get; set; }
        public bool IsAllowFullScreen { get; set; }
        public long ViewCount { get; set; }

        public string CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual CategoryViewModel Category { get; set; }

        public string LanguageId { get; set; }
        [ForeignKey("LanguageId")]
        public virtual LanguageViewModel Language { get; set; }

        public string VideoSettingsId { get; set; }
        [ForeignKey("VideoSettingsId")]
        public virtual VideoSettingsViewModel VideoSettings { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual Data.ApplicationUser ApplicationUser { get; set; }
        public virtual NewsletterViewModel NewsletterViewModel { get; set; }
        public string ThumbunailString
        {
            get
            {
                return Convert.ToBase64String(this.Thumbunail);
            }
        }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }


        public virtual IEnumerable<CategoryViewModel> Categories { get; set; }
        public virtual IEnumerable<LanguageViewModel> Languages { get; set; }
        public virtual IEnumerable<VideoSettingsViewModel> VideoSettingses { get; set; }
    }
}