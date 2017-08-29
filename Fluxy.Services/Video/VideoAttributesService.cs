using Fluxy.Data.ExtentedDTO;
using Fluxy.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
