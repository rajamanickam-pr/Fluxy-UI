using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fluxy.ViewModels.Menu
{
    public class SubMenuViewModel
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string MainMenuId { get; set; }
        [ForeignKey("MainMenuId")]
        public virtual MainMenuViewModel MainMenu { get; set; }
        [Required]
        public string MenuAttributeId { get; set; }
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