using Fluxy.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxy.Core.Models.Menu
{
    public class SubMenu : AuditableEntity<long>
    {
        public long MainMenuId { get; set; }
        [ForeignKey("MainMenuId")]
        public virtual MainMenu MainMenu { get; set; }

        public long MenuAttributeId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string LinkText { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
    }
}
