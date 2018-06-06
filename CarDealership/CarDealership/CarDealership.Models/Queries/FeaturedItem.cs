using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class FeaturedItem
    {
        //public int MakeID { get; set; }
        //public int ModelID { get; set; }
        public int VehicleID { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public int SalesPrice { get; set; }
        public string Picture { get; set; }
        public int Year { get; set; }
    }
}
