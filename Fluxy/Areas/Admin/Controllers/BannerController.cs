using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Core.Models.Banners;
using Fluxy.Infrastructure;
using Fluxy.Services.Banners;
using Fluxy.Services.Logging;
using Fluxy.ViewModels.Banners;
using System.Web;
using System;

namespace Fluxy.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
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
        public ActionResult Create(BannerDetailsViewModel bannerDetailsViewModel, HttpPostedFileBase fileBase)
        {
            if (ModelState.IsValid)
            {
                if (fileBase != null)
                {
                    if (fileBase.ContentLength > 0)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            fileBase.InputStream.CopyTo(ms);
                            byte[] fileArray = ms.GetBuffer();
                            bannerDetailsViewModel.Image = fileArray;
                        }
                    }
                }
                var bannerDto = _mapper.Map<BannerDetails>(bannerDetailsViewModel);
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

        [HttpGet]
        public JsonResult GetbyId(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException("Banner id is null  or empty");

            var bannerDto = _bannerDetailsService.GetSingle(i => i.Id == id);
            var banner = _mapper.Map<BannerDetailsViewModel>(bannerDto);
            var jsonResult= Json(banner, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpGet]
        public JsonResult GetList()
        {
            var bannerDto = _bannerDetailsService.GetAll();
            var bannerList = _mapper.Map<List<BannerDetailsViewModel>>(bannerDto);
            return Json(bannerList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            bool status = false;
            var bannerDto = _bannerDetailsService.GetSingle(i => i.Id == id);
            if (bannerDto != null)
            {
                _bannerDetailsService.Delete(bannerDto);
                status = true;
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }
    }
}
