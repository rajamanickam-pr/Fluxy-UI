using Fluxy.Core.Common;
using System;

namespace Fluxy.Core.Models.Users
{
    public class UserProfile : AuditableEntity<string>
    {
        public byte[] DisplayPicture { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public string Bio { get; set; }
        public DateTime Dob { get; set; }
        public int Age { get; set; }
        public string About { get; set; }
        public string Hobbies { get; set; }
        public bool IsActive { get; set; }
    }
}
