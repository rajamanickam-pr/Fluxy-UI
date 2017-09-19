using Fluxy.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Logging;
using Fluxy.ViewModels.Localization;
using Fluxy.Services.Localization;
using Fluxy.Core.Models.Localization;
using Fluxy.Core.Constants.Language;

namespace Fluxy.Controllers.Administration
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("language")]
    public class LanguageController : BaseController
    {
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;
        public LanguageController(ILogService logService, ILanguageService languageService, IMapper mapper)
            : base(logService, mapper)
        {
            _mapper = mapper;
            _languageService = languageService;
        }

        [HttpGet]
        [Route("", Name = LanguageControllerRoute.GetIndex)]
        public ActionResult Index()
        {
            var languages = _languageService.GetAll();
            var menuList = _mapper.Map<List<LanguageViewModel>>(languages);
            return View(LanguageControllerAction.Index,menuList);
        }

        [HttpGet]
        [Route("Create", Name = LanguageControllerRoute.GetCreate)]
        public ActionResult Create()
        {
            return View(LanguageControllerAction.Create);
        }

        [HttpPost]
        [Route("Create", Name = LanguageControllerRoute.PostCreate)]
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
                    return RedirectToAction(LanguageControllerAction.Index);
                }
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        [Route("Edit", Name = LanguageControllerRoute.GetEdit)]
        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException("Language id is null  or empty");

            var languageDto = _languageService.GetSingle(i => i.Id == id);
            var language = _mapper.Map<LanguageViewModel>(languageDto);
            return View(LanguageControllerAction.Edit, language);
        }

        [HttpPost]
        [Route("Edit", Name = LanguageControllerRoute.PostEdit)]
        public ActionResult Edit(LanguageViewModel LanguageViewModel)
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
                    return RedirectToAction(LanguageControllerAction.Index);
                }
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("Delete", Name = LanguageControllerRoute.GetDelete)]
        public ActionResult Delete(string id)
        {
            try
            {
                var languageDto = _languageService.GetSingle(i => i.Id == id);
                if (languageDto != null)
                {
                    _languageService.Delete(languageDto);
                }
                return RedirectToAction(LanguageControllerAction.Index);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}