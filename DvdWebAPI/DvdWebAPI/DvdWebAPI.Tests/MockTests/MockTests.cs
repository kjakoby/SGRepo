using DvdWebAPI.Data.Mock;
using DvdWebAPI.Models.Queries;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdWebAPI.Tests.MockTests
{
    [TestFixture]
    public class MockTests
    {
        //[SetUp]
        //public void Init()
        //{

        //}

        [Test]
        public void MockCanGetAllDvds()
        {
            var repo = new DvdRepoMock();
            var dvds = repo.GetAll().ToList();

            Assert.AreEqual(4, dvds.Count());
            Assert.AreEqual(3, dvds[2].DvdID);
            Assert.AreEqual("HellBoy", dvds[2].Title);
            Assert.AreEqual(2004, dvds[2].Year);
            Assert.AreEqual("Guillermo Del Toro", dvds[2].DirectorName);
            Assert.AreEqual("PG-13", dvds[2].RatingValue);
            Assert.AreEqual("Who knew a devil like creature would be a good guy!", dvds[2].Note);
            Assert.AreEqual(2, dvds[2].DirectorID);
            Assert.AreEqual(2, dvds[2].RatingID);
            Assert.AreEqual(3, dvds[2].ReleaseID);

        }

        [Test]
        public void MockCanGetDvdByID()
        {
            var repo = new DvdRepoMock();
            var dvd = repo.GetByID(2);

            Assert.AreEqual(2, dvd.DvdID);
            Assert.AreEqual("Pacific Rim", dvd.Title);
            Assert.AreEqual(2013, dvd.Year);
            Assert.AreEqual("Guillermo Del Toro", dvd.DirectorName);
            Assert.AreEqual("PG-13", dvd.RatingValue);
            Assert.AreEqual("Action packed, giant robot vs. monster battle!", dvd.Note);
            Assert.AreEqual(2, dvd.DirectorID);
            Assert.AreEqual(2, dvd.RatingID);
            Assert.AreEqual(2, dvd.ReleaseID);
        }

        [Test]
        public void MockInvalidDvdIDReturnsNull()
        {
            var repo = new DvdRepoMock();
            var dvd = repo.GetByID(20000000);

            Assert.IsNull(dvd);
        }

        [Test]
        public void MockCanGetDvdsByTitle()
        {
            var repo = new DvdRepoMock();
            var dvds = repo.GetByTitle("e").ToList();

            Assert.AreEqual(3, dvds.Count());
            Assert.AreEqual(3, dvds[1].DvdID);
            Assert.AreEqual("HellBoy", dvds[1].Title);
            Assert.AreEqual(2004, dvds[1].Year);
            Assert.AreEqual("Guillermo Del Toro", dvds[1].DirectorName);
            Assert.AreEqual("PG-13", dvds[1].RatingValue);
            Assert.AreEqual("Who knew a devil like creature would be a good guy!", dvds[1].Note);
            Assert.AreEqual(2, dvds[1].DirectorID);
            Assert.AreEqual(2, dvds[1].RatingID);
            Assert.AreEqual(3, dvds[1].ReleaseID);
        }

        [Test]
        public void MockCanGetDvdsByYear()
        {
            var repo = new DvdRepoMock();
            var dvds = repo.GetByYear(201).ToList();

            Assert.AreEqual(2, dvds.Count());
            Assert.AreEqual(2, dvds[0].DvdID);
            Assert.AreEqual("Pacific Rim", dvds[0].Title);
            Assert.AreEqual(2013, dvds[0].Year);
            Assert.AreEqual("Guillermo Del Toro", dvds[0].DirectorName);
            Assert.AreEqual("PG-13", dvds[0].RatingValue);
            Assert.AreEqual("Action packed, giant robot vs. monster battle!", dvds[0].Note);
            Assert.AreEqual(2, dvds[0].DirectorID);
            Assert.AreEqual(2, dvds[0].RatingID);
            Assert.AreEqual(2, dvds[0].ReleaseID);
        }

        [Test]
        public void MockCanGetDvdsByDirector()
        {
            var repo = new DvdRepoMock();
            var dvds = repo.GetByDirector("Del").ToList();

            Assert.AreEqual(2, dvds.Count());
            Assert.AreEqual(3, dvds[1].DvdID);
            Assert.AreEqual("HellBoy", dvds[1].Title);
            Assert.AreEqual(2004, dvds[1].Year);
            Assert.AreEqual("Guillermo Del Toro", dvds[1].DirectorName);
            Assert.AreEqual("PG-13", dvds[1].RatingValue);
            Assert.AreEqual("Who knew a devil like creature would be a good guy!", dvds[1].Note);
            Assert.AreEqual(2, dvds[1].DirectorID);
            Assert.AreEqual(2, dvds[1].RatingID);
            Assert.AreEqual(3, dvds[1].ReleaseID);
        }

        [Test]
        public void MockCanGetDvdsByRating()
        {
            var repo = new DvdRepoMock();
            var dvds = repo.GetByRating("-").ToList();

            Assert.AreEqual(3, dvds.Count());
            Assert.AreEqual(3, dvds[1].DvdID);
            Assert.AreEqual("HellBoy", dvds[1].Title);
            Assert.AreEqual(2004, dvds[1].Year);
            Assert.AreEqual("Guillermo Del Toro", dvds[1].DirectorName);
            Assert.AreEqual("PG-13", dvds[1].RatingValue);
            Assert.AreEqual("Who knew a devil like creature would be a good guy!", dvds[1].Note);
            Assert.AreEqual(2, dvds[1].DirectorID);
            Assert.AreEqual(2, dvds[1].RatingID);
            Assert.AreEqual(3, dvds[1].ReleaseID);
        }

        //[Test]
        //public void MockCanAddDvd()
        //{
        //    var repo = new DvdRepoMock();
        //    var dvdToAdd = new DvdDetails();

        //    dvdToAdd.Title = "Test";
        //    dvdToAdd.Year = 2018;
        //    dvdToAdd.Director = "Mr. Test Test";
        //    dvdToAdd.Rating = "NR";
        //    dvdToAdd.Note = "This is a test";

        //    repo.Insert(dvdToAdd);

        //    Assert.AreEqual(5, dvdToAdd.DvdID);
        //    Assert.AreEqual("Test", dvdToAdd.Title);
        //    Assert.AreEqual(2018, dvdToAdd.Year);
        //    Assert.AreEqual("Mr. Test Test", dvdToAdd.Director);
        //    Assert.AreEqual("NR", dvdToAdd.Rating);
        //    Assert.AreEqual("This is a test", dvdToAdd.Note);
        //}

        //[Test]
        //public void MockCanEditDvd()
        //{

        //}

        //[Test]
        //public void MockCanDeleteDvd()
        //{

        //}
    }
}
