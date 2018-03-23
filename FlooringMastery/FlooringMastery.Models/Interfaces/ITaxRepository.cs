using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Interfaces
{
    public interface ITaxRepository
    {
        //Tax LoadTax(string stateAbbreviation);
        Dictionary<string, Tax> GetAllTaxes();
        void SaveTax(Tax tax);
        Tax GetOrderTax(string stateChosen);
    }
}
