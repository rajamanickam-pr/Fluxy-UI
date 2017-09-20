using Fluxy.Infrastructure;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Logging;
using Fluxy.Services.Video;
using Fluxy.ViewModels.Video;
using Fluxy.Core.Models.Video;
using Fluxy.Core.Constants.VideoSettings;

namespace Fluxy.Controllers.Administration
{
    [RoutePrefix("videosettings")]
    [Authorize(Roles = "Admin")]
    public class VideoSettingsController : BaseController
    {
        private readonly IVideoSettingsService _videoSettingsService;
        private readonly IMapper _mapper;

        public VideoSettingsController(ILogService logService, IVideoSettingsService videSettingsService, IMapper mapper)
            : base(logService, mapper)
        {
            _videoSettingsService = videSettingsService;
            _mapper = mapper;
        }


        // GET: Admin/Menu
        [HttpGet]
        [Route("", Name = VideoSettingsControllerRoutes.GetIndex)]
        public ActionResult Index()
        {
            var videoSettings = _videoSettingsService.GetAll();
            var menuList = _mapper.Map<List<VideoSettingsViewModel>>(videoSettings);
            return View(VideoSettingsControllerAction.Index, menuList);
        }

        [HttpGet]
        [Route("Create", Name = VideoSettingsControllerRoutes.GetCreate)]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create", Name = VideoSettingsControllerRoutes.PostCreate)]
        public ActionResult Create(VideoSettingsViewModel videoSettingsViewModel)
        {
            if (ModelState.IsValid)
            {
                var videoSettingsDto = _mapper.Map<VideoSettings>(videoSettingsViewModel);
                if (!string.IsNullOrEmpty(videoSettingsDto.Id))
                {
                    _videoSettingsService.Update(videoSettingsDto);
                }
                else
                {
                    _videoSettingsService.Create(videoSettingsDto);
                }
                return RedirectToAction(VideoSettingsControllerAction.Index);
            }
            return View();
        }


        [HttpGet]
        [Route("Edit", Name = VideoSettingsControllerRoutes.GetEdit)]
        public ActionResult Edit(string id)
        {
            var videoSettingsDto = _videoSettingsService.GetSingle(i => i.Id == id);
            var videoSettings = _mapper.Map<VideoSettingsViewModel>(videoSettingsDto);
            return View(videoSettings);
        }

        [HttpPost]
        [Route("Edit", Name = VideoSettingsControllerRoutes.PostEdit)]
        public ActionResult Edit(VideoSettingsViewModel videoSettingsViewModel)
        {
            if (ModelState.IsValid)
            {
                var videoSettingsDto = _mapper.Map<VideoSettings>(videoSettingsViewModel);
                if (!string.IsNullOrEmpty(videoSettingsDto.Id))
                {
                    _videoSettingsService.Update(videoSettingsDto);
                }
                else
                {
                    _videoSettingsService.Create(videoSettingsDto);
                }
                return RedirectToAction(VideoSettingsControllerAction.Index);
            }
            return View();
        }

        [HttpGet]
        [Route("Delete", Name = VideoSettingsControllerRoutes.GetDelete)]
        public ActionResult Delete(string id)
        {
            var videoSettingsDto = _videoSettingsService.GetSingle(i => i.Id == id);
            if (videoSettingsDto != null)
            {
                _videoSettingsService.Delete(videoSettingsDto);
            }
            return RedirectToAction(VideoSettingsControllerAction.Index);
        }
    }
}