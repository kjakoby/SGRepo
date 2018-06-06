using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Tables
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public string SellName { get; set; }
        public string SellPhone { get; set; }
        public string SellEmail { get; set; }
        public string SellStreet1 { get; set; }
        public string SellStreet2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public int PurchasePrice { get; set; }
        public int PurchaseTypeID { get; set; }
        public string UserID { get; set; }
        public int VehicleID { get; set; }
    }
}
