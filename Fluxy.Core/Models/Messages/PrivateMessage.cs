using Fluxy.Core.Common;

namespace Fluxy.Core.Models.Messages
{
    public class PrivateMessage:AuditableEntity<string>
    {
        public string Subject { get; set; }
        public string Text { get; set; }
        public bool IsRead { get; set; }
        public bool IsDeletedByAuthor { get; set; }
        public bool IsDeletedByRecipient { get; set; }
    }
}
