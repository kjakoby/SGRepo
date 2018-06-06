using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models.Tables;

namespace CarDealership.Data.InMemory
{
    public class ContactMemoryRepo : IContactRepository
    {
        public List<Contact> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
