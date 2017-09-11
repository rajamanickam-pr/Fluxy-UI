using Fluxy.Data.ExtentedDTO;

namespace Fluxy.Data.Mappings.Users
{
    public class UserSettingsMap:FluxyEntityTypeConfiguration<UserSettingsExtend>
    {
        public UserSettingsMap()
        {
            this.ToTable("UserSettings");
            this.HasKey(pm => pm.Id);
            this.Property(pm => pm.CanISeeEPContent);
            this.HasOptional(pm => pm.ApplicationUser).WithMany().HasForeignKey(b => b.UserId);
        }
    }
}
