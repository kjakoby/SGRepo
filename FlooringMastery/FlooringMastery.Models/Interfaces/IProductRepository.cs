using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Interfaces
{
    public interface IProductRepository
    {
        //Product LoadProduct(string productType);
        //void SaveProduct(Product product);
        Dictionary<string, Product> GetAllProducts();
        Product GetOrderProd(string orderChosen/*, Order currentOrder*/);
    }
}
