using System.Web.Mvc;
using AutoMapper;
using Fluxy.Infrastructure;
using Fluxy.Services.Logging;
using Fluxy.Services.Video;
using Fluxy.ViewModels.Video;
using System.Data.SqlClient;
using System;

namespace Fluxy.Controllers
{
    [RoutePrefix("video")]
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
        [HttpGet]
        public ActionResult Index(string videoId)
        {
            if(string.IsNullOrEmpty(videoId))
                 throw new ArgumentNullException("videoId is null or empty");

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