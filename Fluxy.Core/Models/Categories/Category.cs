using Fluxy.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxy.Core.Models.Common
{
    public class Category : AuditableEntity<string>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<SubCategory> SubCategories { get; set; }
    }
}
