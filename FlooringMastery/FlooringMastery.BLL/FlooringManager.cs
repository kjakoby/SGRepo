using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.BLL
{
    public class FlooringManager
    {
        public IOrderRepository orderRepository;
        public ITaxRepository taxRepository;
        public IProductRepository productRepository;

        public FlooringManager(IOrderRepository orderRepo, IProductRepository productRepo, ITaxRepository taxRepo)
        {
            orderRepository = orderRepo;
            productRepository = productRepo;
            taxRepository = taxRepo;
        }

        public FlooringManager(IOrderRepository orderRepo/*, IProductRepository productRepo, ITaxRepository taxRepo*/)
        {
            orderRepository = orderRepo;
            //productRepository = productRepo;
            //taxRepository = taxRepo;
        }

        public Dictionary<string, Tax> GetAllTaxes()
        {
            var sortedTaxes = taxRepository.GetAllTaxes().OrderBy(kv => kv.Key);
            return sortedTaxes.ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        public Dictionary<int, Order> GetAllOrders(DateTime date)
        {
            var sortedOrders = orderRepository.GetAllOrders(date).OrderBy(kv => kv.Key);
            return sortedOrders.ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        public Dictionary<string, Product> GetAllProducts()
        {
            var sortedProducts = productRepository.GetAllProducts().OrderBy(kv => kv.Key);
            return sortedProducts.ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        public DisplaySingleResponse GetOnlyOrder(DateTime date)
        {
            DisplaySingleResponse response = new DisplaySingleResponse();

            response.Order = orderRepository.GetLastOrder(date);

            if (response.Order == null)
            {
                Console.WriteLine();
                response.Success = false;
                //not sure how to get below text to use ConsoleIO.InvalidOrder
                //response.Message = $"{orderNumber} is not a valid order number!";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public DisplaySingleResponse LookupOrder(int orderNumber,DateTime date)
        {
            DisplaySingleResponse response = new DisplaySingleResponse();

            response.Order = orderRepository.GetSingleOrder(orderNumber,date);

            if (response.Order == null)
            {
                Console.WriteLine();
                response.Success = false;
                //not sure how to get below text to use ConsoleIO.InvalidOrder
                response.Message = $"{orderNumber} is not a valid order number!";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        //public AddOrderResponse AddOrder(string orderDate, string custName, string stateAbbrev, string prodType, decimal area)
        //{
        //    AddOrderResponse response = new AddOrderResponse();

        //    //response = AddOrder(response.Order, orderDate, custName, stateAbbrev, prodType, area);

        //    AddRule addOrderRule = new AddRule();

        //    response = addOrderRule.AddOrder(orderDate, custName, stateAbbrev, prodType, area);

        //    return response;
        //}

        public AddOrderResponse AddOrder(DateTime orderDate, string custName, string stateAbbrev, string prodType, decimal area, decimal taxRate, 
                                            decimal cost, decimal labor, decimal materialCost, decimal laborCost, decimal tax, decimal total, Product prodChosen)
        {
            AddOrderResponse response = new AddOrderResponse();
            Order order = new Order();
            response.Order = order;
            //need to get number by next avail order number
            //response.Order.OrderNumber = 3;
            response.Order.OrderDate = orderDate;
            response.Order.CustomerName = custName;
            response.Order.State = stateAbbrev;
            response.Order.ProductType = prodChosen.ProductType;
            response.Order.Area = area;
            //tax is where response stateAbbrev == tax.StateAbbrev
            //prod is where response.ProductType == product.productType
            response.Order.TaxRate = taxRate;
            response.Order.CostPerSquareFoot = cost;
            response.Order.LaborCostPerSquareFoot = labor;
            response.Order.LaborCost = laborCost;

            response.Order.MaterialCost = materialCost;
            //response.TaxRate = tax.TaxRate;
            response.Order.Tax = tax;
            response.Order.Total = total;
            return response;
        }

        //public Order EditOrder(int orderNumber, Order updatedOrder)
        //{

        //}

        public EditOrderResponse EditOrderResponse(DateTime orderDate, string custName, string stateAbbrev, string prodType, decimal area, decimal taxRate,
                                            decimal cost, decimal labor, decimal materialCost, decimal laborCost, decimal tax, decimal total)
        {
            EditOrderResponse response = new EditOrderResponse();
            Order order = new Order();
            response.Order = order;
            //need to get number by next avail order number
            //response.Order.OrderNumber = 3;
            response.Order.OrderDate = orderDate;
            response.Order.CustomerName = custName;
            response.Order.State = stateAbbrev;
            response.Order.ProductType = prodType;
            response.Order.Area = area;
            //tax is where response stateAbbrev == tax.StateAbbrev
            //prod is where response.ProductType == product.productType
            response.Order.TaxRate = taxRate;
            response.Order.CostPerSquareFoot = cost;
            response.Order.LaborCostPerSquareFoot = labor;
            response.Order.LaborCost = laborCost;

            response.Order.MaterialCost = materialCost;
            //response.TaxRate = tax.TaxRate;
            response.Order.Tax = tax;
            response.Order.Total = total;
            return response;
        }

        //below code is how we setup in TractorDex 

        //public Order GetSingleOrder(int orderNumber)
        //{
        //    return orderRepository.GetSingleOrder(orderNumber);
        //}
    }
}
