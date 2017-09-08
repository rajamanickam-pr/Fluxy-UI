using System.Web.Mvc;
using AutoMapper;
using Fluxy.Infrastructure;
using Fluxy.Services.Logging;
using Fluxy.Services.Video;
using Fluxy.ViewModels.Video;
using System.Data.SqlClient;

namespace Fluxy.Controllers
{
    public class VideoController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IVideoAttributesService _videoAttributesService;

        public VideoController(ILogService logService, IMapper mapper, IVideoAttributesService videoAttributesService)
            : base(logService, mapper)
        {
            _mapper = mapper;
            _videoAttributesService = videoAttributesService;
        }

        // GET: Video
        public ActionResult Index(string videoId)
        {
            SqlParameter[] sqlParam = {
                new SqlParameter("videoId",videoId)
            };
            var query = "UPDATE VideoAttributes SET ViewCount+=1 WHERE Id=@videoId";
            _videoAttributesService.ExecuteNonQuery(query, sqlParam);

            var videoAttribute = _videoAttributesService.GetSingle(i => i.Id == videoId);
            var videoAttributeVM = _mapper.Map<VideoAttributesViewModel>(videoAttribute);
            return View(videoAttributeVM);
        }
    }
}