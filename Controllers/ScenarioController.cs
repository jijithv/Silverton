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
    public class ScenarioController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Scenario
        public ActionResult Index()
        {
            return View(db.ScenarioViewModels.ToList());
        }

        // GET: Scenario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScenarioViewModels scenarioViewModels = db.ScenarioViewModels.Find(id);
            if (scenarioViewModels == null)
            {
                return HttpNotFound();
            }
            return View(scenarioViewModels);
        }

        // GET: Scenario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Scenario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CameraId,Name,Status,Camera,WorkingDays,From,To")] ScenarioViewModels scenarioViewModels)
        {
            if (ModelState.IsValid)
            {
                db.ScenarioViewModels.Add(scenarioViewModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scenarioViewModels);
        }

        // GET: Scenario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScenarioViewModels scenarioViewModels = db.ScenarioViewModels.Find(id);
            if (scenarioViewModels == null)
            {
                return HttpNotFound();
            }
            return View(scenarioViewModels);
        }

        // POST: Scenario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CameraId,Name,Status,Camera,WorkingDays,From,To")] ScenarioViewModels scenarioViewModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scenarioViewModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scenarioViewModels);
        }

        // GET: Scenario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScenarioViewModels scenarioViewModels = db.ScenarioViewModels.Find(id);
            if (scenarioViewModels == null)
            {
                return HttpNotFound();
            }
            return View(scenarioViewModels);
        }

        // POST: Scenario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScenarioViewModels scenarioViewModels = db.ScenarioViewModels.Find(id);
            db.ScenarioViewModels.Remove(scenarioViewModels);
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
