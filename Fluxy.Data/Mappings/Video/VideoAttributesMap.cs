using Fluxy.Data.ExtentedDTO;

namespace Fluxy.Data.Mappings.Video
{
    public class VideoAttributesMap : FluxyEntityTypeConfiguration<VideoAttributesExtend>
    {
        public VideoAttributesMap()
        {
            this.ToTable("VideoAttributes");
            this.HasKey(pm => pm.Id);
            this.Property(pm => pm.Description).HasMaxLength(500);
            this.Property(pm => pm.Title).HasMaxLength(200);
            this.Property(pm => pm.ShortName).HasMaxLength(100);
            this.Property(pm => pm.Tags).HasMaxLength(100);
            this.HasOptional(pm => pm.ApplicationUser).WithMany().HasForeignKey(b => b.UserId);
        }
    }
}
