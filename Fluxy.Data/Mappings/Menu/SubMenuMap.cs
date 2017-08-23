using Fluxy.Core.Models.Menu;

namespace Fluxy.Data.Mappings.Menu
{
    public partial class SubMenuMap: FluxyEntityTypeConfiguration<SubMenu>
    {
        public SubMenuMap()
        {
            this.ToTable("SubMenu");
            this.HasKey(sm => sm.Id);
            this.Property(sm => sm.Name).IsRequired().HasMaxLength(200);
            this.Property(sm => sm.ShortName).HasMaxLength(200);
            this.Property(sm => sm.LinkText).IsRequired().HasMaxLength(200);
            this.Property(sm => sm.ActionName).IsRequired().HasMaxLength(200);
            this.Property(sm => sm.ControllerName).IsRequired().HasMaxLength(200);
            this.Property(sm => sm.MainMenuId).IsRequired();
            this.Property(sm => sm.MenuAttributeId).IsRequired();
        }
    }
}
