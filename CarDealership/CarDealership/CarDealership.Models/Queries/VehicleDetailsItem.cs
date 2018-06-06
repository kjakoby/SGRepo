using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class VehicleDetailsItem
    {
        public int VehicleID { get; set; }
        public int MakeID { get; set; }
        public int ModelID { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public int Year { get; set; }
        public int BodyID { get; set; }
        public string BodyStyleName { get; set; }
        public int InteriorID { get; set; }
        public string InteriorColor { get; set; }
        public int TransmissionID { get; set; }
        public string TransmissionType { get; set; }
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public int ColorID { get; set; }
        public string ColorName { get; set; }
        public int Mileage { get; set; }
        public string VIN { get; set; }
        public int MSRP { get; set; }
        public int SalesPrice { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
    }
}
