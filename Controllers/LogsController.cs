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
    public class LogsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Logs
        public ActionResult Index()
        {
            return View(db.LogsViewModels.ToList());
        }

        // GET: Logs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogsViewModels logsViewModels = db.LogsViewModels.Find(id);
            if (logsViewModels == null)
            {
                return HttpNotFound();
            }
            return View(logsViewModels);
        }

        // GET: Logs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Logs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CameraId,Date,Email,Status,IPAddress")] LogsViewModels logsViewModels)
        {
            if (ModelState.IsValid)
            {
                db.LogsViewModels.Add(logsViewModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(logsViewModels);
        }

        // GET: Logs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogsViewModels logsViewModels = db.LogsViewModels.Find(id);
            if (logsViewModels == null)
            {
                return HttpNotFound();
            }
            return View(logsViewModels);
        }

        // POST: Logs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CameraId,Date,Email,Status,IPAddress")] LogsViewModels logsViewModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(logsViewModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(logsViewModels);
        }

        // GET: Logs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogsViewModels logsViewModels = db.LogsViewModels.Find(id);
            if (logsViewModels == null)
            {
                return HttpNotFound();
            }
            return View(logsViewModels);
        }

        // POST: Logs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LogsViewModels logsViewModels = db.LogsViewModels.Find(id);
            db.LogsViewModels.Remove(logsViewModels);
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
