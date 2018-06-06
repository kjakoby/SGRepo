using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class InventoryReportItem
    {
        public int MakeID { get; set; }
        public int ModelID { get; set; }
        //public int VehicleID { get; set; }
        public int Year { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public int Count { get; set; }
        public int StockValue { get; set; }
    }
}
