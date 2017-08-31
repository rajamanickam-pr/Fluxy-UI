using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fluxy.Data;
using Fluxy.ViewModels.User;

namespace Fluxy.Controllers
{
    public class UserProfileController : Controller
    {
        private FluxyContext db = new FluxyContext();

        // GET: UserProfile
        //public ActionResult Index()
        //{
        //    return View(db.UserMangementViewModels.ToList());
        //}

        //// GET: UserProfile/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    UserMangementViewModel userMangementViewModel = db.UserMangementViewModels.Find(id);
        //    if (userMangementViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(userMangementViewModel);
        //}

        //// GET: UserProfile/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: UserProfile/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,DisplayPicture,Firstname,Lastname,About,Hobbies,CanAnyoneSendMessage,CanAnyoneSendVideo")] UserMangementViewModel userMangementViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.UserMangementViewModels.Add(userMangementViewModel);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(userMangementViewModel);
        //}

        //// GET: UserProfile/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    UserMangementViewModel userMangementViewModel = db.UserMangementViewModels.Find(id);
        //    if (userMangementViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(userMangementViewModel);
        //}

        //// POST: UserProfile/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,DisplayPicture,Firstname,Lastname,About,Hobbies,CanAnyoneSendMessage,CanAnyoneSendVideo")] UserMangementViewModel userMangementViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(userMangementViewModel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(userMangementViewModel);
        //}

        //// GET: UserProfile/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    UserMangementViewModel userMangementViewModel = db.UserMangementViewModels.Find(id);
        //    if (userMangementViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(userMangementViewModel);
        //}

        //// POST: UserProfile/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    UserMangementViewModel userMangementViewModel = db.UserMangementViewModels.Find(id);
        //    db.UserMangementViewModels.Remove(userMangementViewModel);
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
