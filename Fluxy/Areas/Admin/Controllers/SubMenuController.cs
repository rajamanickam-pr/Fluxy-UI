using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Fluxy.Data;
using Fluxy.ViewModels.Menu;
using Fluxy.Services.Menu;
using AutoMapper;
using Fluxy.Core.Models.Menu;
using Fluxy.Infrastructure;
using Fluxy.Services.Logging;

namespace Fluxy.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SubMenuController : BaseController
    {
        private FluxyContext db = new FluxyContext();

        private readonly ISubMenuService _subMenuService;
        private readonly IMapper _mapper;

        public SubMenuController(ILogService logService, ISubMenuService subMenuService, IMapper mapper)
            : base(logService, mapper)
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
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(SubMenuViewModel subMenuViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var subMenuDto = _mapper.Map<SubMenu>(subMenuViewModel);
                    if (!string.IsNullOrWhiteSpace(subMenuDto.Id))
                    {
                        _subMenuService.Update(subMenuDto);
                    }
                    else
                    {
                        _subMenuService.Create(subMenuDto);
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
            var subMenuDto = _subMenuService.GetSingle(i => i.Id == id);
            var subMenu = _mapper.Map<SubMenuViewModel>(subMenuDto);
            return Json(subMenu, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            try
            {
                bool status = false;
                var subMenuDto = _subMenuService.GetSingle(i => i.Id == id);
                if (subMenuDto != null)
                {
                    _subMenuService.Delete(subMenuDto);
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
