using Fluxy.Infrastructure;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Logging;
using Fluxy.Services.Menu;
using Fluxy.ViewModels.Menu;
using System.Collections.Generic;
using System;
using Fluxy.Core.Models.Menu;
using System.Data.Entity.Validation;

namespace Fluxy.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AttributesController : BaseController
    {
        private readonly IMenuAttributeService _menuAttributeService;
        private readonly IMapper _mapper;
        public AttributesController(ILogService logService, IMenuAttributeService menuAttributeService, IMapper mapper)
            : base(logService, mapper)
        {
            _menuAttributeService = menuAttributeService;
            _mapper = mapper;
        }

        // GET: Admin/Attribute
        public ActionResult Index()
        {
            try
            {
                var menuAttribute = _menuAttributeService.GetAll();
                var menuList = _mapper.Map<List<MenuAttributeViewModel>>(menuAttribute);
                return View(menuList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(MenuAttributeViewModel MenuAttributeViewModel)
        {
            try
            {
                var menuAttributeDto = _mapper.Map<MenuAttribute>(MenuAttributeViewModel);
                if (!string.IsNullOrEmpty(menuAttributeDto.Id))
                {
                    _menuAttributeService.Update(menuAttributeDto);
                }
                else
                {
                    _menuAttributeService.Create(menuAttributeDto);
                }
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult GetbyID(string id)
        {
            var menuAttributeDto = _menuAttributeService.GetSingle(i => i.Id == id);
            var menuAttribute = _mapper.Map<MenuAttributeViewModel>(menuAttributeDto);
            return Json(menuAttribute, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetList()
        {
            var menuAttributeDto = _menuAttributeService.GetAll();
            var menuAttributeList = _mapper.Map<List<MenuAttributeViewModel>>(menuAttributeDto);
            return Json(menuAttributeList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            try
            {
                bool status = false;
                var menuAttributeDto = _menuAttributeService.GetSingle(i => i.Id == id);
                if (menuAttributeDto != null)
                {
                    _menuAttributeService.Delete(menuAttributeDto);
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