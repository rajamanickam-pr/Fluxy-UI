using Fluxy.Core.Common;

namespace Fluxy.Core.Models.Categories
{
    public class Category : AuditableEntity<string>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
