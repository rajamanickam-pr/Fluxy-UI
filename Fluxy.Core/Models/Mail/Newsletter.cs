using Fluxy.Core.Common;

namespace Fluxy.Core.Models.Mail
{
    public class Newsletter : AuditableEntity<string>
    {
        public string Email { get; set; }
        public bool Active { get; set; }
    }
}
