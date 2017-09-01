using Fluxy.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Logging;
using Fluxy.Services.Video;
using Fluxy.ViewModels.Video;
using Fluxy.Core.Models.Video;

namespace Fluxy.Areas.Admin.Controllers
{
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
        public ActionResult Index()
        {
            try
            {
                var videoSettings = _videoSettingsService.GetAll();
                var menuList = _mapper.Map<List<VideoSettingsViewModel>>(videoSettings);
                return View(menuList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(VideoSettingsViewModel videoSettingsViewModel)
        {
            try
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
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult GetbyID(string id)
        {
            var videoSettingsDto = _videoSettingsService.GetAll().FirstOrDefault(i => i.Id == id);
            var videoSettings = _mapper.Map<VideoSettingsViewModel>(videoSettingsDto);
            return Json(videoSettings, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetList()
        {
            var videoSettingsDto = _videoSettingsService.GetAll();
            var videoSettingsList = _mapper.Map<List<VideoSettingsViewModel>>(videoSettingsDto);
            return Json(videoSettingsList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            try
            {
                bool status = false;
                var videoSettingsDto = _videoSettingsService.GetAll().FirstOrDefault(i => i.Id == id);
                if (videoSettingsDto != null)
                {
                    _videoSettingsService.Delete(videoSettingsDto);
                    status = true;
                }
                return Json(status, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}