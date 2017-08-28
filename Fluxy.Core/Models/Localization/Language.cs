using FleetTracker.Core.Common;
using Fluxy.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxy.Core.Models.Localization
{
    public class Language:AuditableEntity<long>
    {
        public string Name { get; set; }
        public string LanguageCulture { get; set; }
        public bool Rtl { get; set; }
        public string DefaultCurrency { get; set; }
    }
}
