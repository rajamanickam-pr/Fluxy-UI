using Fluxy.Data.ExtentedDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxy.Data.Mappings.Users
{
    public class UserProfileMap : FluxyEntityTypeConfiguration<UserProfileExtend>
    {
        public UserProfileMap()
        {
            this.ToTable("UserProfile");
            this.HasKey(pm => pm.Id);
            this.Property(pm => pm.About).HasMaxLength(300);
            this.Property(pm => pm.Firstname).HasMaxLength(100);
            this.Property(pm => pm.Lastname).HasMaxLength(100);
            this.HasOptional(pm => pm.ApplicationUser).WithMany().HasForeignKey(b => b.UserId);
            this.HasOptional(pm => pm.UserSettings).WithMany().HasForeignKey(b => b.UserSettingsId);
        }
    }
}
