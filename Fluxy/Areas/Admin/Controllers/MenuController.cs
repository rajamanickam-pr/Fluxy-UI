using AutoMapper;
using Fluxy.Core.Models.Menu;
using Fluxy.Core.Mvc.Controllers;
using Fluxy.Services.Menu;
using Fluxy.ViewModels.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fluxy.Areas.Admin.Controllers
{
    [RoutePrefix("Menu")]
    //[Authorize(Roles ="Admin")]
    public class MenuController : BaseController
    {
        private readonly IMainMenuService _mainMenuService;
        private readonly IMapper _mapper;

        public MenuController(IMainMenuService mainMenuService, IMapper mapper)
        {
            _mainMenuService = mainMenuService;
            _mapper = mapper;
        }

        // GET: Admin/Menu
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetMainMenuItems()
        {
            var mainMenus = _mainMenuService.GetAll();
            var menuList = _mapper.Map<List<MainMenuViewModel>>(mainMenus);
            return Json(new { data = menuList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            var mainMenus = _mainMenuService.GetAll().FirstOrDefault(i => i.Id == id);
            var menu = _mapper.Map<MainMenuViewModel>(mainMenus);
            return PartialView(menu);
        }

        [HttpPost]
        public ActionResult Create(MainMenuViewModel mainMenuViewModel)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                var mainMenuDto = _mapper.Map<MainMenu>(mainMenuViewModel);
                if (mainMenuDto.Id > 0)
                {
                    _mainMenuService.Update(mainMenuDto);
                }
                else
                {
                    _mainMenuService.Create(mainMenuDto);
                }
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var mainMenus = _mainMenuService.GetAll().FirstOrDefault(i => i.Id == id);
            var menu = _mapper.Map<MainMenuViewModel>(mainMenus);
            return PartialView(menu);
        }

        [HttpPost]
        [ActionName("Delete")]
        public JsonResult DeleteMainMenu(MainMenuViewModel mainMenuViewModel)
        {
            bool status = false;
            var mainMenuDto = _mapper.Map<MainMenu>(mainMenuViewModel);
            if (mainMenuDto != null)
            {
                _mainMenuService.Delete(mainMenuDto);
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}