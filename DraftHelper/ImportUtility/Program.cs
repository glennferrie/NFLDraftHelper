using DraftHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace ImportUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new DraftHelperEntities();

            var path = @"C:\git\NFLDraftHelper\DraftHelper\data\player-sheet-2013-07-13.csv";

            var data = File.ReadAllLines(path)
                        .Select(q => Parse(q))
                        .ToList();

            var poslist = new[] { "QB", "WR", "RB", "TE", "D/ST", "K" };

            foreach (var item in data)
            {
                if (poslist.Contains(item.Item4))
                {
                    var teamcode = item.Item3;

                    var team = db.NFLTeams.FirstOrDefault(q => q.Abbrev == teamcode);
                    if (team == null)
                    {
                        team = new NFLTeam { Abbrev = teamcode, Division = "", Name = teamcode, Locale = teamcode, Conference = "" };
                        db.NFLTeams.Add(team);
                    }

                    var player = new NFLPlayer { NFLTeam = team, ESPNRank = item.Item1, MyRank = item.Item1, Name = item.Item2, Position = item.Item4 };
                    db.NFLPlayers.Add(player);
                    db.SaveChanges();
                    continue;
                }
                throw new InvalidDataException("Pos: " + item.Item4);
            }

            if (db.ChangeTracker.HasChanges())
                db.SaveChanges();

            Console.WriteLine("Completed Successfully!");
            Console.ReadLine();
        }

        private static Tuple<int, string, string, string> Parse(string text)
        {
            var rank = -1;
            var name = "<unknown>";
            var team = "UNK";
            var pos = "UNK";

            var theRest = text;

            // get rank
            var index = theRest.IndexOf(",");
            int.TryParse(theRest.Substring(0, index), out rank);
            theRest = theRest.Substring(index+1);

            if (theRest.Contains("\""))
            {
                theRest = theRest.Substring(1);
                index = theRest.IndexOf("\"");
                var chunk = theRest.Substring(0, index).Split(',');
                name = chunk[0];
                team = chunk[1];
                pos = theRest.Substring(index + 2).Split(',').First();
            }
            else
            {
                var parts = theRest.Split(',');
                name = parts[0];
                pos = parts[1];
            }

            return Tuple.Create(rank, name, team, pos);
        }
    }
}
