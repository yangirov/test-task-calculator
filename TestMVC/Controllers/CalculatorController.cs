using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC.Models;
using TestMVC.Helpers;

namespace TestMVC.Controllers
{
	public class CalculatorController : Controller
	{
        // GET: Calculator/Index
        public ActionResult Index()
        {
            return View();
        }

        // POST: Calculator/Index
        [HttpPost]
        public ActionResult Index(CreditInfo credit)
        {
            if (ModelState.IsValid)
            {
                Calculator calculator = new Calculator();
                double annuity = calculator.Annuity(credit.Sum, credit.Period, credit.RateYear);

                if (credit.DayStep)
                    TempData["items"] = calculator.GetItemsByDays(credit.Sum, credit.Period, annuity, credit.StepPayment);
                else
                    TempData["items"] = calculator.GetItemsByMonth(credit.Sum, credit.Period, annuity);

                TempData["overpayments"] = calculator.OverPayments(credit.Sum, credit.Period, annuity);
                TempData["total"] = calculator.Total(credit.Sum, credit.Period, annuity);

                return RedirectToAction("Table");
            }

            return View(credit);
        }

        // GET: Calculator/Table
        public ActionResult Table()
        {
            var items = TempData["items"] as List<Item>;
            ViewBag.Total = TempData["total"];
            ViewBag.Overs = TempData["overpayments"];

            if (items != null && ViewBag.Overs != null && ViewBag.Total != null)
                return View(items);

            return HttpNotFound();
        }
    }
}