using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.Data.TestRepositories
{
    public class ProductsTestRepository : IProductRepository
    {
        private static Product _product = new Product
        {
            ProductType = "Wood",
            CostPerSquareFoot = 5.15M,
            LaborCostPerSquareFoot = 4.75M
        };

        public Dictionary<string, Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Product GetOrderProd(string orderChosen)
        {
            throw new NotImplementedException();
        }

        public Product LoadProduct(string productType)
        {
            if (_product.ProductType == productType)
            {
                return _product;
            }
            else
            {
                return null;
            }
        }

        public void SaveProduct(Product product)
        {
            _product = product;
        }
    }
}
