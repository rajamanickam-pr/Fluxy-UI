using Fluxy.Core.Models.Menu;

namespace Fluxy.Data.Mappings.Menu
{
    public partial class MenuAttributeMap : FluxyEntityTypeConfiguration<MenuAttribute>
    {
        public MenuAttributeMap()
        {
            this.ToTable("MenuAttribute");
            this.HasKey(ma => ma.Id);
            this.Property(ma => ma.AttributeKey).IsRequired().HasMaxLength(200);
            this.Property(ma => ma.AttributeValue).IsRequired().HasMaxLength(200);
        }
    }
}
