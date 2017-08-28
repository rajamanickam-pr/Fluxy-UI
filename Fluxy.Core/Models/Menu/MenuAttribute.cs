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
        public string AttributeKey { get; set; }
        public string AttributeValue { get; set; }
    }
}
