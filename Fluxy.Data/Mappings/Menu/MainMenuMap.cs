using Fluxy.Core.Models.Menu;

namespace Fluxy.Data.Mappings.Menu
{
    public partial class MainMenuMap: FluxyEntityTypeConfiguration<MainMenu>
    {
        public MainMenuMap()
        {
            this.ToTable("MainMenu");
            this.HasKey(sm => sm.Id);
            this.Property(sm => sm.Name).IsRequired().HasMaxLength(200);
            this.Property(sm => sm.ShortName).HasMaxLength(200);
            this.Property(sm => sm.LinkText).IsRequired().HasMaxLength(200);
            this.Property(sm => sm.ActionName).IsRequired().HasMaxLength(200);
            this.Property(sm => sm.ControllerName).IsRequired().HasMaxLength(200);
            this.Property(sm => sm.MenuAttributeId).IsRequired();
        }
    }
}
