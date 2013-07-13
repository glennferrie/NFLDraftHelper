using DraftHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DraftHelper.Controllers
{
    public class ToolsController : Controller
    {
        //
        // GET: /Tools/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StartDraft()
        {
            var db = new DraftHelperEntities();
            var model = db.TeamOwners.Count();

            if (db.DraftPicks.Any())
            {
                ViewBag.BlockStart = "Draft has already been started!";
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult StartDraft(FormCollection collection)
        {
            var db = new DraftHelperEntities();

            var owners = db.TeamOwners.ToArray();

            const int ROUNDS = 12; // add to config
            var picknum = 1;

            for (var q = 1; q <= ROUNDS; q++)
            {
                if (q % 2 == 0)
                {
                    for (var w = owners.Length - 1; w > -1; w--)
                    {
                        var pick = new DraftPick { TeamOwner = owners[w], PickNumber = picknum };
                        db.DraftPicks.Add(pick);
                        picknum++;
                    }
                }
                else
                {
                    for (var w = 0; w < owners.Length; w++)
                    {
                        var pick = new DraftPick { TeamOwner = owners[w], PickNumber = picknum };
                        db.DraftPicks.Add(pick);
                        picknum++;
                    }
                }
            }

            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ResetDraft()
        {
            return View();
        }
	}
}