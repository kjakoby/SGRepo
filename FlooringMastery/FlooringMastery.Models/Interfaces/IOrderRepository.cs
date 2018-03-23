using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Interfaces
{
    public interface IOrderRepository
    {
        Dictionary<int, Order> GetAllOrders(DateTime date);
        Order GetSingleOrder(int orderNumber, DateTime date);
        bool RemoveOrder(int orderNumber);
        Dictionary<int, Order> EditOrder(Order original, Order updated);
        Dictionary<int, Order> EditOrder(int orderNumber, Order updated);
        Order LoadOrder(int orderNumber);
        void SaveOrder(Order order);
        void CloseRepo(Order order);
        bool FileExists();
        bool LastOrder();
        void DeleteOrderFile();
        Order GetLastOrder(DateTime date);
    }
}
