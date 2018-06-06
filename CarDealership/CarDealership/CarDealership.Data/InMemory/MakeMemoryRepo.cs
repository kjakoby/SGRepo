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
    public class MakeMemoryRepo : IMakeRepository
    {
        public List<Make> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MakeItem> GetMakes()
        {
            throw new NotImplementedException();
        }

        public void Insert(Make make)
        {
            throw new NotImplementedException();
        }
    }
}
