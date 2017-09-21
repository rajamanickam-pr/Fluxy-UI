using AutoMapper;
using Fluxy.Core.Constants.Banner;
using Fluxy.Core.Models.Banners;
using Fluxy.Infrastructure;
using Fluxy.Services.Banners;
using Fluxy.Services.Logging;
using Fluxy.ViewModels.Banners;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Fluxy.Controllers.Administration
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("banner")]
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
        // GET: Banner
        [HttpGet]
        [Route("", Name = BannerControllerRoutes.GetIndex)]
        public async Task<ActionResult> Index()
        {
            var bannerDto = await _bannerDetailsService.GetAllAsync();
            var banner = _mapper.Map<List<BannerDetailsViewModel>>(bannerDto);
            return View(BannerControllerAction.Index, banner);
        }

        [HttpGet]
        [Route("Create", Name = BannerControllerRoutes.GetCreate)]
        public ActionResult Create()
        {
            return View(BannerControllerAction.Create);
        }

        // POST: Banner/Create
        [HttpPost]
        [Route("Create", Name = BannerControllerRoutes.PostCreate)]
        public async Task<ActionResult> Create(BannerDetailsViewModel bannerDetailsViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (bannerDetailsViewModel.File != null)
                    {
                        if (bannerDetailsViewModel.File.ContentLength > 0)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bannerDetailsViewModel.File.InputStream.CopyTo(ms);
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
                        await _bannerDetailsService.UpdateAsync(bannerDto);
                    }
                    else
                    {
                        await _bannerDetailsService.CreateAsync(bannerDto);
                    }
                    return RedirectToAction(BannerControllerAction.Index);
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Banner/Edit/5
        [HttpGet]
        [Route("Edit", Name = BannerControllerRoutes.GetEdit)]
        public async Task<ActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException("Banner id is null  or empty");

            var bannerDto = await _bannerDetailsService.GetSingleAsync(i => i.Id == id);
            var banner = _mapper.Map<BannerDetailsViewModel>(bannerDto);
            return View(BannerControllerAction.Edit, banner);
        }

        // POST: Banner/Edit/5
        [HttpPost]
        [Route("Edit", Name = BannerControllerRoutes.PostEdit)]
        public async Task<ActionResult> Edit(BannerDetailsViewModel bannerDetailsViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (bannerDetailsViewModel.File != null)
                    {
                        if (bannerDetailsViewModel.File.ContentLength > 0)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bannerDetailsViewModel.File.InputStream.CopyTo(ms);
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
                        await _bannerDetailsService.UpdateAsync(bannerDto);
                    }
                    else
                    {
                        await _bannerDetailsService.CreateAsync(bannerDto);
                    }
                    return RedirectToAction(BannerControllerAction.Index);
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // POST: Banner/Delete/5
        [HttpGet]
        [Route("Delete", Name = BannerControllerRoutes.GetDelete)]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var bannerDto =await _bannerDetailsService.GetSingleAsync(i => i.Id == id);
                if (bannerDto != null)
                {
                  await  _bannerDetailsService.DeleteAsync(bannerDto);
                }
                return RedirectToAction(BannerControllerAction.Index);
            }
            catch
            {
                return View();
            }
        }
    }
}
