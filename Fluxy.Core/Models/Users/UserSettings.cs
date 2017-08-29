using Fluxy.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxy.Core.Models.Users
{
    public class UserSettings : AuditableEntity<string>
    {
        public bool CanAnyoneSendMessage { get; set; }
        public bool CanAnyoneSendVideo { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
