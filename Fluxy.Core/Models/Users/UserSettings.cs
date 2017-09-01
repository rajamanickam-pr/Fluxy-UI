using Fluxy.Core.Common;

namespace Fluxy.Core.Models.Users
{
    public class UserSettings : AuditableEntity<string>
    {
        public bool CanAnyoneSendMessage { get; set; }
        public bool CanAnyoneSendVideo { get; set; }
        public bool IsMyDpPublic { get; set; }
    }
}
