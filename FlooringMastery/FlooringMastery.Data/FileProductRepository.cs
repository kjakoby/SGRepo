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
    public class FileProductRepository : IProductRepository
    {
        private Dictionary<string, Product> _productIndex;
        private const string prodFile = @"D:\SoftwareGuild\LocalDataFiles\FlooringMastery\Medium\Products.txt";

        public FileProductRepository()
        {
            _productIndex = new Dictionary<string, Product>(/*StringComparer.InvariantCultureIgnoreCase*/);
            if (!File.Exists(prodFile))
            {
                File.Create(prodFile);
            }
            else
            {
                using (StreamReader reader = new StreamReader(prodFile))
                {
                    reader.ReadLine();
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        Product product = new Product();
                        string[] values = line.Split(',');
                        if (values.Length >= 3)
                        {
                            string prodType = values[0];
                            string key = values[0].ToLower();
                            decimal cost = decimal.Parse(values[1]);
                            decimal labor = decimal.Parse(values[2]);

                            _productIndex.Add(key, new Product()
                            {
                                ProductType = prodType,
                                CostPerSquareFoot = cost,
                                LaborCostPerSquareFoot = labor
                            });

                        }
                    }
                }
            }
        }

        public void CloseRepo()
        {
            using (StreamWriter writer = new StreamWriter(prodFile))
            {
                foreach (KeyValuePair<string, Product> kv in _productIndex)
                {
                    if (kv.Value != null)
                    {
                        writer.WriteLine($"{kv.Value.ProductType},{kv.Value.CostPerSquareFoot},{kv.Value.LaborCostPerSquareFoot}");
                    }
                }
            }
        }

        public Dictionary<string, Product> GetAllProducts()
        {
            return _productIndex;
        }

        public Product GetOrderProd(string orderChosen/*, Order currentOrder*/)
        {
            if (_productIndex.Keys.Contains(orderChosen))
            {
                return _productIndex[orderChosen];
            }
            else
            {
                return null;
            }
        }

        //public Product LoadProduct(string productType)
        //{
        //    throw new NotImplementedException();
        //}

        //public void SaveProduct(Product product)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
