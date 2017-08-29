using Fluxy.Core.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fluxy.Core.Models.Menu
{
    public class SubMenu : AuditableEntity<string>
    {
        public string MainMenuId { get; set; }
        [ForeignKey("MainMenuId")]
        public virtual MainMenu MainMenu { get; set; }
        public string MenuAttributeId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string LinkText { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
    }
}
