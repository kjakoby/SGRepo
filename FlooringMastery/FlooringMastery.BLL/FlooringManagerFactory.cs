using FlooringMastery.Data;
using FlooringMastery.Data.TestRepositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.BLL
{
    public static class FlooringManagerFactory
    {
        public static FlooringManager Create(DateTime date)
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new FlooringManager(new OrdersTestRepository(), new ProductsTestRepository(), new TaxesTestRepository());
                case "Prod":
                    return new FlooringManager(new FileOrderRepository(date), new FileProductRepository(), new FileTaxRepository());
                default:
                    throw new Exception("Mode value in app.config is not valid");
            }
        }
    }
}
