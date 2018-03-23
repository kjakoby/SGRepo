using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace FlooringMastery.BLL.Rules
//{
    //public class AddRule : IAddOrder
    //{
    //AddOrderResponse AddOrder(Order order, string orderDate, string custName, string stateAbbrev, string prodType, decimal area)
    //{
    //    AddOrderResponse response = new AddOrderResponse();

    //    response.OrderDate = 
    //}
    //public AddOrderResponse AddOrder(/*int orderNumber,*/Order order, string orderDate, string custName, string stateAbbrev, string prodType, decimal area)
    //{
    //    AddOrderResponse response = new AddOrderResponse();

    //    response.Order = order; 
    //    response.OrderDate = orderDate;
    //    response.CustName = custName;
    //    response.StateAbbrev = stateAbbrev;
    //    response.Area = area;
    //    //response.CostPerSquareFoot = 
    //    response.LaborCost = response.Area * response.CostPerSquareFoot;
    //    response.MaterialCost = response.Area * response.LaborCostPerSquareFoot;
    //    //response.LaborCostPerSquareFoot = 
    //    response.ProductType = prodType;
    //    response.TaxRate = response.TaxRate;
    //    response.Tax = ((response.MaterialCost + response.LaborCost) * (response.TaxRate / 100));
    //    return response;

    //}

    //public AddOrderResponse AddOrder(string orderDate, string custName, string stateAbbrev, string prodType, decimal area)
    //{
    //    AddOrderResponse response = new AddOrderResponse();
    //    Order order = new Order();
    //    response.Order = order;
    //    response.OrderDate = order.OrderDate;
    //    response.CustName = order.CustomerName;
    //    response.StateAbbrev = order.State;
    //    response.Area = order.Area;
    //    //response.CostPerSquareFoot = 
    //    response.LaborCost = order.Area * order.CostPerSquareFoot;
    //    response.MaterialCost = response.Area * response.LaborCostPerSquareFoot;
    //    //response.LaborCostPerSquareFoot = 
    //    response.ProductType = prodType;
    //    response.TaxRate = response.TaxRate;
    //    response.Tax = ((response.MaterialCost + response.LaborCost) * (response.TaxRate / 100));
    //    return response;
    //}
//}
//}
