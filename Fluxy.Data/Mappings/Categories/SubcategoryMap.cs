using Fluxy.Core.Models.Common;

namespace Fluxy.Data.Mappings.Categories
{
    public class SubcategoryMap:FluxyEntityTypeConfiguration<SubCategory>
    {
        public SubcategoryMap()
        {
            this.ToTable("Subcategory");
            this.HasKey(sm => sm.Id);
            this.Property(sm => sm.Name).IsRequired().HasMaxLength(100);
            this.Property(sm => sm.Description).HasMaxLength(200);
        }
    }
}
