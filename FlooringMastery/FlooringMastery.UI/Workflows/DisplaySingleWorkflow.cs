using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class DisplaySingleWorkflow
    {
        public void Execute()
        {
            ConsoleIO.Header("\t~Single Order~");
            DateTime orderDate = ConsoleIO.DateLookupPrompt();

            FlooringManager manager = FlooringManagerFactory.Create(orderDate);

            ConsoleIO.Header("\t~Single Order~");

            //check if file exists
            //if so:
            
            Dictionary<int, Order> orderDictionary = manager.GetAllOrders(orderDate);

            if (manager.orderRepository.FileExists())
            {
                if (manager.orderRepository.LastOrder()==true)
                {
                    //DisplaySingleResponse singleResponse = manager.GetOnlyOrder(orderDate);
                    //ConsoleIO.DisplaySingleOrder(singleResponse.Order, true);
                    ConsoleIO.DisplayAllOrders(orderDictionary, false, true,orderDate);
                }
                else
                {
                    int orderNumber = ConsoleIO.GetIntFromUser(ConsoleIO.OrderLookup());

                    DisplaySingleResponse response = manager.LookupOrder(orderNumber, orderDate);

                    if (response.Success)
                    {
                        ConsoleIO.Header("\t~Single Order~");
                        ConsoleIO.DisplaySingleOrder(response.Order, true);
                    }
                    else
                    {
                        //ConsoleIO.ErrorOccurred();
                        //not sure how to put this into ConsoleIO
                        //Console.WriteLine(response.Message);
                        Console.WriteLine();
                        ConsoleIO.InvalidOrder();
                    }
                }
            }
                
            //else:
            
            ConsoleIO.KeyToContinue();
            Console.ReadKey();
        }
    }
}
