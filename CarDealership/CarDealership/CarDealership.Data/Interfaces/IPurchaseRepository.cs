using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interfaces
{
    public interface IPurchaseRepository
    {
        List<Purchase> GetAll();
        void Insert(Purchase purchase);
    }
}
