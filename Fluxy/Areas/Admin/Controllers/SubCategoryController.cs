using Fluxy.Infrastructure;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Logging;
using Fluxy.Services.Categories;
using Fluxy.ViewModels.Categories;
using System.Collections.Generic;
using System;
using System.Linq;
using Fluxy.Core.Models.Categories;

namespace Fluxy.Areas.Admin.Controllers
{
    public class SubCategoryController : BaseController
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly IMapper _mapper;
        public SubCategoryController(ILogService logService, ISubCategoryService subCategoryService, IMapper mapper)
            : base(logService, mapper)
        {
            _mapper = mapper;
            _subCategoryService = subCategoryService;
        }

        public ActionResult Index()
        {
            try
            {
                var subCategory = _subCategoryService.GetAll();
                var menuList = _mapper.Map<List<SubCategoryViewModel>>(subCategory);
                return View(menuList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(SubCategoryViewModel SubCategoryViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var subCategoryDto = _mapper.Map<SubCategory>(SubCategoryViewModel);
                    if (!string.IsNullOrEmpty(subCategoryDto.Id))
                    {
                        _subCategoryService.Update(subCategoryDto);
                    }
                    else
                    {
                        _subCategoryService.Create(subCategoryDto);
                    }
                    return Json(true, JsonRequestBehavior.AllowGet);
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
            var subCategoryDto = _subCategoryService.GetSingle(i => i.Id == id);
            var subCategory = _mapper.Map<SubCategoryViewModel>(subCategoryDto);
            return Json(subCategory, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetList()
        {
            var subCategoryDto = _subCategoryService.GetAll();
            var subCategoryList = _mapper.Map<List<SubCategoryViewModel>>(subCategoryDto);
            return Json(subCategoryList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            try
            {
                bool status = false;
                var subCategoryDto = _subCategoryService.GetSingle(i => i.Id == id);
                if (subCategoryDto != null)
                {
                    _subCategoryService.Delete(subCategoryDto);
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