using Fluxy.Data.ExtentedDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxy.Data.Mappings.Messages
{
   public class PrivateMessagesMap : FluxyEntityTypeConfiguration<PrivateMessagesExtend>
    {
        public PrivateMessagesMap()
        {
            this.ToTable("PrivateMessages");
            this.HasKey  (pm => pm.Id);
            this.Property(pm => pm.Subject).IsRequired().HasMaxLength(200);
            this.Property(pm => pm.Text).HasMaxLength(500).IsRequired();
            this.Property(pm => pm.IsDeletedByAuthor);
            this.Property(pm => pm.IsDeletedByRecipient);
            this.Property(pm => pm.IsRead);
        }
    }
}
