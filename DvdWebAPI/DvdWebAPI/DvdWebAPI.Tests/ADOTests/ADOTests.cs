using DvdWebAPI.Data.ADO;
using DvdWebAPI.Models.Queries;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdWebAPI.Tests.ADOTests
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
        public void ADOCanGetAllDvds()
        {
            var repo = new DvdRepoADO();
            var dvds = repo.GetAll().ToList();

            Assert.AreEqual(6, dvds.Count());
            Assert.AreEqual(3, dvds[2].DvdID);
            Assert.AreEqual("HellBoy", dvds[2].Title);
            Assert.AreEqual(2004, dvds[2].Year);
            Assert.AreEqual("Guillermo Del Toro", dvds[2].DirectorName);
            Assert.AreEqual("R", dvds[2].RatingValue);
            Assert.AreEqual("Its time to light the lights.", dvds[2].Note);
            Assert.AreEqual(2, dvds[2].DirectorID);
            Assert.AreEqual(4, dvds[2].RatingID);
            Assert.AreEqual(3, dvds[2].ReleaseID);

        }

        [Test]
        public void ADOCanGetDvdByID()
        {
            var repo = new DvdRepoADO();
            var dvd = repo.GetByID(6);

            Assert.AreEqual(6, dvd.DvdID);
            Assert.AreEqual("Pumpkinhead 2", dvd.Title);
            Assert.AreEqual(1993, dvd.Year);
            Assert.AreEqual("Jeff Burr", dvd.DirectorName);
            Assert.AreEqual("R", dvd.RatingValue);
            Assert.AreEqual(null, dvd.Note);
            Assert.AreEqual(1, dvd.DirectorID);
            Assert.AreEqual(4, dvd.RatingID);
            Assert.AreEqual(5, dvd.ReleaseID);
        }

        [Test]
        public void ADOInvalidDvdIDReturnsNull()
        {
            var repo = new DvdRepoADO();
            var dvd = repo.GetByID(20000000);

            Assert.IsNull(dvd);
        }

        [Test]
        public void ADOCanGetDvdsByTitle()
        {
            var repo = new DvdRepoADO();
            var dvds = repo.GetByTitle("e").ToList();

            Assert.AreEqual(4, dvds.Count());
            Assert.AreEqual(3, dvds[1].DvdID);
            Assert.AreEqual("HellBoy", dvds[1].Title);
            Assert.AreEqual(2004, dvds[1].Year);
            Assert.AreEqual("Guillermo Del Toro", dvds[1].DirectorName);
            Assert.AreEqual("R", dvds[1].RatingValue);
            Assert.AreEqual("Its time to light the lights.", dvds[1].Note);
            Assert.AreEqual(2, dvds[1].DirectorID);
            Assert.AreEqual(4, dvds[1].RatingID);
            Assert.AreEqual(3, dvds[1].ReleaseID);
        }

        [Test]
        public void ADOCanGetDvdsByYear()
        {
            var repo = new DvdRepoADO();
            var dvds = repo.GetByYear(201).ToList();

            Assert.AreEqual(2, dvds.Count());
            Assert.AreEqual(2, dvds[0].DvdID);
            Assert.AreEqual("Pacific Rim", dvds[0].Title);
            Assert.AreEqual(2013, dvds[0].Year);
            Assert.AreEqual("Guillermo Del Toro", dvds[0].DirectorName);
            Assert.AreEqual("PG-13", dvds[0].RatingValue);
            Assert.AreEqual("Well we are moving on up to the east side.", dvds[0].Note);
            Assert.AreEqual(2, dvds[0].DirectorID);
            Assert.AreEqual(3, dvds[0].RatingID);
            Assert.AreEqual(2, dvds[0].ReleaseID);
        }

        [Test]
        public void ADOCanGetDvdsByDirector()
        {
            var repo = new DvdRepoADO();
            var dvds = repo.GetByDirector("Del").ToList();

            Assert.AreEqual(2, dvds.Count());
            Assert.AreEqual(3, dvds[1].DvdID);
            Assert.AreEqual("HellBoy", dvds[1].Title);
            Assert.AreEqual(2004, dvds[1].Year);
            Assert.AreEqual("Guillermo Del Toro", dvds[1].DirectorName);
            Assert.AreEqual("R", dvds[1].RatingValue);
            Assert.AreEqual("Its time to light the lights.", dvds[1].Note);
            Assert.AreEqual(2, dvds[1].DirectorID);
            Assert.AreEqual(4, dvds[1].RatingID);
            Assert.AreEqual(3, dvds[1].ReleaseID);
        }

        [Test]
        public void ADOCanGetDvdsByRating()
        {
            var repo = new DvdRepoADO();
            var dvds = repo.GetByRating("-").ToList();

            Assert.AreEqual(3, dvds.Count());
            Assert.AreEqual(4, dvds[1].DvdID);
            Assert.AreEqual("Ready Player One", dvds[1].Title);
            Assert.AreEqual(2018, dvds[1].Year);
            Assert.AreEqual("Steven Spielberg", dvds[1].DirectorName);
            Assert.AreEqual("PG-13", dvds[1].RatingValue);
            Assert.AreEqual("Its time to play the music.", dvds[1].Note);
            Assert.AreEqual(3, dvds[1].DirectorID);
            Assert.AreEqual(3, dvds[1].RatingID);
            Assert.AreEqual(4, dvds[1].ReleaseID);
        }

        [Test]
        public void ADOCanAddDvd()
        {
            var repo = new DvdRepoADO();
            var dvdToAdd = new DvdDetails();

            dvdToAdd.Title = "Test";
            dvdToAdd.Year = 2020;
            dvdToAdd.Note = "Test, test";
            dvdToAdd.DirectorName = "Tester";
            dvdToAdd.RatingValue = "X";
            //dvdToAdd.DirectorID = 15;
            //dvdToAdd.RatingID = 15;
            //dvdToAdd.ReleaseID = 15;

            repo.Insert(dvdToAdd);

            Assert.AreEqual(7, dvdToAdd.DvdID);
            Assert.AreEqual("Test", dvdToAdd.Title);
            Assert.AreEqual(2020, dvdToAdd.Year);
            Assert.AreEqual("Tester", dvdToAdd.DirectorName);
            Assert.AreEqual("X", dvdToAdd.RatingValue);
            Assert.AreEqual("Test, test", dvdToAdd.Note);
            //Assert.AreEqual(4, dvdToAdd.DirectorID);
            //Assert.AreEqual(6, dvdToAdd.RatingID);
            //Assert.AreEqual(6, dvdToAdd.ReleaseID);
        }

        [Test]
        public void ADOCanEditDvd()
        {
            var repo = new DvdRepoADO();
            var dvdToAdd = new DvdDetails();

            dvdToAdd.Title = "Test";
            dvdToAdd.Year = 2020;
            dvdToAdd.Note = "Test, test";
            dvdToAdd.DirectorName = "Tester";
            dvdToAdd.RatingValue = "X";
            //dvdToAdd.DirectorID = 15;
            //dvdToAdd.RatingID = 15;
            //dvdToAdd.ReleaseID = 15;

            repo.Insert(dvdToAdd);

            dvdToAdd.Title = "Test2";
            dvdToAdd.Year = 2022;
            dvdToAdd.Note = "Test, test2";
            dvdToAdd.DirectorName = "Tester2";
            dvdToAdd.RatingValue = "X2";

            repo.Update(dvdToAdd);

            Assert.AreEqual(7, dvdToAdd.DvdID);
            Assert.AreEqual("Test2", dvdToAdd.Title);
            Assert.AreEqual(2022, dvdToAdd.Year);
            Assert.AreEqual("Tester2", dvdToAdd.DirectorName);
            Assert.AreEqual("X2", dvdToAdd.RatingValue);
            Assert.AreEqual("Test, test2", dvdToAdd.Note);
        }

        [Test]
        public void ADOCanDeleteDvd()
        {
            var repo = new DvdRepoADO();
            var dvdToAdd = new DvdDetails();

            dvdToAdd.Title = "Test";
            dvdToAdd.Year = 2020;
            dvdToAdd.Note = "Test, test";
            dvdToAdd.DirectorName = "Tester";
            dvdToAdd.RatingValue = "X";
            //dvdToAdd.DirectorID = 15;
            //dvdToAdd.RatingID = 15;
            //dvdToAdd.ReleaseID = 15;

            repo.Insert(dvdToAdd);

            var loaded = repo.GetByID(7);
            Assert.IsNotNull(loaded);

            repo.Delete(7);
            loaded = repo.GetByID(7);

            Assert.IsNull(loaded);
        }
    }
}
