using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TipCalculator.Models;

namespace TipCalculator.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            TipCalculation model = new TipCalculation();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(TipCalculation model)
        {
            model.TenPercent = decimal.Multiply(model.Total, 0.10M);
            model.FifteenPercent = decimal.Multiply(model.Total, 0.15M);
            model.TwentyPercent = decimal.Multiply(model.Total, 0.20M);
            return View("CalculationResults", model);
        }

        [HttpGet]
        public ActionResult CalculationResults()
        {
            return View();
        }
    }
}