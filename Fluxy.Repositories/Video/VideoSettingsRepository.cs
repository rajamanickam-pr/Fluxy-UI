using Fluxy.Core.Models.Video;
using Fluxy.Repositories.Common;
using System.Data.Entity;

namespace Fluxy.Repositories.Video
{
    public class VideoSettingsRepository : GenericRepository<VideoSettings>, IVideoSettingsRepository
    {
        public VideoSettingsRepository(DbContext context) 
            : base(context)
        {
        }
    }
}
