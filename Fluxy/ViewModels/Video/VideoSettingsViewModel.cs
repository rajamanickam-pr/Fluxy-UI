using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fluxy.ViewModels.Video
{
    public class VideoSettingsViewModel
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int FrameWidth { get; set; }
        [Required]
        public int FrameHeight { get; set; }
        public string FrameFilters { get; set; }

        public virtual VideoAttributesViewModel VideoAttributes { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}