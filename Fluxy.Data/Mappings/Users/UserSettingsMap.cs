using Fluxy.Core.Models.Users;

namespace Fluxy.Data.Mappings.Users
{
    public class UserSettingsMap:FluxyEntityTypeConfiguration<UserSettings>
    {
        public UserSettingsMap()
        {
            this.ToTable("UserSettings");
            this.HasKey(pm => pm.Id);
            this.Property(pm => pm.CanAnyoneSendVideo);
            this.Property(pm => pm.CanAnyoneSendMessage);
        }
    }
}
