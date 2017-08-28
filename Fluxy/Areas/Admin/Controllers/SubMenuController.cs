using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fluxy.Data;
using Fluxy.ViewModels.Menu;
using Fluxy.Core.Mvc.Controllers;
using Fluxy.Services.Menu;
using AutoMapper;
using Fluxy.Core.Mvc.Security.Attributes;
using Fluxy.Core.Models.Menu;

namespace Fluxy.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SubMenuController : BaseController
    {
        private FluxyContext db = new FluxyContext();

        private readonly ISubMenuService _subMenuService;
        private readonly IMapper _mapper;

        public SubMenuController(ISubMenuService subMenuService, IMapper mapper)
        {
            _subMenuService = subMenuService;
            _mapper = mapper;
        }

        // GET: Admin/Menu
        public ActionResult Index()
        {
            try
            {
                var subMenus = _subMenuService.GetAll();
                var menuList = _mapper.Map<List<SubMenuViewModel>>(subMenus);
                return View(menuList);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [JsonErrorHandler]
        public ActionResult Create(SubMenuViewModel subMenuViewModel)
        {
            try
            {
                var subMenuDto = _mapper.Map<SubMenu>(subMenuViewModel);
                if (subMenuDto.Id > 0)
                {
                    _subMenuService.Update(subMenuDto);
                }
                else
                {
                    _subMenuService.Create(subMenuDto);
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
            var subMenuDto = _subMenuService.GetAll().FirstOrDefault(i => i.Id == id);
            var subMenu = _mapper.Map<SubMenuViewModel>(subMenuDto);
            return Json(subMenu, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                bool status = false;
                var subMenuDto = _subMenuService.GetAll().FirstOrDefault(i => i.Id == id);
                if (subMenuDto != null)
                {
                    _subMenuService.Delete(subMenuDto);
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
