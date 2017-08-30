using Fluxy.Core.Common;

namespace Fluxy.Core.Models.Menu
{
    public class MenuAttribute : AuditableEntity<string>
    {
        public string AttributeKey { get; set; }
        public string AttributeValue { get; set; }
    }
}
