using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models.Tables;

namespace CarDealership.Data.InMemory
{
    public class PurchaseMemoryRepo : IPurchaseRepository
    {
        public List<Purchase> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Purchase purchase)
        {
            throw new NotImplementedException();
        }
    }
}
