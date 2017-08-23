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
using Fluxy.Services.Menu;
using AutoMapper;

namespace Fluxy.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMainMenuService _mainMenuService;
        private readonly IMapper _mapper;

        public MenuController(IMainMenuService mainMenuService, IMapper mapper)
        {
            _mainMenuService = mainMenuService;
            _mapper = mapper;
        }

        // GET: Menu
        public ActionResult Index()
        {
            var mainMenus = _mainMenuService.GetAll();
            var value = _mapper.Map<List<MainMenuViewModel>>(mainMenus);
            return View(value);
        }

        //// GET: Menu/Details/5
        //public ActionResult Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MainMenuViewModel mainMenuViewModel = db.MainMenuViewModels.Find(id);
        //    if (mainMenuViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(mainMenuViewModel);
        //}

        // GET: Menu/Create
        public ActionResult Create()
        {
            return View();
        }

        //// POST: Menu/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,MenuAttributeId,Name,ShortName,LinkText,ActionName,ControllerName,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy")] MainMenuViewModel mainMenuViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.MainMenuViewModels.Add(mainMenuViewModel);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(mainMenuViewModel);
        //}

        //// GET: Menu/Edit/5
        //public ActionResult Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MainMenuViewModel mainMenuViewModel = db.MainMenuViewModels.Find(id);
        //    if (mainMenuViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(mainMenuViewModel);
        //}

        //// POST: Menu/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,MenuAttributeId,Name,ShortName,LinkText,ActionName,ControllerName,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy")] MainMenuViewModel mainMenuViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(mainMenuViewModel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(mainMenuViewModel);
        //}

        //// GET: Menu/Delete/5
        //public ActionResult Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MainMenuViewModel mainMenuViewModel = db.MainMenuViewModels.Find(id);
        //    if (mainMenuViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(mainMenuViewModel);
        //}

        //// POST: Menu/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(long id)
        //{
        //    MainMenuViewModel mainMenuViewModel = db.MainMenuViewModels.Find(id);
        //    db.MainMenuViewModels.Remove(mainMenuViewModel);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
