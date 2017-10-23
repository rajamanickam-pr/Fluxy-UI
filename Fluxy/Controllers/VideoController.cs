using System.Web.Mvc;
using System.Linq;
using AutoMapper;
using Fluxy.Infrastructure;
using Fluxy.Services.Logging;
using Fluxy.Services.Video;
using Fluxy.ViewModels.Video;
using System.Data.SqlClient;
using System;
using Fluxy.Core.Constants.Video;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        [Route("{videoId}/{title}", Name = VideoControllerRoutes.GetIndex)]
        public ActionResult Index(string videoId, string title)
        {
            if (string.IsNullOrEmpty(videoId)) throw new ArgumentNullException(nameof(videoId));
            SqlParameter[] sqlParam = {
                new SqlParameter("videoId",videoId)
            };
            const string query = "UPDATE VideoAttributes SET ViewCount+=1 WHERE Id=@videoId";
            _videoAttributesService.ExecuteNonQuery(query, sqlParam);

            var videoAttribute = _videoAttributesService.GetSingle(i => i.Id == videoId);
            var recentlyAdded = _videoAttributesService.GetAll().OrderByDescending(i => i.CreatedDate).Take(9);
            var popularVideo = _videoAttributesService.GetAll().OrderByDescending(i => i.ViewCount).Take(6);
            var userMayLike = _videoAttributesService
                .GetList(i => i.Tags.ToLower() == videoAttribute.Tags.ToLower())
                .OrderByDescending(i => i.ViewCount).Take(9);

            var videoAttributeVm = _mapper.Map<VideoAttributesViewModel>(videoAttribute);
            if (!string.Equals(title, videoAttributeVm.Slug))
                return RedirectToAction("Index", routeValues: new { videoId = videoId, title = videoAttributeVm.Slug });

            Fluxy.Core.Helpers.ImageHelpers.GetThumbnail(videoAttributeVm.Thumbunail, videoAttributeVm.Slug);
            var recentlyAddedVm = _mapper.Map<IEnumerable<VideoAttributesViewModel>>(recentlyAdded);
            var popularVideoVm = _mapper.Map<IEnumerable<VideoAttributesViewModel>>(popularVideo);
            var userMayLikeVm = _mapper.Map<IEnumerable<VideoAttributesViewModel>>(userMayLike);

            var showVideoViewModel = new ShowVideoViewModel
            {
                SelectedVideo = videoAttributeVm,
                PopularVideo = popularVideoVm,
                RecentlyAdded = recentlyAddedVm,
                UserMayLike = userMayLikeVm
            };

            return View(VideoControllerAction.Index, showVideoViewModel);
        }
    }
}