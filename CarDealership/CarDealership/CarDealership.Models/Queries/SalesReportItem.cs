using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class SalesReportItem
    {
        public string UserID { get; set; }
        //public int VehicleID { get; set; }
        public int PurchaseID { get; set; }
        public string User { get; set; }
        public int TotalSales { get; set; }
        public int TotalVehicles { get; set; }
    }
}
