using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models.Queries;

namespace CarDealership.Data.InMemory
{
    public class InventoryMemoryRepo : IInventoryRepository
    {
        public IEnumerable<InventoryReportItem> GetNewInventory()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InventoryReportItem> GetUsedInventory()
        {
            throw new NotImplementedException();
        }
    }
}
