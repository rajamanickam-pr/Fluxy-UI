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
using Fluxy.Core.Mvc.Security.Attributes;

namespace Fluxy.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
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
            try
            {
                var mainMenus = _mainMenuService.GetAll();
                var menuList = _mapper.Map<List<MainMenuViewModel>>(mainMenus);
                return View(menuList);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [JsonErrorHandler]
        public ActionResult Create(MainMenuViewModel mainMenuViewModel)
        {
            try
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
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public JsonResult GetbyID(int id)
        {
            var mainMenuDto = _mainMenuService.GetAll().FirstOrDefault(i => i.Id == id);
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
        public JsonResult Delete(int id)
        {
            try
            {
                bool status = false;
                var mainMenuDto = _mainMenuService.GetAll().FirstOrDefault(i => i.Id == id);
                if (mainMenuDto != null)
                {
                    _mainMenuService.Delete(mainMenuDto);
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