using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Data.Interfaces;
using CarDealership.Models.Tables;

namespace CarDealership.Data.InMemory
{
    public class ColorMemoryRepo : IColorRepository
    {
        public List<Color> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
