using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Silverton.Models;

namespace Silverton.Controllers
{
    public class NotificationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Notifications
        public ActionResult Index()
        {
            return View(db.NotificationsViewModels.ToList());
        }

        // GET: Notifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotificationsViewModels notificationsViewModels = db.NotificationsViewModels.Find(id);
            if (notificationsViewModels == null)
            {
                return HttpNotFound();
            }
            return View(notificationsViewModels);
        }

        // GET: Notifications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CameraId,Name,ScenarioName,Type,Email")] NotificationsViewModels notificationsViewModels)
        {
            if (ModelState.IsValid)
            {
                db.NotificationsViewModels.Add(notificationsViewModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(notificationsViewModels);
        }

        // GET: Notifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotificationsViewModels notificationsViewModels = db.NotificationsViewModels.Find(id);
            if (notificationsViewModels == null)
            {
                return HttpNotFound();
            }
            return View(notificationsViewModels);
        }

        // POST: Notifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CameraId,Name,ScenarioName,Type,Email")] NotificationsViewModels notificationsViewModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notificationsViewModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notificationsViewModels);
        }

        // GET: Notifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotificationsViewModels notificationsViewModels = db.NotificationsViewModels.Find(id);
            if (notificationsViewModels == null)
            {
                return HttpNotFound();
            }
            return View(notificationsViewModels);
        }

        // POST: Notifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NotificationsViewModels notificationsViewModels = db.NotificationsViewModels.Find(id);
            db.NotificationsViewModels.Remove(notificationsViewModels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
