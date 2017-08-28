using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fluxy.ViewModels.Menu
{
    public class SubMenuViewModel
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long MainMenuId { get; set; }
        [ForeignKey("MainMenuId")]
        public virtual MainMenuViewModel MainMenu { get; set; }
        [Required]
        public long MenuAttributeId { get; set; }
        [Required]
        public string Name { get; set; }
        public string ShortName { get; set; }
        [Required]
        public string LinkText { get; set; }
        [Required]
        public string ActionName { get; set; }
        [Required]
        public string ControllerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}