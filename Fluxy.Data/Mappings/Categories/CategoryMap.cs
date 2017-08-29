using Fluxy.Core.Models.Common;

namespace Fluxy.Data.Mappings.Categories
{
    public class CategoryMap : FluxyEntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            this.ToTable("Category");
            this.HasKey(sm => sm.Id);
            this.Property(sm => sm.Name).IsRequired().HasMaxLength(100);
            this.Property(sm => sm.Description).HasMaxLength(200);
        }
    }
}
