using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Core.Models.Banners;
using Fluxy.Infrastructure;
using Fluxy.Services.Banners;
using Fluxy.Services.Logging;
using Fluxy.ViewModels.Banners;
using Fluxy.ViewModels.Menu;

namespace Fluxy.Areas.Admin.Controllers
{
    public class BannerController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IBannerDetailsService _bannerDetailsService;

        public BannerController(ILogService logService, IMapper mapper, IBannerDetailsService bannerDetailsService)
            : base(logService, mapper)
        {
            _mapper = mapper;
            _bannerDetailsService = bannerDetailsService;
        }

        // GET: Admin/Banner
        public ActionResult Index()
        {
            var bannerDto = _bannerDetailsService.GetAll();
            var banner = _mapper.Map<List<BannerDetailsViewModel>>(bannerDto);
            return View(banner);
        }

        [HttpPost]
        public ActionResult Create(BannerDetailsViewModel bannerDetailsViewModel)
        {
            if (ModelState.IsValid)
            {
                var bannerDto = _mapper.Map<BannerDetails>(bannerDetailsViewModel);

                if (bannerDetailsViewModel.fileBase != null)
                {
                    if (bannerDetailsViewModel.fileBase.ContentLength > 0)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bannerDetailsViewModel.fileBase.InputStream.CopyTo(ms);
                            byte[] fileArray = ms.GetBuffer();
                            bannerDto.Image = fileArray;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(bannerDto.Id))
                {
                    var oldPicture = _bannerDetailsService.GetSingle(i => i.Id == bannerDto.Id).Image;
                    if (oldPicture.Length > 0 && bannerDto.Image.Length <= 0)
                    {
                        bannerDto.Image = oldPicture;
                    }
                    _bannerDetailsService.Update(bannerDto);
                }
                else
                {
                    _bannerDetailsService.Create(bannerDto);
                }
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetbyId(string id)
        {
            var bannerDto = _bannerDetailsService.GetAll().FirstOrDefault(i => i.Id == id);
            var mainMenu = _mapper.Map<MainMenuViewModel>(bannerDto);
            return Json(mainMenu, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetList()
        {
            var bannerDto = _bannerDetailsService.GetAll();
            var mainMenuList = _mapper.Map<List<MainMenuViewModel>>(bannerDto);
            return Json(mainMenuList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            bool status = false;
            var bannerDto = _bannerDetailsService.GetAll().FirstOrDefault(i => i.Id == id);
            if (bannerDto != null)
            {
                _bannerDetailsService.Delete(bannerDto);
                status = true;
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }
    }
}
