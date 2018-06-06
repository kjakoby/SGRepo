using CarDealership.Data.ADO;
using CarDealership.Data.Interfaces;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Tests.IntegrationTests
{
    [TestFixture]
    public class ADOTests
    {
        [SetUp]
        public void Init()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void CanLoadBodyStyle()
        {
            var repo = new BodyStyleRepositoryADO();

            var bodyStyles = repo.GetAll();

            Assert.AreEqual(5, bodyStyles.Count);

            Assert.AreEqual(1, bodyStyles[0].BodyID);
            Assert.AreEqual("Van", bodyStyles[3].BodyStyleName);
        }

        [Test]
        public void CanLoadColor()
        {
            var repo = new ColorRepositoryADO();

            var colors = repo.GetAll();

            Assert.AreEqual(5, colors.Count);

            Assert.AreEqual(1, colors[0].ColorID);
            Assert.AreEqual("Blue", colors[4].ColorName);
        }

        //need to complete

        [Test]
        public void CanLoadContact()
        {
            var repo = new ContactRepositoryADO();

            var contacts = repo.GetAll();

            Assert.AreEqual(5, contacts.Count);

            Assert.AreEqual(1, contacts[0].ContactID);
            Assert.AreEqual("Ratchet", contacts[1].ContactName);
        }

        [Test]
        public void CanLoadInterior()
        {
            var repo = new InteriorRepositoryADO();

            var interiors = repo.GetAll();

            Assert.AreEqual(3, interiors.Count);

            Assert.AreEqual(1, interiors[0].InteriorID);
            Assert.AreEqual("Grey", interiors[1].InteriorColor);
        }

        [Test]
        public void CanLoadMake()
        {
            var repo = new MakeRepositoryADO();

            var makes = repo.GetAll();

            Assert.AreEqual(5, makes.Count);

            Assert.AreEqual(1, makes[0].MakeID);
            Assert.AreEqual("Saturn", makes[3].MakeName);
            Assert.AreEqual("1980-11-05", makes[2].MakeDateAdded.ToString("yyyy-MM-dd"));
        }

        [Test]
        public void CanLoadModel()
        {
            var repo = new ModelRepositoryADO();

            var models = repo.GetAll();

            Assert.AreEqual(5, models.Count);

            Assert.AreEqual(1, models[0].ModelID);
            Assert.AreEqual("Aura", models[4].ModelName);
            Assert.AreEqual("2000-03-28", models[2].ModelDateAdded.ToString("yyyy-MM-dd"));
        }

        [Test]
        public void CanLoadPurchase()
        {
            var repo = new PurchaseRepositoryADO();

            var purchases = repo.GetAll();

            Assert.AreEqual(5, purchases.Count);

            Assert.AreEqual(1, purchases[0].PurchaseID);
            Assert.AreEqual(34560, purchases[2].PurchasePrice);
        }

        [Test]
        public void CanLoadPurchaseType()
        {
            var repo = new PurchaseTypeRepositoryADO();

            var purchaseTypes = repo.GetAll();

            Assert.AreEqual(5, purchaseTypes.Count);

            Assert.AreEqual(1, purchaseTypes[0].PurchaseTypeID);
            Assert.AreEqual("Manager Sale", purchaseTypes[3].PurchaseTypeName);
        }

        [Test]
        public void CanLoadSpecials()
        {
            var repo = new SpecialsRepositoryADO();

            var specials = repo.GetAll();

            Assert.AreEqual(4, specials.Count);

            Assert.AreEqual(1, specials[0].SpecialID);
            Assert.AreEqual("Sale on Saturns", specials[2].SpecialTitle);
        }

        [Test]
        public void CanLoadTransmission()
        {
            var repo = new TransmissionRepositoryADO();

            var Transmission = repo.GetAll();

            Assert.AreEqual(2, Transmission.Count);

            Assert.AreEqual(1, Transmission[0].TransmissionID);
            Assert.AreEqual("Manual", Transmission[1].TransmissionType);
        }

        [Test]
        public void CanLoadType()
        {
            var repo = new TypeRepositoryADO();

            var types = repo.GetAll();

            Assert.AreEqual(2, types.Count);

            Assert.AreEqual(1, types[0].TypeID);
            Assert.AreEqual("Used", types[1].TypeName);
        }

        [Test]
        public void CanLoadVehicle()
        {
            var repo = new VehicleRepositoryADO();

            var vehicles = repo.GetAll();

            Assert.AreEqual(8, vehicles.Count);

            Assert.AreEqual(1, vehicles[0].VehicleID);
            Assert.AreEqual("5J8TB3H53DL010021", vehicles[5].VIN);
        }

        [Test]
        public void CanGetSingleVehicle()
        {
            var repo = new VehicleRepositoryADO();
            var vehicle = repo.GetByID(1);

            //(VehicleID, Year, Mileage, MSRP, UserID, SalesPrice, [Description], Picture, Featured, VIN, ModelID, ColorID, TypeID, TransmissionID, InteriorID)
            //(1, 2017, 0, 55450, '00000000-1111-1111-0000-000000000000', 52980, 'Great car, makes you feel alive!', null, 1, 'WBAVL1C50EVR93551', 1, 3, 1, 1, 2), --corvette

            Assert.AreEqual(1, vehicle.VehicleID);
            Assert.AreEqual(2017, vehicle.Year);
            Assert.AreEqual(0, vehicle.Mileage);
            Assert.AreEqual(55450, vehicle.MSRP);
            Assert.AreEqual("00000000-1111-1111-0000-000000000000", vehicle.UserID);
            Assert.AreEqual(52980, vehicle.SalesPrice);
            Assert.AreEqual("Great car, makes you feel alive!", vehicle.Description);
            Assert.AreEqual("placeholder.png", vehicle.Picture);
            Assert.AreEqual(true, vehicle.Featured);
            Assert.AreEqual("WBAVL1C50EVR93551", vehicle.VIN);
            Assert.AreEqual(1, vehicle.ModelID);
            Assert.AreEqual(3, vehicle.ColorID);
            Assert.AreEqual(1, vehicle.TypeID);
            Assert.AreEqual(1, vehicle.TransmissionID);
            Assert.AreEqual(2, vehicle.InteriorID);
        }

        [Test]
        public void NoVehicleReturnsNull()
        {
            var repo = new VehicleRepositoryADO();

            var vehicle = repo.GetByID(1000000000);

            Assert.IsNull(vehicle);
        }

        [Test]
        public void CanAddMake()
        {
            Make makeToAdd = new Make();
            var repo = new MakeRepositoryADO();

            makeToAdd.MakeName = "Test";
            makeToAdd.MakeDateAdded = DateTime.Today;
            makeToAdd.UserID = "00000000-1111-1111-0000-000000000000";

            repo.Insert(makeToAdd);

            Assert.AreEqual(6, makeToAdd.MakeID);
            Assert.AreEqual("Test", makeToAdd.MakeName);
            Assert.AreEqual("00000000-1111-1111-0000-000000000000", makeToAdd.UserID);
            Assert.AreEqual(DateTime.Today, makeToAdd.MakeDateAdded);
        }

        [Test]
        public void CanAddVehicle()
        {
            Vehicle vehicleToAdd = new Vehicle();
            var repo = new VehicleRepositoryADO();

            vehicleToAdd.Year = 2018;
            vehicleToAdd.Mileage = 0;
            vehicleToAdd.MSRP = 50011;
            vehicleToAdd.SalesPrice = 49875;
            vehicleToAdd.Description = "The meanest on the streets!";
            vehicleToAdd.Picture = "placeholder.png";
            vehicleToAdd.Featured = true;
            vehicleToAdd.VIN = "KMHHT6KD1CU079023";
            //vehicleToAdd.MakeID = 2;
            vehicleToAdd.BodyID = 5;
            vehicleToAdd.ModelID = 3;
            vehicleToAdd.ColorID = 2;
            vehicleToAdd.TypeID = 1;
            vehicleToAdd.TransmissionID = 1;
            vehicleToAdd.InteriorID = 3;
            vehicleToAdd.UserID = "00000000-1111-1111-0000-000000000000";

            repo.Insert(vehicleToAdd);

            Assert.AreEqual(9, vehicleToAdd.VehicleID);
            Assert.AreEqual(2018, vehicleToAdd.Year);
            Assert.AreEqual(0, vehicleToAdd.Mileage);
            Assert.AreEqual(50011, vehicleToAdd.MSRP);
            Assert.AreEqual(49875, vehicleToAdd.SalesPrice);
            Assert.AreEqual("The meanest on the streets!", vehicleToAdd.Description);
            Assert.AreEqual("placeholder.png", vehicleToAdd.Picture);
            Assert.AreEqual(true, vehicleToAdd.Featured);
            Assert.AreEqual("KMHHT6KD1CU079023", vehicleToAdd.VIN);
            Assert.AreEqual(5, vehicleToAdd.BodyID);
            Assert.AreEqual(3, vehicleToAdd.ModelID);
            Assert.AreEqual(2, vehicleToAdd.ColorID);
            Assert.AreEqual(1, vehicleToAdd.TypeID);
            Assert.AreEqual(1, vehicleToAdd.TransmissionID);
            Assert.AreEqual(3, vehicleToAdd.InteriorID);
            Assert.AreEqual("00000000-1111-1111-0000-000000000000", vehicleToAdd.UserID);
        }

        [Test]
        public void CanAddPurchase()
        {
            Purchase purchaseToAdd = new Purchase();
            var repo = new PurchaseRepositoryADO();

            purchaseToAdd.SellName = "Test";
            purchaseToAdd.SellPhone = "999-999-9999";
            purchaseToAdd.SellEmail = "test@test.com";
            purchaseToAdd.SellStreet1 = "1234 test ct.";
            purchaseToAdd.SellStreet2 = null;
            purchaseToAdd.City = "test";
            purchaseToAdd.State = "st";
            purchaseToAdd.ZipCode = 99999;
            purchaseToAdd.PurchasePrice = 999999;
            purchaseToAdd.PurchaseTypeID = 4;
            purchaseToAdd.UserID = "00000000-1111-1111-0000-000000000000";
            purchaseToAdd.VehicleID = 2;

            repo.Insert(purchaseToAdd);

            Assert.AreEqual(6, purchaseToAdd.PurchaseID);
            Assert.AreEqual("Test", purchaseToAdd.SellName);
            Assert.AreEqual("999-999-9999", purchaseToAdd.SellPhone);
            Assert.AreEqual("test@test.com", purchaseToAdd.SellEmail);
            Assert.AreEqual("1234 test ct.", purchaseToAdd.SellStreet1);
            Assert.IsNull(purchaseToAdd.SellStreet2);
            Assert.AreEqual("test", purchaseToAdd.City);
            Assert.AreEqual("st", purchaseToAdd.State);
            Assert.AreEqual(99999, purchaseToAdd.ZipCode);
            Assert.AreEqual(999999, purchaseToAdd.PurchasePrice);
            Assert.AreEqual(4, purchaseToAdd.PurchaseTypeID);
            Assert.AreEqual(2, purchaseToAdd.VehicleID);
            Assert.AreEqual("00000000-1111-1111-0000-000000000000", purchaseToAdd.UserID);
        }

        [Test]
        public void CanAddContact()
        {
            Contact contactToAdd = new Contact();
            var repo = new ContactRepositoryADO();

            contactToAdd.ContactName = "Test";
            contactToAdd.ContactEmail = "test@test.com";
            contactToAdd.ContactPhone = "999-999-9999";
            contactToAdd.Message = "test message";

            repo.Insert(contactToAdd);

            Assert.AreEqual(6, contactToAdd.ContactID);
            Assert.AreEqual("Test", contactToAdd.ContactName);
            Assert.AreEqual("999-999-9999", contactToAdd.ContactPhone);
            Assert.AreEqual("test@test.com", contactToAdd.ContactEmail);
            Assert.AreEqual("test message", contactToAdd.Message);
        }

        [Test]
        public void CanAddSpecial()
        {
            Specials specialToAdd = new Specials();
            var repo = new SpecialsRepositoryADO();

            specialToAdd.SpecialTitle = "Test";
            specialToAdd.SpecialDescription = "Test description";

            repo.Insert(specialToAdd);
            Assert.AreEqual(5, specialToAdd.SpecialID);
            Assert.AreEqual("Test", specialToAdd.SpecialTitle);
            Assert.AreEqual("Test description", specialToAdd.SpecialDescription);
        }

        [Test]
        public void CanAddModel()
        {
            Model modelToAdd = new Model();
            var repo = new ModelRepositoryADO();

            modelToAdd.MakeID = 1;
            modelToAdd.ModelName = "test";
            modelToAdd.ModelDateAdded = DateTime.Today;
            modelToAdd.UserID = "00000000-1111-1111-0000-000000000000";

            repo.Insert(modelToAdd);

            Assert.AreEqual(6, modelToAdd.ModelID);
            Assert.AreEqual(1, modelToAdd.MakeID);
            Assert.AreEqual("test", modelToAdd.ModelName);
            Assert.AreEqual("00000000-1111-1111-0000-000000000000", modelToAdd.UserID);
            Assert.AreEqual(DateTime.Today, modelToAdd.ModelDateAdded);
        }

        [Test]
        public void CanEditVehicle()
        {
            Vehicle vehicleToAdd = new Vehicle();
            var repo = new VehicleRepositoryADO();

            vehicleToAdd.Year = 2018;
            vehicleToAdd.Mileage = 0;
            vehicleToAdd.MSRP = 50011;
            vehicleToAdd.SalesPrice = 49875;
            vehicleToAdd.Description = "The meanest on the streets!";
            vehicleToAdd.Picture = "placeholder.png";
            vehicleToAdd.Featured = true;
            vehicleToAdd.VIN = "KMHHT6KD1CU079023";
            //vehicleToAdd.MakeID = 2;
            vehicleToAdd.BodyID = 5;
            vehicleToAdd.ModelID = 3;
            vehicleToAdd.ColorID = 2;
            vehicleToAdd.TypeID = 1;
            vehicleToAdd.TransmissionID = 1;
            vehicleToAdd.InteriorID = 3;
            vehicleToAdd.UserID = "00000000-1111-1111-0000-000000000000";

            repo.Insert(vehicleToAdd);

            vehicleToAdd.Year = 2010;
            vehicleToAdd.Mileage = 30000;
            vehicleToAdd.MSRP = 12654;
            vehicleToAdd.SalesPrice = 11632;
            vehicleToAdd.Description = "Baddest on the streets!";
            vehicleToAdd.Picture = "placeholder.png";
            vehicleToAdd.Featured = false;
            vehicleToAdd.VIN = "KMHHR6K21CU0A9023";
            //vehicleToAdd.MakeID = 2;
            vehicleToAdd.BodyID = 3;
            vehicleToAdd.ModelID = 2;
            vehicleToAdd.ColorID = 1;
            vehicleToAdd.TypeID = 2;
            vehicleToAdd.TransmissionID = 2;
            vehicleToAdd.InteriorID = 1;
            vehicleToAdd.UserID = "00000000-1111-1111-0000-000000000000";

            repo.Update(vehicleToAdd);

            var updatedVehicle = repo.GetByID(9);

            Assert.AreEqual(2010, vehicleToAdd.Year);
            Assert.AreEqual(30000, vehicleToAdd.Mileage);
            Assert.AreEqual(12654, vehicleToAdd.MSRP);
            Assert.AreEqual(11632, vehicleToAdd.SalesPrice);
            Assert.AreEqual("Baddest on the streets!", vehicleToAdd.Description);
            Assert.AreEqual("placeholder.png", vehicleToAdd.Picture);
            Assert.AreEqual(false, vehicleToAdd.Featured);
            Assert.AreEqual("KMHHR6K21CU0A9023", vehicleToAdd.VIN);
            Assert.AreEqual(3, vehicleToAdd.BodyID);
            Assert.AreEqual(2, vehicleToAdd.ModelID);
            Assert.AreEqual(1, vehicleToAdd.ColorID);
            Assert.AreEqual(2, vehicleToAdd.TypeID);
            Assert.AreEqual(2, vehicleToAdd.TransmissionID);
            Assert.AreEqual(1, vehicleToAdd.InteriorID);
            Assert.AreEqual("00000000-1111-1111-0000-000000000000", vehicleToAdd.UserID);


        }

        [Test]
        public void CanDeleteVehicle()
        {
            Vehicle vehicleToAdd = new Vehicle();
            var repo = new VehicleRepositoryADO();

            vehicleToAdd.Year = 2018;
            vehicleToAdd.Mileage = 0;
            vehicleToAdd.MSRP = 50011;
            vehicleToAdd.SalesPrice = 49875;
            vehicleToAdd.Description = "The meanest on the streets!";
            vehicleToAdd.Picture = "placeholder.png";
            vehicleToAdd.Featured = true;
            vehicleToAdd.VIN = "KMHHT6KD1CU079023";
            //vehicleToAdd.MakeID = 2;
            vehicleToAdd.BodyID = 5;
            vehicleToAdd.ModelID = 3;
            vehicleToAdd.ColorID = 2;
            vehicleToAdd.TypeID = 1;
            vehicleToAdd.TransmissionID = 1;
            vehicleToAdd.InteriorID = 3;
            vehicleToAdd.UserID = "00000000-1111-1111-0000-000000000000";

            repo.Insert(vehicleToAdd);

            var loaded = repo.GetByID(9);
            Assert.IsNotNull(loaded);

            repo.Delete(9);

            loaded = repo.GetByID(9);
            Assert.IsNull(loaded);
        }

        [Test]
        public void CanGetFeaturedVehicles()
        {
            var repo = new VehicleRepositoryADO();
            List<FeaturedItem> featured = repo.GetFeatured().ToList();

            Assert.AreEqual(4, featured.Count());

            Assert.AreEqual(1, featured[0].VehicleID);
            //Assert.AreEqual(1, featured[0].MakeID);
            //Assert.AreEqual(1, featured[0].ModelID);
            Assert.AreEqual("Chevy", featured[0].MakeName);
            Assert.AreEqual("Corvette", featured[0].ModelName);
            Assert.AreEqual(52980, featured[0].SalesPrice);
            Assert.AreEqual("placeholder.png", featured[0].Picture);
        }

        [Test]
        public void CanGetVehicleDetails()
        {
            var repo = new VehicleRepositoryADO();
            var vehicle = repo.GetDetails(1);

            //(VehicleID, Year, Mileage, MSRP, UserID, SalesPrice, [Description], Picture, Featured, VIN, ModelID, ColorID, TypeID, TransmissionID, InteriorID)
            //(1, 2017, 0, 55450, '00000000-1111-1111-0000-000000000000', 52980, 'Great car, makes you feel alive!', null, 1, 'WBAVL1C50EVR93551', 1, 3, 1, 1, 2), --corvette

            Assert.AreEqual(1, vehicle.VehicleID);
            Assert.AreEqual(2017, vehicle.Year);
            Assert.AreEqual(0, vehicle.Mileage);
            Assert.AreEqual(55450, vehicle.MSRP);
            Assert.AreEqual(52980, vehicle.SalesPrice);
            Assert.AreEqual("Great car, makes you feel alive!", vehicle.Description);
            Assert.AreEqual("placeholder.png", vehicle.Picture);
            Assert.AreEqual("WBAVL1C50EVR93551", vehicle.VIN);
            Assert.AreEqual(1, vehicle.ModelID);
            Assert.AreEqual(3, vehicle.ColorID);
            Assert.AreEqual(1, vehicle.TransmissionID);
            Assert.AreEqual(2, vehicle.InteriorID);
            //break
            Assert.AreEqual(1, vehicle.MakeID);
            Assert.AreEqual(3, vehicle.BodyID);
            Assert.AreEqual("Chevy", vehicle.MakeName);
            Assert.AreEqual("Corvette", vehicle.ModelName);
            Assert.AreEqual(2, vehicle.InteriorID);
            Assert.AreEqual("Coupe", vehicle.BodyStyleName);
            Assert.AreEqual("Grey", vehicle.InteriorColor);
            Assert.AreEqual("Automatic", vehicle.TransmissionType);
            Assert.AreEqual("Green", vehicle.ColorName);
        }

        [Test]
        public void CanGetMakeList()
        {
            var repo = new MakeRepositoryADO();
            var makes = repo.GetMakes().ToList();

            Assert.AreEqual(5, makes.Count());
            Assert.AreEqual(1, makes[0].MakeID);
            Assert.AreEqual("Chevy", makes[0].MakeName);
            Assert.AreEqual("1970-04-15", makes[0].MakeDateAdded.ToString("yyyy-MM-dd"));
            Assert.AreEqual("test@test.com", makes[0].Email);
            Assert.AreEqual("00000000-0000-0000-0000-000000000000", makes[0].UserID);
        }

        [Test]
        public void CanGetModelList()
        {
            var repo = new ModelRepositoryADO();
            var models = repo.GetModels().ToList();

            Assert.AreEqual(5, models.Count());
            Assert.AreEqual(1, models[0].MakeID);
            Assert.AreEqual(3, models[2].ModelID);
            Assert.AreEqual("Pontiac", models[3].MakeName);
            Assert.AreEqual("F150", models[2].ModelName);
            Assert.AreEqual("1999-11-05", models[1].ModelDateAdded.ToString("yyyy-MM-dd"));
            Assert.AreEqual("test2@test.com", models[2].Email);
            Assert.AreEqual("00000000-1111-1111-0000-000000000000", models[4].UserID);
        }

        [Test]
        public void CanGetNewInventory()
        {
            var repo = new InventoryRepositoryADO();
            var newList = repo.GetNewInventory().ToList();

            Assert.AreEqual(3, newList.Count());
            Assert.AreEqual(1, newList[0].MakeID);
            Assert.AreEqual(3, newList[2].ModelID);
            Assert.AreEqual("Chevy", newList[1].MakeName);
            Assert.AreEqual("F150", newList[2].ModelName);
            Assert.AreEqual(1, newList[0].Count);
            Assert.AreEqual(2017, newList[2].Year);
            Assert.AreEqual(11975, newList[1].StockValue);
        }

        [Test]
        public void CanGetUsedInventory()
        {
            var repo = new InventoryRepositoryADO();
            var usedList = repo.GetUsedInventory().ToList();

            Assert.AreEqual(5, usedList.Count());
            Assert.AreEqual(2, usedList[0].MakeID);
            Assert.AreEqual(5, usedList[2].ModelID);
            Assert.AreEqual("Chevy", usedList[1].MakeName);
            Assert.AreEqual("Aura", usedList[2].ModelName);
            Assert.AreEqual(1, usedList[0].Count);
            Assert.AreEqual(2007, usedList[2].Year);
            Assert.AreEqual(8564, usedList[1].StockValue);
        }

        [Test]
        public void CanGetSingleSpecial()
        {
            var repo = new SpecialsRepositoryADO();
            var special = repo.GetByID(1);

            //(VehicleID, Year, Mileage, MSRP, UserID, SalesPrice, [Description], Picture, Featured, VIN, ModelID, ColorID, TypeID, TransmissionID, InteriorID)
            //(1, 2017, 0, 55450, '00000000-1111-1111-0000-000000000000', 52980, 'Great car, makes you feel alive!', null, 1, 'WBAVL1C50EVR93551', 1, 3, 1, 1, 2), --corvette

            Assert.AreEqual(1, special.SpecialID);
            Assert.AreEqual("Two for One Deal", special.SpecialTitle);
            Assert.AreEqual("Buy one, Get one doesnt just apply to the simple shopping. Come get one car and get a second for free!", special.SpecialDescription);
        }

        [Test]
        public void CanDeleteSpecial()
        {
            Specials specialToAdd = new Specials();
            var repo = new SpecialsRepositoryADO();


            specialToAdd.SpecialTitle = "Test";
            specialToAdd.SpecialDescription = "Test description";

            repo.Insert(specialToAdd);

            var loaded = repo.GetByID(5);
            Assert.IsNotNull(loaded);

            repo.Delete(5);

            loaded = repo.GetByID(5);
            Assert.IsNull(loaded);
        }

        [Test]
        public void CanGetUserList()
        {
            var repo = new UserRepositoryADO();
            var userList = repo.GetAll().ToList();

            Assert.AreEqual(2, userList.Count());
        }

        //[Test]
        //public void CanChangePassword()
        //{

        //}

        //[Test]
        //public void CanEditUser()
        //{

        //}

        //[Test]
        //public void CanAddUser()
        //{

        //}
    }
}
