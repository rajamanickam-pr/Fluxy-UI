using AutoMapper;
using Fluxy.Core.Models.Menu;
using Fluxy.Services.Menu;
using Fluxy.ViewModels.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Fluxy.Infrastructure;
using Fluxy.Services.Logging;

namespace Fluxy.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MenuController : BaseController
    {
        private readonly IMainMenuService _mainMenuService;
        private readonly IMapper _mapper;

        public MenuController(IMainMenuService mainMenuService, ILogService logService, IMapper mapper)
            : base(logService, mapper)
        {
            _mainMenuService = mainMenuService;
            _mapper = mapper;
        }

        // GET: Admin/Menu
        public ActionResult Index()
        {
            try
            {
                var mainMenus = _mainMenuService.GetAll();
                var menuList = _mapper.Map<List<MainMenuViewModel>>(mainMenus);
                return View(menuList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(MainMenuViewModel mainMenuViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var mainMenuDto = _mapper.Map<MainMenu>(mainMenuViewModel);
                    if (!string.IsNullOrEmpty(mainMenuDto.Id))
                    {
                        _mainMenuService.Update(mainMenuDto);
                    }
                    else
                    {
                        _mainMenuService.Create(mainMenuDto);
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
            var mainMenuDto = _mainMenuService.GetSingle(i => i.Id == id);
            var mainMenu = _mapper.Map<MainMenuViewModel>(mainMenuDto);
            return Json(mainMenu, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetList()
        {
            var mainMenuDto = _mainMenuService.GetAll();
            var mainMenuList = _mapper.Map<List<MainMenuViewModel>>(mainMenuDto);
            return Json(mainMenuList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            try
            {
                bool status = false;
                var mainMenuDto = _mainMenuService.GetSingle(i => i.Id == id);
                if (mainMenuDto != null)
                {
                    _mainMenuService.Delete(mainMenuDto);
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