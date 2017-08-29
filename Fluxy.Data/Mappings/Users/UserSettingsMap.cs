using Fluxy.Core.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
