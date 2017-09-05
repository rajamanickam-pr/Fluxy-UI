using System.ComponentModel.DataAnnotations.Schema;
using Fluxy.Core.Common;

namespace Fluxy.Core.Models.Categories
{
    public class SubCategory : AuditableEntity<string>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
