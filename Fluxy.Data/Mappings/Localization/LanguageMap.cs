using Fluxy.Core.Models.Localization;

namespace Fluxy.Data.Mappings.Localization
{
    public class LanguageMap : FluxyEntityTypeConfiguration<Language>
    {
        public LanguageMap()
        {
            this.ToTable("Language");
            this.HasKey(sm => sm.Id);
            this.Property(sm => sm.Name).IsRequired().HasMaxLength(200);
            this.Property(sm => sm.DefaultCurrency).HasMaxLength(50);
            this.Property(sm => sm.LanguageCulture).HasMaxLength(100);
        }
    }
}
