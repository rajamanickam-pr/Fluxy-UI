using Fluxy.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Logging;
using Fluxy.Services.Video;
using Fluxy.ViewModels.Video;
using Fluxy.Data.ExtentedDTO;
using Microsoft.AspNet.Identity;
using System.Net;

namespace Fluxy.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class VideoAttributesController : BaseController
    {
        private readonly IVideoAttributesService _videoAttributesService;
        private readonly IMapper _mapper;

        public VideoAttributesController(ILogService logService, IVideoAttributesService videoAttributesService, IMapper mapper)
            : base(logService, mapper)
        {
            _videoAttributesService = videoAttributesService;
            _mapper = mapper;
        }

        // GET: Admin/VideoAttributes
        public ActionResult Index()
        {
            var videoSettings = _videoAttributesService.GetAll();
            var menuList = _mapper.Map<List<VideoAttributesViewModel>>(videoSettings);
            return View(menuList);
        }

        [HttpPost]
        public ActionResult Create(VideoAttributesViewModel videoSettingsViewModel)
        {
            if (ModelState.IsValid)
            {

                var videoSettingsDto = _mapper.Map<VideoAttributesExtend>(videoSettingsViewModel);
                if (!string.IsNullOrEmpty(videoSettingsDto.Id))
                {
                    videoSettingsDto.Thumbunail = GetYouTubeThumbnail(videoSettingsViewModel.VideoId);
                    videoSettingsDto.UserId = User.Identity.GetUserId();
                    _videoAttributesService.Update(videoSettingsDto);
                }
                else
                {
                    videoSettingsDto.Thumbunail = GetYouTubeThumbnail(videoSettingsViewModel.VideoId);
                    videoSettingsDto.UserId = User.Identity.GetUserId();
                    _videoAttributesService.Create(videoSettingsDto);
                }
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public byte[] GetYouTubeThumbnail(string videoId)
        {
            if (!string.IsNullOrWhiteSpace(videoId))
            {
                var url = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
                WebClient wc = new WebClient();
                byte[] originalData = wc.DownloadData(url);
                return originalData;
            }
            return null;
        }

        public JsonResult GetbyID(string id)
        {
            var videoSettingsDto = _videoAttributesService.GetAll().FirstOrDefault(i => i.Id == id);
            var videoSettings = _mapper.Map<VideoAttributesViewModel>(videoSettingsDto);
            return Json(videoSettings, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetList()
        {
            var videoSettingsDto = _videoAttributesService.GetAll();
            var videoSettingsList = _mapper.Map<List<VideoAttributesViewModel>>(videoSettingsDto);
            return Json(videoSettingsList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            bool status = false;
            var videoSettingsDto = _videoAttributesService.GetAll().FirstOrDefault(i => i.Id == id);
            if (videoSettingsDto != null)
            {
                _videoAttributesService.Delete(videoSettingsDto);
                status = true;
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }
    }
}