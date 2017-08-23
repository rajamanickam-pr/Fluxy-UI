using Fluxy.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxy.Core.Models.Menu
{
   public class MenuAttribute : Entity<long>
    {
        public string AttributeName { get; set; }
        public virtual IEnumerable<Attribute> Attributes { get; set; }
    }

    public class Attribute : Entity<long>
    {
        public long MenuAttributeId { get; set; }
        [ForeignKey("MenuAttributeId")]
        public virtual MenuAttribute MenuAttribute { get; set; }
        public string AttributeKey { get; set; }
        public string AttributeValue { get; set; }
    }
}
