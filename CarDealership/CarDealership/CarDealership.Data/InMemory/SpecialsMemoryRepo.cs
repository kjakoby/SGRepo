using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models.Tables;
using CarDealership.Models.Queries;

namespace CarDealership.Data.InMemory
{
    public class SpecialsMemoryRepo : ISpecialsRepository
    {
        public void Delete(int specialID)
        {
            throw new NotImplementedException();
        }

        public List<Specials> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SpecialsItem> GetList()
        {
            throw new NotImplementedException();
        }

        public void Insert(Specials specials)
        {
            throw new NotImplementedException();
        }
    }
}
