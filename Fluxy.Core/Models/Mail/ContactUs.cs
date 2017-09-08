using Fluxy.Core.Common;

namespace Fluxy.Core.Models.Mail
{
    public class ContactUs : AuditableEntity<string>
    {
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
