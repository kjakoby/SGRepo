using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models.Tables;

namespace CarDealership.Data.InMemory
{
    public class PurchaseTypeMemoryRepo : IPurchaseTypeRepository
    {
        public List<PurchaseType> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
