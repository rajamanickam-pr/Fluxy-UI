using Fluxy.Infrastructure;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Logging;
using Fluxy.Services.Categories;
using Fluxy.ViewModels.Categories;
using System;
using System.Linq;
using System.Collections.Generic;
using Fluxy.Core.Models.Categories;

namespace Fluxy.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ILogService logService, ICategoryService categoryService, IMapper mapper)
            : base(logService, mapper)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            try
            {
                var category = _categoryService.GetAll();
                var menuList = _mapper.Map<List<CategoryViewModel>>(category);
                return View(menuList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(CategoryViewModel CategoryViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var categoryDto = _mapper.Map<Category>(CategoryViewModel);
                    if (!string.IsNullOrEmpty(categoryDto.Id))
                    {
                        _categoryService.Update(categoryDto);
                    }
                    else
                    {
                        _categoryService.Create(categoryDto);
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
            var categoryDto = _categoryService.GetSingle(i => i.Id == id);
            var category = _mapper.Map<CategoryViewModel>(categoryDto);
            return Json(category, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetList()
        {
            var categoryDto = _categoryService.GetAll().OrderBy(i=>i.Name);
            var categoryList = _mapper.Map<List<CategoryViewModel>>(categoryDto);
            return Json(categoryList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            try
            {
                bool status = false;
                var categoryDto = _categoryService.GetSingle(i => i.Id == id);
                if (categoryDto != null)
                {
                    _categoryService.Delete(categoryDto);
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