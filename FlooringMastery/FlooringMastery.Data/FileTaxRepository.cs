using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data
{
    public class FileTaxRepository :ITaxRepository
    {
        private Dictionary<string, Tax> _taxIndex;
        private const string taxFile = @"D:\SoftwareGuild\LocalDataFiles\FlooringMastery\Medium\taxes.txt";

        public FileTaxRepository()
        {
            _taxIndex = new Dictionary<string, Tax>();
            if (!File.Exists(taxFile))
            {
                File.Create(taxFile);
            }
            else
            {
                using (StreamReader reader = new StreamReader(taxFile))
                {
                    reader.ReadLine();
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        Tax tax = new Tax();
                        string[] values = line.Split(',');
                        if (values.Length >= 3)
                        {
                            string key = values[0];
                            string stateName = (values[1]);
                            decimal taxRate = decimal.Parse(values[2]);

                            _taxIndex.Add(key, new Tax()
                            {
                                StateAbbreviation = key,
                                StateName = stateName,
                                TaxRate = taxRate
                            });

                        }
                    }
                }
            }
        }

        public void CloseRepo()
        {
            using (StreamWriter writer = new StreamWriter(taxFile))
            {
                foreach (KeyValuePair<string, Tax> kv in _taxIndex)
                {
                    if (kv.Value != null)
                    {
                        writer.WriteLine($"{kv.Key},{kv.Value.StateName},{kv.Value.TaxRate}");
                    }
                }
            }
        }

        public Tax GetOrderTax(string stateChosen)
        {
            if (_taxIndex.Keys.Contains(stateChosen))
            {
                return _taxIndex[stateChosen];
            }
            else
            {
                return null;
            }
        }

        //public Tax LoadTax(string stateAbbreviation)
        //{
        //    throw new NotImplementedException();
        //}

        public void SaveTax(Tax tax)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, Tax> GetAllTaxes()
        {
            return _taxIndex;
        }
    }
}
