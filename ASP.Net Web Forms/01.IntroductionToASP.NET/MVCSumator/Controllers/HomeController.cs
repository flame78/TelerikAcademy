using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSumator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sumator()
        {
            return View();
        }

        public ActionResult CalculateSum(string firstNumber, string secondNumber)
        {
            try
            {
                ViewBag.Sum = (double.Parse(firstNumber) + double.Parse(secondNumber)).ToString();
            }
            catch (Exception)
            {
            }
            ViewBag.FirstNumber = firstNumber;
            ViewBag.SecondNumber = secondNumber;
            return View("Sumator");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}