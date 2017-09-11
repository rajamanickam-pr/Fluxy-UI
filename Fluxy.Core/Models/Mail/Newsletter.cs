using Fluxy.Core.Common;

namespace Fluxy.Core.Models.Mail
{
    public class Newsletter : AuditableEntity<string>
    {
        public string Subscription { get; set; }
        public bool Active { get; set; }
    }
}
