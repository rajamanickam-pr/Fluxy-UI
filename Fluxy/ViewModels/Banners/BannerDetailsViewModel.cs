using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Fluxy.ViewModels.Banners
{
    public class BannerDetailsViewModel
    {
        [Key]
        public string Id { get; set; }
        public byte[] Image { get; set; }
        public HttpPostedFileBase File { get; set; }
        [Required]
        public string Headline { get; set; }
        [Required]
        public string Slogans { get; set; }
        [Required]
        public string ButtonText { get; set; }
        public string ButtonUrl { get; set; }
        public string Name { get; set; }
        public string ImageString
        {
            get
            {
                if (this.Image.Length > 0)
                {
                    return Convert.ToBase64String(this.Image);

                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}