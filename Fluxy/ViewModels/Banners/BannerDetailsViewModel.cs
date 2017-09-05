using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fluxy.ViewModels.Banners
{
    public class BannerDetailsViewModel
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public byte[] Image { get; set; }
        [Required]
        public string Headline { get; set; }
        [Required]
        public string Slogans { get; set; }
        [Required]
        public string ButtonText { get; set; }
        public string Name { get; set; }
        public HttpPostedFileBase fileBase { get; set; }
        public string ImageString => Convert.ToBase64String(this.Image);
    }
}