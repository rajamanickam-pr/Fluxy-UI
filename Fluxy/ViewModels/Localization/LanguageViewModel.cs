using System;
using System.ComponentModel.DataAnnotations;

namespace Fluxy.ViewModels.Localization
{
    public class LanguageViewModel
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string LanguageCulture { get; set; }
        public bool Rtl { get; set; }
        public string DefaultCurrency { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}