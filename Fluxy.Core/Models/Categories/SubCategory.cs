using Fluxy.Core.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fluxy.Core.Models.Common
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
