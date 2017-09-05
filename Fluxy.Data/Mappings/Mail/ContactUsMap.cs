using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fluxy.Core.Models.Mail;

namespace Fluxy.Data.Mappings.Mail
{
    public class ContactUsMap : FluxyEntityTypeConfiguration<ContactUs>
    {
        public ContactUsMap()
        {
            this.ToTable("ContactUs");
            this.HasKey(sm => sm.Id);
            this.Property(sm => sm.Email).IsRequired();
            this.Property(sm => sm.Message);
        }
    }
}
