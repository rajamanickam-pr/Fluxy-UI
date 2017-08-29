using Fluxy.Core.Models.Video;
using Fluxy.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fluxy.Repositories.Common;

namespace Fluxy.Services.Video
{
    public class VideoSettingsService : EntityService<VideoSettings>, IVideoSettingsService
    {
        public VideoSettingsService(IUnitOfWork unitOfWork, IGenericRepository<VideoSettings> repository)
            : base(unitOfWork, repository)
        {
        }
    }
}
