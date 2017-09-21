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
using System.Threading.Tasks;

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
        public async Task<ActionResult> Index()
        {
            var languages = await _languageService.GetAllAsync();
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
        public async Task<ActionResult> Create(LanguageViewModel LanguageViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var languageDto = _mapper.Map<Language>(LanguageViewModel);
                    if (!string.IsNullOrEmpty(languageDto.Id))
                    {
                       await _languageService.UpdateAsync(languageDto);
                    }
                    else
                    {
                       await _languageService.CreateAsync(languageDto);
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
        public async Task<ActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException("Language id is null  or empty");

            var languageDto =await _languageService.GetSingleAsync(i => i.Id == id);
            var language = _mapper.Map<LanguageViewModel>(languageDto);
            return View(LanguageControllerAction.Edit, language);
        }

        [HttpPost]
        [Route("Edit", Name = LanguageControllerRoute.PostEdit)]
        public async Task<ActionResult> Edit(LanguageViewModel LanguageViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var languageDto = _mapper.Map<Language>(LanguageViewModel);
                    if (!string.IsNullOrEmpty(languageDto.Id))
                    {
                       await _languageService.UpdateAsync(languageDto);
                    }
                    else
                    {
                       await _languageService.CreateAsync(languageDto);
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
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var languageDto = _languageService.GetSingle(i => i.Id == id);
                if (languageDto != null)
                {
                   await _languageService.DeleteAsync(languageDto);
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