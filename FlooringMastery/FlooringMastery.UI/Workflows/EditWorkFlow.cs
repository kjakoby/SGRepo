using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class EditWorkflow
    {
        public void Execute()
        {
            ConsoleIO.Header("\t~Edit Order~");
            DateTime orderDate = ConsoleIO.DateLookupPrompt();

            FlooringManager flooringManager = FlooringManagerFactory.Create(orderDate);
            IOrderRepository orderRepo = flooringManager.orderRepository;
            IProductRepository productRepository = flooringManager.productRepository;
            ITaxRepository taxRepository = flooringManager.taxRepository;

            ConsoleIO.Header("\t~Edit Order~");
            Dictionary<int, Order> orderDictionary = flooringManager.GetAllOrders(orderDate);
            //Order singleOrder = orderDictionary.TakeWhile(o=>o.Value.OrderDate==orderDate)

            if (orderRepo.FileExists())
            {
                if (orderRepo.LastOrder() == true)
                {
                    ConsoleIO.DisplayAllOrders(orderDictionary, false,true,orderDate);
                    Console.WriteLine();
                    string input = ConsoleIO.YOrNMessage("edit");
                    if (input == "Y")
                    {
                        DisplaySingleResponse singleResponse = flooringManager.GetOnlyOrder(orderDate);

                        ConsoleIO.EditOrder(singleResponse.Order, flooringManager.GetAllTaxes(), flooringManager.GetAllProducts());
                        ConsoleIO.Header("\t~Edit Order");
                        ConsoleIO.DisplaySingleOrder(singleResponse.Order, true);

                        do
                        {

                            singleResponse.Success = false;

                            string saveAnswer = ConsoleIO.SavePrompt().ToUpper();

                            if (saveAnswer == "Y")
                            {
                                //save and exit
                                //orderRepo.SaveOrder(response.Order);
                                orderRepo.CloseRepo(singleResponse.Order);
                                ConsoleIO.SaveCompleted();
                                singleResponse.Success = true;
                            }
                            else
                            {
                                string editAnswer = ConsoleIO.EditPrompt();
                                if (editAnswer == "Y")
                                {
                                    ConsoleIO.AllowEdit();
                                    ConsoleIO.KeyToContinue();
                                    Console.ReadKey();
                                    ConsoleIO.EditOrder(singleResponse.Order, flooringManager.GetAllTaxes(), flooringManager.GetAllProducts());
                                    ConsoleIO.Header("\t~Edit Order~");
                                    ConsoleIO.DisplaySingleOrder(singleResponse.Order, true);
                                    //edit answer 
                                }
                                else if (editAnswer == "N")
                                {
                                    ConsoleIO.ReturnMenu("saving");
                                    singleResponse.Success = true;
                                    //dont save and go back to main menu
                                }
                                else
                                {
                                    //go back to save prompt
                                    ConsoleIO.Header("\t~Edit Order~");
                                    ConsoleIO.DisplaySingleOrder(singleResponse.Order, true);
                                    continue;
                                }

                            }
                        } while (singleResponse.Success != true);
                        //orderRepo.DeleteOrderFile();
                        //Console.WriteLine();
                        //ConsoleIO.OrderRemoved(0, true);
                        //ConsoleIO.KeyToContinue();
                        //Console.ReadKey();
                    }
                    //else
                    //{
                    //    //string editAnswer = ConsoleIO.EditPrompt();
                    //    //if (editAnswer == "Y")
                    //    //{
                    //    //    ConsoleIO.AllowEdit();
                    //    //    ConsoleIO.KeyToContinue();
                    //    //    Console.ReadKey();
                    //    //    ConsoleIO.EditOrder(response.Order, flooringManager.GetAllTaxes(), flooringManager.GetAllProducts());
                    //    //    ConsoleIO.Header("\t~Edit Order~");
                    //    //    ConsoleIO.DisplaySingleOrder(response.Order, true);
                    //    //    //edit answer 
                    //    //}
                    //    //else if (editAnswer == "N")
                    //    //{
                    //    //    ConsoleIO.ReturnMenu("saving");
                    //    //    response.Success = true;
                    //    //    //dont save and go back to main menu
                    //    //}
                    //    //else
                    //    //{
                    //    //    //go back to save prompt
                    //    //    ConsoleIO.Header("\t~Edit Order~");
                    //    //    ConsoleIO.DisplaySingleOrder(response.Order, true);
                    //    //    continue;
                    //    //}
                    //}
                }
                else
                {
                    ConsoleIO.Header("\t~Edit Order~");
                    int orderNumber = ConsoleIO.GetIntFromUser(ConsoleIO.OrderLookup());

                    DisplaySingleResponse response = flooringManager.LookupOrder(orderNumber, orderDate);

                    if (response.Success)
                    {
                        ConsoleIO.Header("\t~Edit Order~");
                        ConsoleIO.DisplaySingleOrder(response.Order, true);
                        Console.WriteLine();
                        string input = ConsoleIO.YOrNMessage("edit");
                        if (input == "Y")
                        {
                            ConsoleIO.EditOrder(response.Order, flooringManager.GetAllTaxes(), flooringManager.GetAllProducts());
                            ConsoleIO.Header("\t~Edit Order");
                            ConsoleIO.DisplaySingleOrder(response.Order, true);
                            do
                            {

                                response.Success = false;

                                string saveAnswer = ConsoleIO.SavePrompt().ToUpper();

                                if (saveAnswer == "Y")
                                {
                                    //save and exit
                                    //orderRepo.SaveOrder(response.Order);
                                    orderRepo.CloseRepo(response.Order);
                                    ConsoleIO.SaveCompleted();
                                    response.Success = true;
                                }
                                else
                                {
                                    string editAnswer = ConsoleIO.EditPrompt();
                                    if (editAnswer == "Y")
                                    {
                                        ConsoleIO.AllowEdit();
                                        ConsoleIO.KeyToContinue();
                                        Console.ReadKey();
                                        ConsoleIO.EditOrder(response.Order, flooringManager.GetAllTaxes(), flooringManager.GetAllProducts());
                                        ConsoleIO.Header("\t~Edit Order~");
                                        ConsoleIO.DisplaySingleOrder(response.Order, true);
                                        //edit answer 
                                    }
                                    else if (editAnswer == "N")
                                    {
                                        ConsoleIO.ReturnMenu("saving");
                                        response.Success = true;
                                        //dont save and go back to main menu
                                    }
                                    else
                                    {
                                        //go back to save prompt
                                        ConsoleIO.Header("\t~Edit Order~");
                                        ConsoleIO.DisplaySingleOrder(response.Order, true);
                                        continue;
                                    }

                                }
                            } while (response.Success != true);
                        }
                    }
                }
            }
            else
            {
                ConsoleIO.InvalidOrder();
                ConsoleIO.KeyToContinue();
                Console.ReadKey();
            }

            //else
            //{
            //    ConsoleIO.KeyToContinue();
            //    Console.ReadKey();
            //}
        }
    }
}
