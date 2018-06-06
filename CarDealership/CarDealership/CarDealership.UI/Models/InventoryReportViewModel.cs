using CarDealership.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class InventoryReportViewModel
    {
        public List<InventoryReportItem> NewInventory { get; set; }
        public List<InventoryReportItem> UsedInventory { get; set; }
    }
}