﻿using CarDealership.Data.ADO;
using CarDealership.Data.InMemory;
using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Factories
{
    public static class VehicleRepoFactory
    {
        public static IVehicleRepository GetRepository()
        {
            switch (Settings.GetRepoMode())
            {
                case "QA":
                    return new VehicleMemoryRepo();
                case "PROD":
                    return new VehicleRepositoryADO();
                default:
                    throw new Exception("Could not find valid Mode configuration value.");
            }
        }
    }
}
