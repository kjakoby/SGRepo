using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.Data.TestRepositories
{
    public class TaxesTestRepository : ITaxRepository
    {
        private static Tax _tax = new Tax
        {
            StateAbbreviation = "OH",
            StateName = "Ohio",
            TaxRate = 6.25M
        };

        public Dictionary<string, Tax> GetAllTaxes()
        {
            throw new NotImplementedException();
        }

        public Tax GetOrderTax(string stateChosen)
        {
            throw new NotImplementedException();
        }

        public Tax LoadTax(string stateAbbreviation)
        {
            if (_tax.StateAbbreviation == stateAbbreviation)
            {
                return _tax;
            }
            else
            {
                return null;
            }
        }

        public void SaveTax(Tax tax)
        {
            _tax = tax;
        }
    }
}
