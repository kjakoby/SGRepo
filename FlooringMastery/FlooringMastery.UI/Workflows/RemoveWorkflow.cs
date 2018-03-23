using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class RemoveWorkflow
    {
        public void Execute()
        {
            //bool invalidDate;
            //do
            //{
            //    invalidDate = true;
            ConsoleIO.Header("\t~Remove Order~");
            DateTime orderDate = ConsoleIO.DateLookupPrompt();

            FlooringManager flooringManager = FlooringManagerFactory.Create(orderDate);
            IOrderRepository orderRepo = flooringManager.orderRepository;
            IProductRepository productRepository = flooringManager.productRepository;
            ITaxRepository taxRepository = flooringManager.taxRepository;

            ConsoleIO.Header("\t~Remove Order~");
            Dictionary<int, Order> orderDictionary = flooringManager.GetAllOrders(orderDate);
            //if (!orderRepo.FileExists())
            //{
            //    //Console.WriteLine();
            //    //ConsoleIO.InvalidDate();
            //    ConsoleIO.TryAgain();
            //    Console.ReadKey();
            //}
            //else
            if (orderRepo.FileExists())
            {
                if (orderRepo.LastOrder() == true)
                {
                    ConsoleIO.DisplayAllOrders(orderDictionary,false,true,orderDate);
                    Console.WriteLine();
                    string input = ConsoleIO.YOrNMessage("remove");
                    if (input == "Y")
                    {
                        orderRepo.DeleteOrderFile();
                        Console.WriteLine();
                        ConsoleIO.OrderRemoved(0,true);
                        ConsoleIO.KeyToContinue();
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine();
                        ConsoleIO.ReturnMenu("removing");
                        ConsoleIO.KeyToContinue();
                        Console.ReadKey();
                    }

                }
                else
                {
                    ConsoleIO.Header("\t~Remove Order~");
                    int orderNumber = ConsoleIO.GetIntFromUser(ConsoleIO.OrderLookup());

                    DisplaySingleResponse response = flooringManager.LookupOrder(orderNumber, orderDate);
                    //if (response.Success)
                    //{
                    ConsoleIO.DisplaySingleOrder(response.Order, true);
                    Console.WriteLine();
                    string input = ConsoleIO.YOrNMessage("remove");
                    if (input == "Y")
                    {
                        while (orderRepo.RemoveOrder(response.Order.OrderNumber) == false)
                        {
                            ConsoleIO.InvalidOrder();
                            ConsoleIO.TryAgain();
                        }
                        //{
                        //    ConsoleIO.InvalidOrder(orderNumber.ToString());
                        //    ConsoleIO.TryAgain();
                        //} while (orderRepo.RemoveOrder(orderNumber) == false);


                        Console.WriteLine();
                        ConsoleIO.OrderRemoved(orderNumber,false);
                        orderRepo.CloseRepo(response.Order);
                        ConsoleIO.KeyToContinue();
                        Console.ReadKey();
                    }
                }
                //invalidDate = false;
                
                //}
                //else
                //{
                //    ConsoleIO.ErrorOccurred();
                //    Console.WriteLine(response.Message);
                //}

            }
            else
            {
                ConsoleIO.KeyToContinue();
                Console.ReadKey();
            }
            
            //} while (invalidDate); 
        }
    }
}
