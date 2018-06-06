using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models.Tables;

namespace CarDealership.Data.InMemory
{
    public class TransmissionMemoryRepo : ITransmissionRepository
    {
        public List<Transmission> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
