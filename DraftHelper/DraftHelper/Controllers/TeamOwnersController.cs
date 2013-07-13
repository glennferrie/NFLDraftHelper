using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DraftHelper.Models;

namespace DraftHelper.Controllers
{
    public class TeamOwnersController : Controller
    {
        private DraftHelperEntities db = new DraftHelperEntities();

        //
        // GET: /TeamOwners/
        public ActionResult Index()
        {
            return View(db.TeamOwners.ToList());
        }

        //
        // GET: /TeamOwners/Details/5
        public ActionResult Details(Int32 id)
        {
            TeamOwner teamowner = db.TeamOwners.Find(id);
            if (teamowner == null)
            {
                return HttpNotFound();
            }
            return View(teamowner);
        }

        //
        // GET: /TeamOwners/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TeamOwners/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeamOwner teamowner)
        {
            if (ModelState.IsValid)
            {
                db.TeamOwners.Add(teamowner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teamowner);
        }

        //
        // GET: /TeamOwners/Edit/5
        public ActionResult Edit(Int32 id)
        {
            TeamOwner teamowner = db.TeamOwners.Find(id);
            if (teamowner == null)
            {
                return HttpNotFound();
            }
            return View(teamowner);
        }

        //
        // POST: /TeamOwners/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TeamOwner teamowner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teamowner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teamowner);
        }

        //
        // GET: /TeamOwners/Delete/5
        public ActionResult Delete(Int32 id)
        {
            TeamOwner teamowner = db.TeamOwners.Find(id);
            if (teamowner == null)
            {
                return HttpNotFound();
            }
            return View(teamowner);
        }

        //
        // POST: /TeamOwners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Int32 id)
        {
            TeamOwner teamowner = db.TeamOwners.Find(id);
            db.TeamOwners.Remove(teamowner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
