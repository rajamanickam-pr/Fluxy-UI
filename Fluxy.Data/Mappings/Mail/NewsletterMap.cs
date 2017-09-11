using Fluxy.Data.ExtentedDTO;

namespace Fluxy.Data.Mappings.Mail
{
    public class NewsletterMap : FluxyEntityTypeConfiguration<NewsletterExtend>
    {
        public NewsletterMap()
        {
            this.ToTable("Newsletter");
            this.HasKey(sm => sm.Id);
            this.HasOptional(pm => pm.ApplicationUser).WithMany().HasForeignKey(b => b.UserId);
            this.Property(sm => sm.Active);
        }
    }
}
