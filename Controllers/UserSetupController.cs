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
    public class UserSetupController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserSetup
        public ActionResult Index()
        {
            return View(db.UserSetupViewModels.ToList());
        }

        // GET: UserSetup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserSetupViewModels userSetupViewModels = db.UserSetupViewModels.Find(id);
            if (userSetupViewModels == null)
            {
                return HttpNotFound();
            }
            return View(userSetupViewModels);
        }

        // GET: UserSetup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserSetup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CameraId,Email,Password,UserName,Type,Projects,AccessPrivilege")] UserSetupViewModels userSetupViewModels)
        {
            if (ModelState.IsValid)
            {
                db.UserSetupViewModels.Add(userSetupViewModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userSetupViewModels);
        }

        // GET: UserSetup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserSetupViewModels userSetupViewModels = db.UserSetupViewModels.Find(id);
            if (userSetupViewModels == null)
            {
                return HttpNotFound();
            }
            return View(userSetupViewModels);
        }

        // POST: UserSetup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CameraId,Email,Password,UserName,Type,Projects,AccessPrivilege")] UserSetupViewModels userSetupViewModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userSetupViewModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userSetupViewModels);
        }

        // GET: UserSetup/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserSetupViewModels userSetupViewModels = db.UserSetupViewModels.Find(id);
            if (userSetupViewModels == null)
            {
                return HttpNotFound();
            }
            return View(userSetupViewModels);
        }

        // POST: UserSetup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserSetupViewModels userSetupViewModels = db.UserSetupViewModels.Find(id);
            db.UserSetupViewModels.Remove(userSetupViewModels);
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
