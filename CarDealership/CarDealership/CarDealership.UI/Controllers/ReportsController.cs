using CarDealership.Data.ADO;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Inventory()
        {
            var model = new InventoryReportViewModel();
            var repo = new InventoryRepositoryADO();
            var newRepo = repo.GetNewInventory().ToList();
            var usedRepo = repo.GetUsedInventory().ToList();

            model.NewInventory = newRepo;
            model.UsedInventory = newRepo;

            return View(model);
        }
    }
}