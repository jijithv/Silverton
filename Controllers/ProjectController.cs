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
    public class ProjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Project
        public ActionResult Index()
        {
            return View(db.ProjectViewModels.ToList());
        }

        // GET: Project/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectViewModels projectViewModels = db.ProjectViewModels.Find(id);
            if (projectViewModels == null)
            {
                return HttpNotFound();
            }
            return View(projectViewModels);
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Name,City,Country,Client,Consultant,Contractor,Sector,Plot")] ProjectViewModels projectViewModels)
        {
            if (ModelState.IsValid)
            {
                db.ProjectViewModels.Add(projectViewModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectViewModels);
        }

        // GET: Project/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectViewModels projectViewModels = db.ProjectViewModels.Find(id);
            if (projectViewModels == null)
            {
                return HttpNotFound();
            }
            return View(projectViewModels);
        }

        // POST: Project/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Code,Name,City,Country,Client,Consultant,Contractor,Sector,Plot")] ProjectViewModels projectViewModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectViewModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectViewModels);
        }

        // GET: Project/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectViewModels projectViewModels = db.ProjectViewModels.Find(id);
            if (projectViewModels == null)
            {
                return HttpNotFound();
            }
            return View(projectViewModels);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ProjectViewModels projectViewModels = db.ProjectViewModels.Find(id);
            db.ProjectViewModels.Remove(projectViewModels);
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
