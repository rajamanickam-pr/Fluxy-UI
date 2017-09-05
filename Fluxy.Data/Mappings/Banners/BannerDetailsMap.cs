using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fluxy.Core.Models.Banners;

namespace Fluxy.Data.Mappings.Banners
{
    public class BannerDetailsMap : FluxyEntityTypeConfiguration<BannerDetails>
    {
        public BannerDetailsMap()
        {
            this.ToTable("BannerDetails");
            this.HasKey(sm => sm.Id);
            this.Property(sm => sm.Name).IsRequired().HasMaxLength(100);
            this.Property(sm => sm.Headline).HasMaxLength(100);
            this.Property(sm => sm.Slogans).HasMaxLength(200);
            this.Property(sm => sm.ButtonText).HasMaxLength(200);
            this.Property(sm => sm.Image);
        }
    }
}
