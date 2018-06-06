using CarDealership.Data.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = VehicleRepoFactory.GetRepository().GetDetails(id);
            return View(model);
        }
    }
}