using System;
using System.ComponentModel.DataAnnotations;

namespace Fluxy.ViewModels.Banners
{
    public class BannerDetailsViewModel
    {
        [Key]
        public string Id { get; set; }
        public byte[] Image { get; set; }
        [Required]
        public string Headline { get; set; }
        [Required]
        public string Slogans { get; set; }
        [Required]
        public string ButtonText { get; set; }
        public string ButtonUrl { get; set; }
        public string Name { get; set; }
        public string ImageString => Convert.ToBase64String(this.Image);
    }
}