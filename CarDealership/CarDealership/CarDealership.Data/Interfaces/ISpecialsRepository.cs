using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interfaces
{
    public interface ISpecialsRepository
    {
        List<Specials> GetAll();
        void Insert(Specials specials);
        void Delete(int specialID);
        IEnumerable<SpecialsItem> GetList();
    }
}
