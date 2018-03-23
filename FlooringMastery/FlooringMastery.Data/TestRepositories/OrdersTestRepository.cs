using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data.TestRepositories
{
    public class OrdersTestRepository : IOrderRepository
    {
        private static Order _order = new Order
        {
            OrderNumber = 1,
            CustomerName = "Wise",
            State = "OH",
            TaxRate = 6.25M,
            ProductType = "Wood",
            Area = 100.00M,
            CostPerSquareFoot = 5.15M,
            LaborCostPerSquareFoot = 4.75M,
            MaterialCost = 515.00M,
            LaborCost = 475.00M,
            Tax = 61.88M,
            Total = 1051.88M
        };

        public void CloseRepo(Order order)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, Order> DeleteOrder(int orderNumber)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrderFile()
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, Order> EditOrder(Order original, Order updated)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, Order> EditOrder(int orderNumber, Order updated)
        {
            throw new NotImplementedException();
        }

        public bool FileExists()
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, Order> GetAllOrders(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Order GetLastOrder(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, Order> GetOrder(DateTime date, int orderNumber)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, Order> GetSingleOrder(DateTime date, int orderNumber)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, Order> GetSingleOrder(int orderNumber)
        {
            throw new NotImplementedException();
        }

        public Order GetSingleOrder(int orderNumber, DateTime date)
        {
            throw new NotImplementedException();
        }

        public bool LastOrder()
        {
            throw new NotImplementedException();
        }

        public Order LoadOrder(int orderNumber)
        {
            if (_order.OrderNumber == orderNumber)
            {
                return _order;
            }
            else
            {
                return null;
            }
        }

        public Dictionary<int, Order> RemoveOrder(int orderNumber)
        {
            throw new NotImplementedException();
        }

        public void SaveOrder(Order order)
        {
            _order = order;
        }

        //Order IOrderRepository.GetSingleOrder(int orderNumber)
        //{
        //    throw new NotImplementedException();
        //}

        bool IOrderRepository.RemoveOrder(int orderNumber)
        {
            throw new NotImplementedException();
        }
    }
}
