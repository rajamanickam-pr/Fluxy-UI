using Fluxy.Data.ExtentedDTO;
using Fluxy.Repositories.Common;
using System.Data.Entity;

namespace Fluxy.Repositories.Video
{
    public class VideoAttributesRepository : GenericRepository<VideoAttributesExtend>, IVideoAttributesRepository
    {
        public VideoAttributesRepository(DbContext context) 
            : base(context)
        {
        }
    }
}
