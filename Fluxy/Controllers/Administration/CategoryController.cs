using Fluxy.Infrastructure;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Logging;
using Fluxy.Services.Categories;
using Fluxy.ViewModels.Categories;
using System.Collections.Generic;
using Fluxy.Core.Models.Categories;
using System.Threading.Tasks;
using System.Net;
using Fluxy.Core.Constants.Category;

namespace Fluxy.Controllers.Administration
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("category")]
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

        // GET: Category
        [HttpGet]
        [Route("", Name = CategoryControllerRoutes.GetIndex)]
        public async Task<ActionResult> Index()
        {
            var category = await _categoryService.GetAllAsync();
            var categoryList = _mapper.Map<List<CategoryViewModel>>(category);
            return View(CategoryControllerAction.Index, categoryList);
        }

        [HttpGet]
        [Route("Create", Name = CategoryControllerRoutes.GetCreate)]
        public ActionResult Create()
        {
            return View(CategoryControllerAction.Create);
        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create", Name = CategoryControllerRoutes.PostCreate)]
        public async Task<ActionResult> Create(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var categoryDto = _mapper.Map<Category>(categoryViewModel);
                await _categoryService.CreateAsync(categoryDto);
                return RedirectToAction(CategoryControllerAction.Index);
            }

            return View(CategoryControllerAction.Create,categoryViewModel);
        }

        [HttpGet]
        [Route("Edit", Name = CategoryControllerRoutes.GetEdit)]
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var categoryDto = await _categoryService.GetSingleAsync(i => i.Id == id);
            var categoryViewModel = _mapper.Map<CategoryViewModel>(categoryDto);
            if (categoryViewModel == null)
            {
                return HttpNotFound();
            }
            return View(CategoryControllerAction.Edit,categoryViewModel);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit", Name = CategoryControllerRoutes.PostEdit)]
        public async Task<ActionResult> Edit(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var categoryDto = _mapper.Map<Category>(categoryViewModel);
                await _categoryService.UpdateAsync(categoryDto);
                return RedirectToAction(CategoryControllerAction.Index);
            }
            return View(CategoryControllerAction.Edit,categoryViewModel);
        }

        // GET: Category/Delete/5
        [HttpGet]
        [Route("Delete", Name = CategoryControllerRoutes.GetDelete)]
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var categoryDto = await _categoryService.GetSingleAsync(i => i.Id == id);
            var categoryViewModel = _mapper.Map<CategoryViewModel>(categoryDto);
            if (categoryViewModel == null)
            {
                return HttpNotFound();
            }
            await _categoryService.DeleteAsync(categoryDto);
            return RedirectToAction(CategoryControllerAction.Index);
        }
    }
}
