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
    public class PlayersController : Controller
    {
        private DraftHelperEntities db = new DraftHelperEntities();

        //
        // GET: /Players/
        public ActionResult Index()
        {
            var nflplayers = db.NFLPlayers.Include(n => n.NFLTeam);
            return View(nflplayers.OrderBy(a => a.MyRank).ToList());
        }

        //
        // GET: /Players/Details/5
        public ActionResult Details(Int32 id)
        {
            NFLPlayer nflplayer = db.NFLPlayers.Find(id);
            if (nflplayer == null)
            {
                return HttpNotFound();
            }
            return View(nflplayer);
        }

        //
        // GET: /Players/Create
        public ActionResult Create()
        {
            ViewBag.NFLTeam_Id = new SelectList(db.NFLTeams, "Id", "Name");
            return View();
        }

        //
        // POST: /Players/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NFLPlayer nflplayer)
        {
            if (ModelState.IsValid)
            {
                db.NFLPlayers.Add(nflplayer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NFLTeam_Id = new SelectList(db.NFLTeams, "Id", "Name", nflplayer.NFLTeam_Id);
            return View(nflplayer);
        }

        //
        // GET: /Players/Edit/5
        public ActionResult Edit(Int32 id)
        {
            NFLPlayer nflplayer = db.NFLPlayers.Find(id);
            if (nflplayer == null)
            {
                return HttpNotFound();
            }
            ViewBag.NFLTeam_Id = new SelectList(db.NFLTeams, "Id", "Name", nflplayer.NFLTeam_Id);
            return View(nflplayer);
        }

        //
        // POST: /Players/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NFLPlayer nflplayer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nflplayer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NFLTeam_Id = new SelectList(db.NFLTeams, "Id", "Name", nflplayer.NFLTeam_Id);
            return View(nflplayer);
        }

        //
        // GET: /Players/Delete/5
        public ActionResult Delete(Int32 id)
        {
            NFLPlayer nflplayer = db.NFLPlayers.Find(id);
            if (nflplayer == null)
            {
                return HttpNotFound();
            }
            return View(nflplayer);
        }

        //
        // POST: /Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Int32 id)
        {
            NFLPlayer nflplayer = db.NFLPlayers.Find(id);
            db.NFLPlayers.Remove(nflplayer);
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
