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
    public class TeamsController : Controller
    {
        private DraftHelperEntities db = new DraftHelperEntities();

        //
        // GET: /Teams/
        public ActionResult Index()
        {
            return View(db.NFLTeams.ToList());
        }

        //
        // GET: /Teams/Details/5
        public ActionResult Details(Int32 id)
        {
            NFLTeam nflteam = db.NFLTeams.Include("NFLPlayers").FirstOrDefault( q => q.Id == id);
            
            if (nflteam == null)
            {
                return HttpNotFound();
            }
            return View(nflteam);
        }

        public ActionResult AddPlayer(string pos, int team, string teamName)
        {
            ViewBag.TeamName = teamName;
             
            var p = new NFLPlayer { Position = pos, NFLTeam_Id = team };
            return View(p);
        }

        [HttpPost]
        public ActionResult AddPlayer(NFLPlayer nflplayer)
        {
            using (var db = new Models.DraftHelperEntities())
            {
                db.NFLPlayers.Add(nflplayer);
                db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = nflplayer.NFLTeam_Id });
        }

        //
        // GET: /Teams/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Teams/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NFLTeam nflteam)
        {
            if (ModelState.IsValid)
            {
                db.NFLTeams.Add(nflteam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nflteam);
        }

        //
        // GET: /Teams/Edit/5
        public ActionResult Edit(Int32 id)
        {
            NFLTeam nflteam = db.NFLTeams.Find(id);
            if (nflteam == null)
            {
                return HttpNotFound();
            }
            return View(nflteam);
        }

        //
        // POST: /Teams/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NFLTeam nflteam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nflteam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nflteam);
        }

        //
        // GET: /Teams/Delete/5
        public ActionResult Delete(Int32 id)
        {
            NFLTeam nflteam = db.NFLTeams.Find(id);
            if (nflteam == null)
            {
                return HttpNotFound();
            }
            return View(nflteam);
        }

        //
        // POST: /Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Int32 id)
        {
            NFLTeam nflteam = db.NFLTeams.Find(id);
            db.NFLTeams.Remove(nflteam);
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
