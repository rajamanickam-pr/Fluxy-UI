using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fluxy.Core.Models.Mail;

namespace Fluxy.Data.Mappings.Mail
{
    public class NewsletterMap : FluxyEntityTypeConfiguration<Newsletter>
    {
        public NewsletterMap()
        {
            this.ToTable("Newsletter");
            this.HasKey(sm => sm.Id);
            this.Property(sm => sm.Email).IsRequired();
            this.Property(sm => sm.Active);
        }
    }
}
