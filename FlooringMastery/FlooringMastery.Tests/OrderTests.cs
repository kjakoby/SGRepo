using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Tests
{
    [TestFixture]
    public class OrderTests
    {
        [Test]
        public void CanLoadOrderTestData()
        {
            DateTime orderDate = DateTime.Now;
            FlooringManager manager = FlooringManagerFactory.Create(orderDate);

            DisplaySingleResponse response = manager.LookupOrder(1,(DateTime.Now));

            Assert.IsNotNull(response.Order);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(1, response.Order.OrderNumber);
        }
    }
}
