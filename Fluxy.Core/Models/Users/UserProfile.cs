using Fluxy.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxy.Core.Models.Users
{
    public class UserProfile : AuditableEntity<string>
    {
        public byte[] DisplayPicture { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string About { get; set; }
        public string Hobbies { get; set; }
    }
}
