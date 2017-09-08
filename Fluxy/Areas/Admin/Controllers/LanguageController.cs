using Fluxy.Infrastructure;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Logging;
using Fluxy.Services.Localization;
using Fluxy.ViewModels.Localization;
using Fluxy.Core.Models.Localization;

namespace Fluxy.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LanguageController : BaseController
    {
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;
        public LanguageController(ILogService logService, ILanguageService languageService,IMapper mapper) 
            : base(logService, mapper)
        {
            _mapper = mapper;
            _languageService = languageService;
        }


        // GET: Admin/Menu
        public ActionResult Index()
        {
            try
            {
                var languages = _languageService.GetAll();
                var menuList = _mapper.Map<List<LanguageViewModel>>(languages);
                return View(menuList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(LanguageViewModel LanguageViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var languageDto = _mapper.Map<Language>(LanguageViewModel);
                    if (!string.IsNullOrEmpty(languageDto.Id))
                    {
                        _languageService.Update(languageDto);
                    }
                    else
                    {
                        _languageService.Create(languageDto);
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
            var languageDto = _languageService.GetSingle(i => i.Id == id);
            var language = _mapper.Map<LanguageViewModel>(languageDto);
            return Json(language, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetList()
        {
            var languageDto = _languageService.GetAll();
            var languageList = _mapper.Map<List<LanguageViewModel>>(languageDto);
            return Json(languageList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            try
            {
                bool status = false;
                var languageDto = _languageService.GetSingle(i => i.Id == id);
                if (languageDto != null)
                {
                    _languageService.Delete(languageDto);
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