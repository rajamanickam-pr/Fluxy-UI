using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fluxy.ViewModels.Menu
{
    public class MainMenuViewModel
    {
        [Key]
        public string Id { get; set; }
        public string MenuAttributeId { get; set; }
        [Required]
        [Display(Name="MainMenuName")]
        public string Name { get; set; }
        public string ShortName { get; set; }
        [Required]
        public string LinkText { get; set; }
        [Required]
        public string ActionName { get; set; }
        [Required]
        public string ControllerName { get; set; }
        public virtual IEnumerable<SubMenuViewModel> SubMenus { get; set; }
        public virtual IEnumerable<MenuAttributeViewModel> MenuAttributes { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}