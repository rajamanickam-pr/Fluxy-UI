using Fluxy.Core.Common;
using System.Collections.Generic;

namespace Fluxy.Core.Models.Common
{
    public class Category : AuditableEntity<string>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<SubCategory> SubCategories { get; set; }
    }
}
