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
        static List<SelectListItem> divisions = new List<SelectListItem>();
        static List<SelectListItem> positions = new List<SelectListItem>();

        static Lists()
        {
            var arr_c = new[] { "AFC", "NFC" };
            var arr_d = new[] { "North", "South", "East", "West" };
            var arr_p = new[] { "QB", "WR", "RB", "TE", "DEF" };

            Action<List<SelectListItem>, string[]> transform = 
                (a,b) => b.Select(q => new SelectListItem { Value = q, Text = q })
                            .ToList()
                            .ForEach(q => a.Add(q));

            transform(conferences, arr_c);
            transform(divisions, arr_d);
            transform(positions, arr_p);
        }

        public static IEnumerable<SelectListItem> GetConferences()
        {
            return conferences;
        }

        public static IEnumerable<SelectListItem> GetDivisions()
        {
            return divisions;
        }
    }
}