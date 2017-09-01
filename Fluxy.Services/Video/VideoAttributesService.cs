using Fluxy.Data.ExtentedDTO;
using Fluxy.Services.Common;
using Fluxy.Repositories.Common;

namespace Fluxy.Services.Video
{
    public class VideoAttributesService : EntityService<VideoAttributesExtend>, IVideoAttributesService
    {
        public VideoAttributesService(IUnitOfWork unitOfWork, IGenericRepository<VideoAttributesExtend> repository)
            : base(unitOfWork, repository)
        {
        }
    }
}
