using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models.Tables;

namespace CarDealership.Data.InMemory
{
    public class ModelMemoryRepo : IModelRepository
    {
        public List<Model> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Model model)
        {
            throw new NotImplementedException();
        }
    }
}
