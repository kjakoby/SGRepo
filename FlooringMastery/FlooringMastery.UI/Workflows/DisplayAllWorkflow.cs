using FlooringMastery.BLL;
using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class DisplayAllWorkflow
    {
        public void Execute()
        {
            //Console.Clear();
            //Console.WriteLine("You are now in the Display All Orders by Date section");
            //Console.ReadKey();
            ConsoleIO.Header("\t~All of Date's Orders~");

            DateTime orderDate = ConsoleIO.DateLookupPrompt();

            //get date to search by then out in .create(...)
            FlooringManager manager = FlooringManagerFactory.Create(orderDate);

            ConsoleIO.Header("\t~All of Date's Orders~");
            Dictionary<int, Order> orderDictionary = manager.GetAllOrders(orderDate);

            if (manager.orderRepository.FileExists())
            {
                if (manager.orderRepository.LastOrder() == true)
                {
                    ConsoleIO.DisplayAllOrders(orderDictionary, true, true,orderDate);
                }
                else
                {
                    ConsoleIO.DisplayAllOrders(orderDictionary, true, false, orderDate);
                }
            }
            

            ConsoleIO.KeyToContinue();
            Console.ReadKey();
        }
    }
}
