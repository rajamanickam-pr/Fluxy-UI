using Boilerplate.Web.Mvc;
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
        //[RegularExpression(@"^[0-9a-zA-Z'\s-]{1,40}$", ErrorMessage = "special characters are not allowed except hyphen.")]
        public string Title { get; set; }
        [StringLength(240, ErrorMessage = "ShortName cannot be longer than 240 characters.")]
        public string ShortName { get; set; }
        [Required]
        [DataType(DataType.Url)]
        [RegularExpression(@"^(?:https?:\/\/)?(?:www\.)?(?:youtu\.be\/|youtube\.com\/(?:embed\/|v\?.+&v=))((?:\w|-){11})(?:&list=(\S+))?$",
            ErrorMessage = "Url should be from embed youtube.")]
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
                if (Thumbunail?.Length > 0)
                {
                    return Convert.ToBase64String(this.Thumbunail);
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public string Slug
        {
            get
            {
                return FriendlyUrlHelper.GetFriendlyTitle(this.Title);
            }
        }

        public virtual IEnumerable<CategoryViewModel> Categories { get; set; }
        public virtual IEnumerable<LanguageViewModel> Languages { get; set; }
        public virtual IEnumerable<VideoSettingsViewModel> VideoSettingses { get; set; }
    }
}