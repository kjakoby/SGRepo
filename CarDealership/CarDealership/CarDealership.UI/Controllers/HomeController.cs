using CarDealership.Data.ADO;
using CarDealership.Data.Factories;
using CarDealership.Models.Tables;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var model = VehicleRepoFactory.GetRepository().GetFeatured();
            return View(model);
        }

        // TODO BEGIN
        //needs to be moved to Account

        //[AllowAnonymous]
        //public ActionResult Login()
        //{
        //    var model = new LoginViewModel();

        //    return View(model);
        //}

        //TODO END

        [HttpGet]
        public ActionResult Specials()
        {
            var model = SpecialsRepoFactory.GetRepository().GetList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Contact(Contact model)
        {
            var repo = ContactRepoFactory.GetRepository();

            try
            {
                repo.Insert(model);
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}