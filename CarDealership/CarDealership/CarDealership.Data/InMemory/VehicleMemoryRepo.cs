using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;

namespace CarDealership.Data.InMemory
{
    public class VehicleMemoryRepo : IVehicleRepository
    {
        public void Delete(int vehicleID)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetAll()
        {
            throw new NotImplementedException();
        }

        public Vehicle GetByID(int vehicleID)
        {
            throw new NotImplementedException();
        }

        public VehicleDetailsItem GetDetails(int vehicleID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FeaturedItem> GetFeatured()
        {
            throw new NotImplementedException();
        }

        public void Insert(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public void Update(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
