using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TractorDex.BLL.Data;
using TractorDex.BLL.Models;

namespace TractorDex.Tests
{
    
    [TestFixture]
    class TractorRepoTests
    {
        private TractorRepository _testRepo;
        [SetUp]
        public void Init()
        {
            _testRepo = new TractorRepository();
            _testRepo.SetupRepo();
        }
        [Test]
        public void CanGetTractor()
        {
            Tractor actual =_testRepo.GetTractor(1);
            Assert.AreEqual("Johnny Reb", actual.Name);
            Assert.AreEqual("Kenny Webb", actual.Driver);
            Assert.AreEqual(9990, actual.Weight);
        }

        [Test]
        public void CanGetAllTractors()
        {
            Dictionary<int, Tractor> actual = _testRepo.GetAllTractors();
            Assert.AreEqual(4, actual.LongCount());
        }

        [Test]
        public void CanDeleteTractor()
        {
            Tractor actual =_testRepo.DeleteTractor(1);
            Assert.AreEqual("Johnny Reb", actual.Name);

            actual = _testRepo.DeleteTractor(42);
            Assert.IsNull(actual);
        }
        [Test]
        public void CanAddTractor()
        {
            Tractor newTractor = new Tractor()
            {
                Name = "Dixie Binder",
                Driver = "Hambone",
                Weight = 10100
            };

            Assert.IsTrue(_testRepo.AddTractor(newTractor));
            Tractor actual = _testRepo.GetTractorByName("Dixie Binder");
            Assert.AreEqual("Hambone", actual.Driver);
        }
        [Test]
        public void CanUpdateTractor()
        {
            Tractor original = _testRepo.GetTractorByName("Johnny Reb");
            Tractor currentTractor = new Tractor() {
                Name = original.Name,
                Driver = original.Driver,
                Weight = original.Weight
            };
            currentTractor.Name = "Honest John";
            Tractor actual = _testRepo.UpdateTractor(original, currentTractor);

            Assert.AreEqual(currentTractor.Driver, actual.Driver);
        }
        [Test]
        public void CanUpdateTractorByKey()
        {
            Tractor original = _testRepo.GetTractor(1);
            Tractor currentTractor = new Tractor()
            {
                Name = original.Name,
                Driver = original.Driver,
                Weight = original.Weight
            };
            currentTractor.Name = "Honest John";
            Tractor actual = _testRepo.UpdateTractor(1, currentTractor);
            Assert.AreEqual(currentTractor.Driver, actual.Driver);
            var Tractors = _testRepo.GetAllTractors();
            Assert.AreEqual(currentTractor.Name, Tractors[1].Name);
        }
    }
}
