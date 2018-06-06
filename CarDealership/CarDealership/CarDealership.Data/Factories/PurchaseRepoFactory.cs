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
    public static class PurchaseRepoFactory
    {
        public static IPurchaseRepository GetRepository()
        {
            switch (Settings.GetRepoMode())
            {
                case "QA":
                    return new PurchaseMemoryRepo();
                case "PROD":
                    return new PurchaseRepositoryADO();
                default:
                    throw new Exception("Could not find valid Mode configuration value.");
            }
        }
    }
}
