using Fluxy.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
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
                var mainMenus = _languageService.GetAll();
                var menuList = _mapper.Map<List<LanguageViewModel>>(mainMenus);
                return View(menuList);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Create(LanguageViewModel LanguageViewModel)
        {
            try
            {
                var mainMenuDto = _mapper.Map<Language>(LanguageViewModel);
                if (!string.IsNullOrEmpty(mainMenuDto.Id))
                {
                    _languageService.Update(mainMenuDto);
                }
                else
                {
                    _languageService.Create(mainMenuDto);
                }
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult GetbyID(string id)
        {
            var mainMenuDto = _languageService.GetAll().FirstOrDefault(i => i.Id == id);
            var mainMenu = _mapper.Map<LanguageViewModel>(mainMenuDto);
            return Json(mainMenu, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetList()
        {
            var mainMenuDto = _languageService.GetAll();
            var mainMenuList = _mapper.Map<List<LanguageViewModel>>(mainMenuDto);
            return Json(mainMenuList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            try
            {
                bool status = false;
                var mainMenuDto = _languageService.GetAll().FirstOrDefault(i => i.Id == id);
                if (mainMenuDto != null)
                {
                    _languageService.Delete(mainMenuDto);
                    status = true;
                }
                return Json(status, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}