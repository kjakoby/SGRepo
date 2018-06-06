using DvdWebAPI.Data.EF;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdWebAPI.Tests.EFTests
{
    [TestFixture]
    public class EFTests
    {
        [Test]
        public void EFCanGetAllDvds()
        {
            var repo = new DvdRepoEF();
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
        public void EFCanGetDvdByID()
        {
            var repo = new DvdRepoEF();
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
        public void EFInvalidDvdIDReturnsNull()
        {
            var repo = new DvdRepoEF();
            var dvd = repo.GetByID(20000000);

            Assert.IsNull(dvd);
        }

        [Test]
        public void EFCanGetDvdsByDirector()
        {
            var repo = new DvdRepoEF();
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
        public void EFCanGetDvdsByRating()
        {
            var repo = new DvdRepoEF();
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
        public void EFCanGetDvdsByYear()
        {
            var repo = new DvdRepoEF();
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
        public void EFCanGetDvdsByTitle()
        {
            var repo = new DvdRepoEF();
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
    }
}
