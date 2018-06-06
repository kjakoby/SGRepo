using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interfaces
{
    public interface IVehicleRepository
    {
        List<Vehicle> GetAll();
        Vehicle GetByID(int vehicleID);
        void Insert(Vehicle vehicle);
        void Update(Vehicle vehicle);
        void Delete(int vehicleID);
        IEnumerable<FeaturedItem> GetFeatured();
        VehicleDetailsItem GetDetails(int vehicleID);
    }
}
