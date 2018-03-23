using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetterFactorizor.BLL;

namespace BetterFactorizor.Tests
{
    [TestFixture]
    public class WorkManagerTests
    {
        [Test]
        public void SixIsPerfectTest()
        {
            WorkManager testInstance = new WorkManager();
            testInstance.Start();

            PerfectChecker actual = testInstance.ProcessPerfect(6);
            Assert.AreEqual(true, actual.IsPerfect);
        }

        [Test]
        public void SevenIsPrimeTest()
        {
            WorkManager testInstance = new WorkManager();
            testInstance.Start();

            PrimeChecker actual = testInstance.ProcessPrime(7);
            Assert.AreEqual(true, actual.IsPrime);

        }
    }
}
