using BitCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitCalculator.Controllers
{
    public class HomeController : Controller
    {
        private static List<string> types = new List<string>()
            {
                "bit - b",
                "Byte - B",
                "Kilobit - Kb",
                "Kilobyte - KB",
                "Megabit - Mb",
                "Megabyte - MB",
                "Gigabit - Gb",
                "Gigabyte - GB",
                "Terabit - Tb",
                "Terabyte - TB",
                "Petabit - Pb",
                "Petabyte - PB",
                "Exabit - Eb",
                "Exabyte - EB",
                "Zettabit - Zb",
                "Zettabyte - ZB",
                "Yottabit - Yb",
                "Yottabyte - YB",
            };

        public HomeController()
        {
            if (Types == null)
            {
                Types = types.Select((t, i) => new SelectListItem() { Text = t, Value = i.ToString() }).ToList();
            }
        }

        public static List<SelectListItem> Types { get; private set; }

        public ActionResult Index(CalculatorConfiguration conf)
        {
            ViewBag.Types = Types.ToList();
            return View(conf);
        }

        [ChildActionOnly]
        public ActionResult ShowResult(CalculatorConfiguration conf)
        {
            if (conf == null || conf.Kilo == 0) return null;

            List<ResultData> results = CalculateResults(conf);

            return View("_ShowResultPartial", results);
        }

        private static List<ResultData> CalculateResults(CalculatorConfiguration conf)
        {
            var results = types.Select((t, i) => new ResultData() { Type = t, Value = i }).ToList();

            for (int i = conf.Type; i >= 0; i--)
            {
                if (i == conf.Type)
                {
                    results[conf.Type].Value = conf.Quantity;
                    continue;
                }

                if (i % 2 != 0)
                {
                    results[i].Value = results[i + 1].Value / 8 * conf.Kilo;
                }
                else
                {
                    results[i].Value = results[i + 1].Value * 8;
                }
            }

            for (int i = conf.Type; i < types.Count; i++)
            {
                if (i == conf.Type)
                {
                    results[conf.Type].Value = conf.Quantity;
                    continue;
                }

                if (i % 2 != 0)
                {
                    results[i].Value = results[i - 1].Value / 8;
                }
                else
                {
                    results[i].Value = results[i - 1].Value / conf.Kilo * 8;
                }
            }

            return results;
        }
    }
}