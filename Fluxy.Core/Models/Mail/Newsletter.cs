using Fluxy.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxy.Core.Models.Mail
{
    public class Newsletter : AuditableEntity<string>
    {
        public string Email { get; set; }
        public bool Active { get; set; }
    }
}
