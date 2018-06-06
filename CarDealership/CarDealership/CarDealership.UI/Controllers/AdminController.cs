using CarDealership.Data.ADO;
using CarDealership.Models.Tables;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            var repo = new UserRepositoryADO();
            var model = repo.GetAll().ToList();

            return View(model);
        }

        public ActionResult AddVehicle()
        {
            var model = new AddVehicleViewModel();
            var makeRepo = new MakeRepositoryADO();
            var modelRepo = new ModelRepositoryADO();
            var typeRepo = new TypeRepositoryADO();
            var bodystyleRepo = new BodyStyleRepositoryADO();
            var transmissionRepo = new TransmissionRepositoryADO();
            var colorRepo = new ColorRepositoryADO();
            var interiorRepo = new InteriorRepositoryADO();

            model.Makes = new SelectList(makeRepo.GetAll(), "MakeID", "MakeName");
            model.Models = new SelectList(modelRepo.GetAll(), "ModelID", "ModelName");
            model.Types = new SelectList(modelRepo.GetAll(), "TypeID", "TypeName");
            model.BodyStyles = new SelectList(modelRepo.GetAll(), "BodyID", "BodyStyleName");
            model.Transmissions = new SelectList(modelRepo.GetAll(), "TransmissionID", "TransmissionType");
            model.Colors = new SelectList(modelRepo.GetAll(), "ColorID", "ColorName");
            model.Interiors = new SelectList(modelRepo.GetAll(), "InteriorID", "InteriorColor");

            model.Vehicle = new Vehicle();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddVehicle(AddVehicleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = new VehicleRepositoryADO();

                try
                {
                    var savePath = Server.MapPath("~/Images");

                    string fileName = Path.GetFileNameWithoutExtension(model.PictureUpload.FileName);
                    string extension = Path.GetExtension(model.PictureUpload.FileName);

                    var filePath = Path.Combine(savePath, fileName + extension);

                    int counter = 1;
                    while (System.IO.File.Exists(filePath))
                    {
                        filePath = Path.Combine(savePath, fileName + counter.ToString() + extension);
                        counter++;
                    }

                    model.PictureUpload.SaveAs(filePath);
                    model.Vehicle.Picture = Path.GetFileName(filePath);
                    repo.Insert(model.Vehicle);

                    return RedirectToAction("EditVehicle", "Admin", new { id = model.Vehicle.VehicleID });
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
                var vehicleModel = new AddVehicleViewModel();
                var makeRepo = new MakeRepositoryADO();
                var modelRepo = new ModelRepositoryADO();
                var typeRepo = new TypeRepositoryADO();
                var bodystyleRepo = new BodyStyleRepositoryADO();
                var transmissionRepo = new TransmissionRepositoryADO();
                var colorRepo = new ColorRepositoryADO();
                var interiorRepo = new InteriorRepositoryADO();

                vehicleModel.Makes = new SelectList(makeRepo.GetAll(), "MakeID", "MakeName");
                vehicleModel.Models = new SelectList(modelRepo.GetAll(), "ModelID", "ModelName");
                vehicleModel.Types = new SelectList(modelRepo.GetAll(), "TypeID", "TypeName");
                vehicleModel.BodyStyles = new SelectList(modelRepo.GetAll(), "BodyID", "BodyStyleName");
                vehicleModel.Transmissions = new SelectList(modelRepo.GetAll(), "TransmissionID", "TransmissionType");
                vehicleModel.Colors = new SelectList(modelRepo.GetAll(), "ColorID", "ColorName");
                vehicleModel.Interiors = new SelectList(modelRepo.GetAll(), "InteriorID", "InteriorColor");

                return View(vehicleModel);
            }
        }

        public ActionResult EditVehicle(int id)
        {
            var model = new EditVehicleViewModel();
            var makeRepo = new MakeRepositoryADO();
            var modelRepo = new ModelRepositoryADO();
            var typeRepo = new TypeRepositoryADO();
            var bodystyleRepo = new BodyStyleRepositoryADO();
            var transmissionRepo = new TransmissionRepositoryADO();
            var colorRepo = new ColorRepositoryADO();
            var interiorRepo = new InteriorRepositoryADO();

            var vehicleRepo = new VehicleRepositoryADO();

            model.Makes = new SelectList(makeRepo.GetAll(), "MakeID", "MakeName");
            model.Models = new SelectList(modelRepo.GetAll(), "ModelID", "ModelName");
            model.Types = new SelectList(modelRepo.GetAll(), "TypeID", "TypeName");
            model.BodyStyles = new SelectList(modelRepo.GetAll(), "BodyID", "BodyStyleName");
            model.Transmissions = new SelectList(modelRepo.GetAll(), "TransmissionID", "TransmissionType");
            model.Colors = new SelectList(modelRepo.GetAll(), "ColorID", "ColorName");
            model.Interiors = new SelectList(modelRepo.GetAll(), "InteriorID", "InteriorColor");

            model.Vehicle = vehicleRepo.GetByID(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult EditVehicle(EditVehicleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = new VehicleRepositoryADO();

                try
                {
                    var oldVehicleInfo = repo.GetByID(model.Vehicle.VehicleID);
                    if (model.PictureUpload != null && model.PictureUpload.ContentLength > 0)
                    {
                        var savePath = Server.MapPath("~/Images");

                        string fileName = Path.GetFileNameWithoutExtension(model.PictureUpload.FileName);
                        string extension = Path.GetExtension(model.PictureUpload.FileName);

                        var filePath = Path.Combine(savePath, fileName + extension);

                        int counter = 1;
                        while (System.IO.File.Exists(filePath))
                        {
                            filePath = Path.Combine(savePath, fileName + counter.ToString() + extension);
                            counter++;
                        }

                        model.PictureUpload.SaveAs(filePath);
                        model.Vehicle.Picture = Path.GetFileName(filePath);

                        var oldPath = Path.Combine(savePath, fileName + counter.ToString() + extension);
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    else
                    {
                        model.Vehicle.Picture = oldVehicleInfo.Picture;
                    }

                    repo.Update(model.Vehicle);

                    return RedirectToAction("EditVehicle", "Admin", new { id = model.Vehicle.VehicleID });
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
                var vehicleModel = new AddVehicleViewModel();
                var makeRepo = new MakeRepositoryADO();
                var modelRepo = new ModelRepositoryADO();
                var typeRepo = new TypeRepositoryADO();
                var bodystyleRepo = new BodyStyleRepositoryADO();
                var transmissionRepo = new TransmissionRepositoryADO();
                var colorRepo = new ColorRepositoryADO();
                var interiorRepo = new InteriorRepositoryADO();

                vehicleModel.Makes = new SelectList(makeRepo.GetAll(), "MakeID", "MakeName");
                vehicleModel.Models = new SelectList(modelRepo.GetAll(), "ModelID", "ModelName");
                vehicleModel.Types = new SelectList(modelRepo.GetAll(), "TypeID", "TypeName");
                vehicleModel.BodyStyles = new SelectList(modelRepo.GetAll(), "BodyID", "BodyStyleName");
                vehicleModel.Transmissions = new SelectList(modelRepo.GetAll(), "TransmissionID", "TransmissionType");
                vehicleModel.Colors = new SelectList(modelRepo.GetAll(), "ColorID", "ColorName");
                vehicleModel.Interiors = new SelectList(modelRepo.GetAll(), "InteriorID", "InteriorColor");

                return View(vehicleModel);
            }
        }
    }
}