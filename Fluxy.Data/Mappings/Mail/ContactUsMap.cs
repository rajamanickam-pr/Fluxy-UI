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
