using Fluxy.Core.Models.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxy.Data.Mappings.Video
{
    public class VideoSettingsMap:FluxyEntityTypeConfiguration<VideoSettings>
    {
        public VideoSettingsMap()
        {
            this.ToTable("VideoSettings");
            this.HasKey(pm => pm.Id);
            this.Property(pm => pm.FrameFilters).HasMaxLength(200);
        }
    }
}
