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
using System.Text.RegularExpressions;
using System.Collections.Generic;

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
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException("videoId is null or empty");
            SqlParameter[] sqlParam = {
                new SqlParameter("videoId",videoId)
            };
            var query = "UPDATE VideoAttributes SET ViewCount+=1 WHERE Id=@videoId";
            _videoAttributesService.ExecuteNonQuery(query, sqlParam);

            var videoAttribute = _videoAttributesService.GetSingle(i => i.Id == videoId);
            var recentlyAdded = _videoAttributesService.GetAll().Take(9).OrderByDescending(i => i.CreatedDate);
            var popularVideo = _videoAttributesService.GetAll().Take(6).OrderBy(i => i.ViewCount);
            var userMayLike = _videoAttributesService.GetAll().Take(9).OrderBy(i => i.Tags == videoAttribute.Tags);
            var videoAttributeVM = _mapper.Map<VideoAttributesViewModel>(videoAttribute);
            var recentlyAddedVM = _mapper.Map<IEnumerable<VideoAttributesViewModel>>(recentlyAdded);
            var popularVideoVM = _mapper.Map<IEnumerable<VideoAttributesViewModel>>(popularVideo);
            var userMayLikeVM = _mapper.Map<IEnumerable<VideoAttributesViewModel>>(userMayLike);

            var showVideoViewModel = new ShowVideoViewModel
            {
                SelectedVideo = videoAttributeVM,
                PopularVideo = popularVideoVM,
                RecentlyAdded = recentlyAddedVM,
                UserMayLike = userMayLikeVM
            };

            return View(VideoControllerAction.Index, showVideoViewModel);
        }
    }
}