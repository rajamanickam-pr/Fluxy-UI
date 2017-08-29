using Fluxy.Core.Common;

namespace Fluxy.Core.Models.Localization
{
    public class Language:AuditableEntity<string>
    {
        public string Name { get; set; }
        public string LanguageCulture { get; set; }
        public bool Rtl { get; set; }
        public string DefaultCurrency { get; set; }
    }
}
