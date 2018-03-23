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
    public class AddWorkflow
    {
        public void Execute()
        {
            ConsoleIO.Header("\t~Add Order~");
            DateTime orderDate = ConsoleIO.GetOrderDate();

            FlooringManager flooringManager = FlooringManagerFactory.Create(orderDate);
            IOrderRepository orderRepo = flooringManager.orderRepository;
            IProductRepository productRepository = flooringManager.productRepository;
            ITaxRepository taxRepository = flooringManager.taxRepository;

            //if (!orderRepo.FileExists())
            //{
                
            //}
            ConsoleIO.Header("\t~Add Order~");
            string custName = ConsoleIO.GetInputFromUser(ConsoleIO.GetCustName());
            ConsoleIO.Header("\t~Add Order~");
            string state = ConsoleIO.GetCustStateAbbrv(flooringManager.GetAllTaxes(),"\t~Add Order~",false,"");
            ConsoleIO.Header("\t~Add Order~");
            string prodType = ConsoleIO.GetProd(flooringManager.GetAllProducts(), false, "\t~Add Order~","");
            ConsoleIO.Header("\t~Add Order~");
            decimal area = ConsoleIO.GetArea();

            Product prodChosen = productRepository.GetOrderProd(prodType);
            Tax taxChosen = taxRepository.GetOrderTax(state);

            decimal taxRate = taxChosen.TaxRate;
            decimal cost = prodChosen.CostPerSquareFoot;
            decimal labor = prodChosen.LaborCostPerSquareFoot;
            decimal materialCost = area * cost;
            decimal laborCost = area * labor;
            decimal tax = ((materialCost + laborCost) * (taxRate / 100));
            decimal total = materialCost + laborCost + tax;

            Console.Clear();
            AddOrderResponse response = flooringManager.AddOrder(orderDate, custName, state, prodType, area, taxRate, cost, labor, materialCost, laborCost, tax, total, prodChosen);

            //display order after calculations
            do
            {
                ConsoleIO.Header("\t~Add Order~");
                ConsoleIO.DisplaySingleOrder(response.Order, false);
                string saveAnswer = ConsoleIO.SavePrompt().ToUpper();

                if (saveAnswer == "Y")
                {
                    //save and exit
                    orderRepo.SaveOrder(response.Order);
                    orderRepo.CloseRepo(response.Order);
                    Console.WriteLine();
                    ConsoleIO.SaveCompleted();
                    response.Success = true;
                }
                else
                {
                    string editAnswer = ConsoleIO.EditPrompt();
                    if (editAnswer == "Y")
                    {
                        Console.WriteLine();
                        ConsoleIO.AllowEdit();
                        ConsoleIO.KeyToContinue();
                        Console.ReadKey();
                        ConsoleIO.EditOrder(response.Order, flooringManager.GetAllTaxes(), flooringManager.GetAllProducts());
                        //edit answer 
                    }
                    else if (editAnswer == "N")
                    {
                        Console.WriteLine();
                        ConsoleIO.ReturnMenu("saving");
                        response.Success = true;
                        //dont save and go back to main menu
                    }
                    else
                    {
                        //go back to save prompt
                        continue;
                    }

                }
            } while (response.Success!=true);



            
            ConsoleIO.KeyToContinue();
            Console.ReadKey();
        }
        
    }
}
