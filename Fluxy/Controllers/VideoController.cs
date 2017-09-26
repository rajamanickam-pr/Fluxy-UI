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
        public async Task<ActionResult> Index(string videoId, string title)
        {
            if (string.IsNullOrEmpty(title)) throw new ArgumentNullException(nameof(title));
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(videoId));
            SqlParameter[] sqlParam = {
                new SqlParameter("videoId",videoId)
            };
            const string query = "UPDATE VideoAttributes SET ViewCount+=1 WHERE Id=@videoId";
            _videoAttributesService.ExecuteNonQuery(query, sqlParam);

            var videoAttribute = _videoAttributesService.GetSingle(i => i.Id == videoId);
            var recentlyAdded = await _videoAttributesService.GetAllAsync();
            var popularVideo = await _videoAttributesService.GetAllAsync();
            var userMayLike = await _videoAttributesService.GetAllAsync();
            var videoAttributeVm = _mapper.Map<VideoAttributesViewModel>(videoAttribute);
            Fluxy.Core.Helpers.ImageHelpers.GetThumbnail(videoAttributeVm.Thumbunail, videoAttributeVm.Slug);
            var recentlyAddedVm = _mapper.Map<IEnumerable<VideoAttributesViewModel>>(recentlyAdded.Take(9).OrderByDescending(i => i.CreatedDate));
            var popularVideoVm = _mapper.Map<IEnumerable<VideoAttributesViewModel>>(popularVideo.Take(6).OrderBy(i => i.ViewCount));
            var userMayLikeVm = _mapper.Map<IEnumerable<VideoAttributesViewModel>>(userMayLike.Where(i => i.Tags == videoAttribute.Tags).Take(9).OrderBy(i => i.ViewCount));

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