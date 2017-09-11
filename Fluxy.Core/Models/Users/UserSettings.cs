using Fluxy.Core.Common;

namespace Fluxy.Core.Models.Users
{
    public class UserSettings : AuditableEntity<string>
    {
        public bool CanISeeEPContent { get; set; }
        public bool IsMyDpPublic { get; set; }
    }
}
