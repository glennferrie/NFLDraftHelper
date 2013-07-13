using DraftHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DraftHelper.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var db = new DraftHelperEntities();
            var model = db.DraftPicks
                        .Include("SelectedPlayer").Include("SelectedPlayer.NFLTeam")
                        .Include("TeamOwner")
                        .ToList();
            return View(model);
        }
	}
}