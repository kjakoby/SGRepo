﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interfaces
{
    public interface ITypeRepository
    {
        List<Models.Tables.Type> GetAll();
    }
}
