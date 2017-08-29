using Fluxy.Core.Common;
using System.Collections.Generic;

namespace Fluxy.Core.Models.Menu
{
    public class MainMenu : AuditableEntity<string>
    {
        public string MenuAttributeId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string LinkText { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public virtual IEnumerable<SubMenu> SubMenus { get; set; }
        public virtual IEnumerable<MenuAttribute> MenuAttributes { get; set; }
    }
}
