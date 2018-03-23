using FlooringMastery.BLL;
using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI
{
    public class ConsoleIO
    {
        private const string seperator = "===========================================";

        public static void EntryError()
        {
            Console.WriteLine("That is not a valid entry!");
        }

        public static void KeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
        }

        public static void TryAgain()
        {
            Console.WriteLine("Press any key to try again...");
        }

        internal static void DisplayAllOrders(Dictionary<int, Order> orderDictionary, bool summary, bool isLast,DateTime date)
        {
            foreach (KeyValuePair<int, Order> kv in orderDictionary)
            {
                //Console.WriteLine($"Order number: {kv.Key}");
                if (kv.Value != null)
                {
                    if (summary)
                    {
                        if (isLast)
                        {
                            DisplaySummaryOrder(kv.Value, true);
                        }
                        else
                        {
                            DisplaySummaryOrder(kv.Value, false);
                        }
                        
                    }
                    else
                    {
                        if (isLast)
                        {
                            DisplayFullOrder(kv.Value, true);
                        }
                        else
                        {
                            DisplayFullOrder(kv.Value, false);
                        }
                    }
                    //Console.WriteLine(seperator);
                }
            }
            if (summary&&!isLast)
            {
                Console.WriteLine($"Orders for {date} are displayed above.");
            }
            Console.WriteLine();
            //KeyToContinue();
        }

        public static void DisplayFullOrder(Order order,bool isLast)
        {
            Console.WriteLine($"Displaying order # {order.OrderNumber}");
            Console.WriteLine("------------------------------");
            Console.WriteLine();
            if (isLast)
            {
                Console.WriteLine($"Order date: {order.OrderDate.ToShortDateString()}");
            }
            Console.WriteLine($"Customer name: {order.CustomerName}");
            Console.WriteLine($"State: {order.State}");
            Console.WriteLine($"Tax rate: {order.TaxRate}%");
            Console.WriteLine($"Product: {order.ProductType}");
            Console.WriteLine($"Area: {order.Area}");
            Console.WriteLine($"Cost per square foot: {order.CostPerSquareFoot:c}");
            Console.WriteLine($"Labor cost per square foot: {order.LaborCostPerSquareFoot:c}");
            Console.WriteLine($"Material cost: {order.MaterialCost:c}");
            Console.WriteLine($"Labor cost: {order.LaborCost:c}");
            Console.WriteLine($"Tax: {order.Tax:c}");
            Console.WriteLine($"Total: {order.Total:c}");
            Console.WriteLine();
            Console.WriteLine("------------------------------");
        }

        public static void DisplaySummaryOrder(Order order,bool isLast)
        {
            Console.WriteLine($"Displaying order # {order.OrderNumber}");
            Console.WriteLine("------------------------------");
            Console.WriteLine();
            if (isLast)
            {
                Console.WriteLine($"Order date: {order.OrderDate.ToShortDateString()}");
            }
            Console.WriteLine($"Customer name: {order.CustomerName}");
            Console.WriteLine($"Product: {order.ProductType}");
            Console.WriteLine($"Total: {order.Total:c}");
            Console.WriteLine();
            Console.WriteLine("------------------------------");
        }

        public static void DisplayAvailProds(Dictionary<string, Product> prodDictionary)
        {
            Console.WriteLine();
            foreach (KeyValuePair<string, Product> kv in prodDictionary)
            {
                //Console.WriteLine($"Order number: {kv.Key}");
                if (kv.Value != null)
                {
                    Console.WriteLine(kv.Value.ProductType);
                    //Console.WriteLine(seperator);
                }
            }
            Console.WriteLine();
            //KeyToContinue();
        }

        internal static void OrderRemoved(int orderNumber,bool lastOrder)
        {
            if (lastOrder)
            {
                Console.WriteLine($"The order has been removed.");
            }
            else
            {
                Console.WriteLine($"Order # {orderNumber} has been removed.");
            }
            
        }

        public static void DisplayAvailStates(Dictionary<string, Tax> taxDictionary)
        {
            Console.WriteLine();
            foreach (KeyValuePair<string, Tax> kv in taxDictionary)
            {
                //Console.WriteLine($"Order number: {kv.Key}");
                if (kv.Value != null)
                {
                    Console.WriteLine($"{kv.Key}({kv.Value.StateName})");
                    //Console.WriteLine(seperator);
                }
            }
            Console.WriteLine();
            //KeyToContinue();
        }

        internal static void Header(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine(seperator);
            Console.WriteLine();
        }

        public static string GetInputFromUser(string message)
        { 
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (input == "" || input == " ")
                {
                    BlankOrNon();
                    KeyToContinue();
                    Console.ReadKey();
                    Console.WriteLine();
                }
                else
                {
                    return input;
                }
            }
        }

        public static string GetCustStateAbbrv(Dictionary<string, Tax> Taxes, string message, bool IsEdit, string original)
        {
            string input;
            bool Invalid=true;
            do
            {
                Header(message);
                Console.Write("Enter the state by abbreviation(or hit enter to see available states): ");
                input = Console.ReadLine().ToUpper();
                if (input == "")
                {
                    Header(message);
                    Console.WriteLine("Find the State you would like from the below list:");
                    DisplayAvailStates(Taxes);
                    Console.WriteLine("Press any key to select your state...");
                    Console.ReadKey();
                }
                else
                {
                    if (Taxes.Keys.Contains(input))
                    {
                        Invalid = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        BlankOrNon();
                        KeyToContinue();
                        Console.ReadKey();
                        continue;
                    }
                }
                
                if (IsEdit==true)
                {
                    Header(message);
                    EditStringWrites("state's abbreviation", original);
                    input = Console.ReadLine().ToUpper();
                    if (input == "")
                    {
                        //beingSplit = null;
                        Invalid = false;
                        break;
                    }
                    else if (Taxes.Keys.Contains(input))
                    {
                        Invalid = false;
                    }
                    else
                    {
                        Console.WriteLine();
                        BlankOrNon();
                        KeyToContinue();
                        Console.ReadKey();
                    }
                }
                
                

            } while (Invalid);
            return input;
            
        }

        public static decimal GetArea()
        {
            while (true)
            {
                int area;
                Console.Write("Enter the area you are covering(min. area is 100): ");
                string response = Console.ReadLine();
                if (response == "")
                {
                    BlankOrNon();
                    KeyToContinue();
                    Console.ReadKey();
                    Console.WriteLine();
                }
                else if (int.TryParse(response, out area) && area>=100)
                {
                    return area;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"{response} is not a valid area!");
                    KeyToContinue();
                    Console.ReadKey();
                    Console.WriteLine();
                }
            }
            //Console.Write("Enter the area of needed product: ");
            //decimal area = Console.ReadLine();
            //return area;
        }

        public static string GetProd(Dictionary<string, Product> Product,bool IsEdit,string message,string original)
        {
            string input;
            string valid;

            //bool Invalid = true;
            do
            {
                valid = "Temp";
                Header(message);
                Console.Write("Enter the product(or hit enter to see available products): ");
                input = Console.ReadLine();
                
                if (input == "")
                {
                    Header(message);
                    Console.WriteLine("Find the product you would like from the below list: ");
                    DisplayAvailProds(Product);
                    valid = null;
                    Console.WriteLine("Press any key to select your product...");
                    Console.ReadKey();
                }
                //else if (input == " ")
                //{
                //    beingSplit = null;
                //    continue;
                //}
                else
                {
                    if (!Product.ContainsKey(input))
                    {
                        
                        //Invalid = false;
                        valid = null;
                        Console.WriteLine();
                        BlankOrNon();
                        KeyToContinue();
                        Console.ReadKey();
                        continue;
                    }
                    //is a valid product
                    else
                    {
                        break;
                    }
                    ////beingSplit = char.ToUpper(input[0]) + input.Substring(1);
                    //if (!Product.ContainsKey(input))
                    //{
                    //else
                    //    {
                    //        //Invalid = false;
                    //        beingSplit = null;
                    //        BlankOrNon();
                    //        KeyToContinue();
                    //        Console.ReadKey();
                    //        Console.WriteLine();
                    //    }
                }
                if (IsEdit==true)
                {
                    Header(message);
                    EditStringWrites("product",original);
                    input = Console.ReadLine();
                    if (input == "")
                    {
                        //beingSplit = null;
                        break;
                    }
                    else
                    {

                        //beingSplit = char.ToUpper(input[0]) + input.Substring(1);
                        if (!Product.ContainsKey(input))
                        {
                            //Invalid = false;
                            valid = null;
                            Console.WriteLine();
                            BlankOrNon();
                            KeyToContinue();
                            Console.ReadKey();
                        }
                    }
                    
                    //else
                    //{
                    //    Console.WriteLine("That product does not exist!");
                    //    KeyToContinue();
                    //    Console.WriteLine();
                    //    Console.ReadKey();
                    //}
                }

                //Console.Write("Enter the product: ");
                //input = Console.ReadLine();
                //if (input == "" || input == " ")
                //{
                //    BlankOrNon();
                //    KeyToContinue();
                //    Console.ReadKey();
                //    Console.WriteLine();
                //}
                //else
                //{
                //    beingSplit = char.ToUpper(input[0]) + input.Substring(1);
                //    if (!Product.Keys.Contains(beingSplit))
                //    {
                //        //Invalid = false;
                //        //beingSplit = null;
                //        BlankOrNon();
                //        KeyToContinue();
                //        Console.ReadKey();
                //        Console.WriteLine();
                //    }
                //    //else
                //    //{
                //    //    Console.WriteLine("That product does not exist!");
                //    //    KeyToContinue();
                //    //    Console.WriteLine();
                //    //    Console.ReadKey();
                //    //}
                //}
                //else
                //{
                //    Console.Write("Enter the product: ");
                //    input = Console.ReadLine();
                //    if (input == "" || input == " ")
                //    {
                //        BlankOrNon();
                //        KeyToContinue();
                //        Console.ReadKey();
                //        Console.WriteLine();
                //    }
                //    else
                //    {
                //        beingSplit = char.ToUpper(input[0]) + input.Substring(1);
                //        if (!Product.Keys.Contains(beingSplit))
                //        {
                //            //Invalid = false;
                //            //beingSplit = null;
                //            BlankOrNon();
                //            KeyToContinue();
                //            Console.ReadKey();
                //            Console.WriteLine();
                //        }
                //        //else
                //        //{
                //        //    Console.WriteLine("That product does not exist!");
                //        //    KeyToContinue();
                //        //    Console.WriteLine();
                //        //    Console.ReadKey();
                //        //}
                //    }
                //}
            } while (valid==null);
            return input;
        }

        internal static string GetCustName()
        {
            return "Enter the name for the order: ";
        }

        public static string SavePrompt()
        {
            Console.Write("Would you like to save? (Y for yes or any other key to continue): ");
            string input = Console.ReadLine().ToUpper();
            return input;
        }

        public static void SaveCompleted()
        {
            Console.WriteLine("The order has been saved!");
        }

        public static string EditPrompt()
        {
            Console.Write("Would you like to edit one of your responses? (Y/N or any key to try to save again.): ");
            string input = Console.ReadLine().ToUpper();
            return input;
        }

        public static void EditStringWrites(string fieldBeingChanged, string original)
        {
            Console.Write($"Enter a new {fieldBeingChanged} or use ({original}): ");
        }

        public static void EditIntWrites(string fieldBeingChanged, decimal original)
        {
            Console.Write($"Enter a new {fieldBeingChanged} or use ({original}): ");
        }

        public static Order EditOrder(Order order, Dictionary<string, Tax> taxes, Dictionary<string, Product> products)
        {
            if (order != null)
            {
                Header("\t~Edit Order~");
                EditStringWrites("customer name", order.CustomerName);
                string tempName = Console.ReadLine();
                if (!string.IsNullOrEmpty(tempName))
                {
                    order.CustomerName = tempName;
                }

                string tempState = GetCustStateAbbrv(taxes, "\t~Edit Order~", true, order.State);
                if (!string.IsNullOrEmpty(tempState))
                {
                    order.State = tempState;
                }

                string tempProd = GetProd(products, true, "\t~Edit Order~", order.ProductType);
                if (!string.IsNullOrEmpty(tempProd))
                {
                    order.ProductType = tempProd;
                }

                decimal selection=-1;
                bool validEntry = true;

                Header("\t~Edit Order~");
                do
                {
                    
                    EditIntWrites("area", order.Area);
                    string entry = Console.ReadLine();
                    if (!string.IsNullOrEmpty(entry))
                    {
                        validEntry = decimal.TryParse(entry, out selection);
                        if (validEntry && selection >=100)
                        {
                            order.Area = selection;
                        }
                        else
                        {
                            validEntry = false;
                            Console.WriteLine();
                            Console.WriteLine($"{entry} is not a valid area!");
                            TryAgain();
                            Console.ReadKey();
                            Console.WriteLine();
                        }
                    }
                    else if(entry=="")
                    {
                        validEntry = true;
                    }
                } while (!validEntry);
            }
            else
            {
                Console.WriteLine("No order found to edit!");
            }
            return order;
        }

        public static string YOrNMessage(string section)
        {
            Console.Write($"Would you like to {section} the order? (Y for yes or any key to return to the menu): ");
            string input = Console.ReadLine().ToUpper();
            return input;
        }

        public static void AllowEdit()
        {
            Console.WriteLine("You chose to edit the order before saving.");
        }

        public static void NoEdit()
        {
            Console.WriteLine("You have chosen to not edit the order.");
        }

        public static void ReturnMenu(string section)
        {
            Console.WriteLine($"You have chosen to return to the menu without {section}.");
        }

        public static void BlankOrNon()
        {
            Console.WriteLine("The required field was blank or does not exist!");
        }

        public static void ErrorOccurred()
        {
            Console.WriteLine("An error occurred: ");
        }

        public static DateTime DateLookupPrompt()
        {
            bool IncorrectDate;
            DateTime orderDate = default(DateTime);
            //DateTime today = DateTime.Today;
            do
            {
                //DateTime orderDate;
                IncorrectDate = true;
                Console.Write("Enter the date you would like to search for(MM-DD-YYYY): ");
                string input = Console.ReadLine();
                DateTime date;
                if (DateTime.TryParse(input, out date))
                {
                    //if (date >= today)
                    //{
                    //    //good date
                        orderDate = date;
                        IncorrectDate = false;
                    //}
                    //else
                    //{
                    //    Console.WriteLine("");
                    //    //date is in the past
                    //}
                }
                else
                {
                    Console.WriteLine();
                    EntryError();
                    TryAgain();
                    Console.ReadKey();
                    Console.WriteLine();
                    //not a valid date

                }
            } while (IncorrectDate);
            return orderDate;
        }

        public static int GetIntFromUser(string message)
        {
            while (true)
            {
                int number;
                Console.Write(message);
                string response = Console.ReadLine();
                if (int.TryParse(response, out number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine($"{response} is not a valid number!");
                    KeyToContinue();
                    Console.ReadKey();
                    Console.WriteLine();
                }
            }
        }

        public static string OrderLookup()
        {
            //Console.WriteLine("Lookup an order");
            //Console.WriteLine(seperator);
            //Console.WriteLine();
            return "Enter the order number you would like to look for: ";
        }

        public static void InvalidOrder()
        {
            Console.WriteLine($"That order does not exist!");
        }

        public static void InvalidDate()
        {
            Console.WriteLine($"That date does not exist!");
        }

        public static void DisplaySingleOrder(Order order, bool DisplayOrderNumber)
        {
            if (order==null)
            {
                InvalidOrder();
            }
            else
            {
                if (DisplayOrderNumber)
                {
                    Console.WriteLine($"Displaying order # {order.OrderNumber}");
                }
                else
                {
                    Console.WriteLine("Displaying order being added...");
                }
                Console.WriteLine("------------------------------");
                Console.WriteLine();
                Console.WriteLine($"Order date: {order.OrderDate.ToShortDateString()}");
                if (DisplayOrderNumber)
                {
                    Console.WriteLine($"Order number: {order.OrderNumber}");
                }
                else
                {
                    Console.WriteLine("Order number: Pending until saved!");
                }
                Console.WriteLine($"Customer name: {order.CustomerName}");
                Console.WriteLine($"State: {order.State}");
                Console.WriteLine($"Tax rate: {order.TaxRate}%");
                Console.WriteLine($"Product: {order.ProductType}");
                Console.WriteLine($"Area: {order.Area}");
                Console.WriteLine($"Cost per square foot: {order.CostPerSquareFoot:c}");
                Console.WriteLine($"Labor cost per square foot: {order.LaborCostPerSquareFoot:c}");
                Console.WriteLine($"Material cost: {order.MaterialCost:c}");
                Console.WriteLine($"Labor cost: {order.LaborCost:c}");
                Console.WriteLine($"Tax: {order.Tax:c}");
                Console.WriteLine($"Total: {order.Total:c}");
                Console.WriteLine();
                Console.WriteLine("------------------------------");
            }
            
        }

        public static DateTime GetOrderDate()
        {
            bool IncorrectDate;
            DateTime orderDate = default(DateTime);
            DateTime today = DateTime.Today;
            do
            {
                //DateTime orderDate;
                IncorrectDate = true;
                Console.Write("Enter the date for your order(MM-DD-YYYY): ");
                string input = Console.ReadLine();
                DateTime date;
                if (DateTime.TryParse(input, out date))
                {
                    if (date>=today)
                    {
                        //good date
                        orderDate = date;
                        IncorrectDate = false;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Order dates must be in the future!");
                        TryAgain();
                        Console.ReadKey();
                        Console.WriteLine();
                        //date is in the past
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("That is not a valid date!");
                    TryAgain();
                    Console.ReadKey();
                    Console.WriteLine();
                    //not a valid date

                }
            } while (IncorrectDate);
            return orderDate;
            //return "Enter the order date: ";
        }

        public static void SplashScreen()
        {
            Console.WriteLine(" ___________________________________________");
            Console.WriteLine("|                                           |");
            Console.WriteLine("|              Welcome to the               |");
            Console.WriteLine("|         SWC Corp Order Application        |");
            Console.WriteLine("|                                           |");
            Console.WriteLine("|    -----------------------------------    |");
            Console.WriteLine("|       ...Press any key to begin...        |");
            Console.WriteLine("|___________________________________________|");
        }
    }
}
