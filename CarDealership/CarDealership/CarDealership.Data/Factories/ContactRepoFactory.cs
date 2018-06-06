using CarDealership.Data.ADO;
using CarDealership.Data.InMemory;
using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Factories
{
    public static class ContactRepoFactory
    {
        public static IContactRepository GetRepository()
        {
            switch (Settings.GetRepoMode())
            {
                case "QA":
                    return new ContactMemoryRepo();
                case "PROD":
                    return new ContactRepositoryADO();
                default:
                    throw new Exception("Could not find valid Mode configuration value.");
            }
        }
    }
}
