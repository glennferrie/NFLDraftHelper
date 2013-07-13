using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DraftHelper.Models
{
    public static class Lists
    {
        static List<SelectListItem> conferences = new List<SelectListItem>();

        static Lists()
        {
            conferences = new List<SelectListItem> { new SelectListItem { Text = "NFC", Value = "NFC" }, new SelectListItem { Text = "AFC", Value = "AFC" } };
        }

        public static IEnumerable<SelectListItem> GetConferences()
        {
            return conferences;
        }
    }
}