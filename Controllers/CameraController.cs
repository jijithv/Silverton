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
    public class CameraController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Camera
        public ActionResult Index()
        {

            return View(db.CameraViewModels.ToList());
        }

        // GET: Camera/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CameraViewModels cameraViewModels = db.CameraViewModels.Find(id);
            if (cameraViewModels == null)
            {
                return HttpNotFound();
            }
            return View(cameraViewModels);
        }

        // GET: Camera/Create
        public ActionResult Create()
        {
            var model = new CameraViewModels
            {
                _weekdaysList = new List<SelectListItem>
                {
                    new SelectListItem {Value = "Sunday", Text = "Sunday"},
                    new SelectListItem {Value = "Monday", Text = "Monday"},
                    new SelectListItem {Value = "Tuesday", Text = "Tuesday"},
                    new SelectListItem {Value = "Wednesday", Text = "Wednesday"},
                    new SelectListItem {Value = "Thursday", Text = "Thursday"},
                    new SelectListItem {Value = "Friday", Text = "Friday"},
                    new SelectListItem {Value = "Saturday", Text = "Saturday"},
                }
            };

            // the list of available values

            return View(model);
        }

        // POST: Camera/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CameraId,Name,Make,Model,From,To,LiveView,ExtrernalLink,Status,VideoSpeed,ContinuousLoop")] CameraViewModels cameraViewModels)
        {
            if (ModelState.IsValid)
            {
                db.CameraViewModels.Add(cameraViewModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cameraViewModels);
        }

        // GET: Camera/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CameraViewModels cameraViewModels = db.CameraViewModels.Find(id);
            if (cameraViewModels == null)
            {
                return HttpNotFound();
            }
            return View(cameraViewModels);
        }

        // POST: Camera/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CameraId,Name,Make,Model,From,To,LiveView,ExtrernalLink,Status,VideoSpeed,ContinuousLoop")] CameraViewModels cameraViewModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cameraViewModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cameraViewModels);
        }

        // GET: Camera/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CameraViewModels cameraViewModels = db.CameraViewModels.Find(id);
            if (cameraViewModels == null)
            {
                return HttpNotFound();
            }
            return View(cameraViewModels);
        }

        // POST: Camera/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CameraViewModels cameraViewModels = db.CameraViewModels.Find(id);
            db.CameraViewModels.Remove(cameraViewModels);
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
