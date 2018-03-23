using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();

            //Exercise1();
            //Exercise2();
            //Exercise3();
            //Exercise4();
            //Exercise5();//
            //Exercise6();
            //Exercise7();
            //Exercise8();
            //Exercise9();
            //Exercise10();
            //Exercise11();
            //Exercise12();
            //Exercise13();
            //Exercise14();
            //Exercise15();
            //Exercise16();
            //Exercise17();
            //Exercise18();
            //Exercise19();
            //Exercise20();
            //Exercise21();// 
            //Exercise22();
            //Exercise23();//
            //Exercise24();//
            //Exercise25();//
            //Exercise26();
            //Exercise27();//
            //Exercise28();// 
            //Exercise29();//
            //Exercise30();//
            //Exercise31();//

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            var outOfStock = DataLoader.LoadProducts().Where(prod => prod.UnitsInStock == 0);
            PrintProductInformation(outOfStock);
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            var inStockAndMoreThanThree = DataLoader.LoadProducts().Where(prod => (prod.UnitsInStock > 0) && (prod.UnitPrice > 3));
            PrintProductInformation(inStockAndMoreThanThree);
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            var washingtonCustomers = from customer in DataLoader.LoadCustomers()
                                      where customer.Region == "WA"
                                      select customer;
            PrintCustomerInformation(washingtonCustomers);
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            var results = from prod in DataLoader.LoadProducts()
                          select new
                          {
                              ProductName = prod.ProductName
                          };
            Console.WriteLine("{0}", "ProductName");
            Console.WriteLine("==============================================================================");
            foreach(var prod in results)
            {
                Console.WriteLine(prod.ProductName);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            var results = from prod in DataLoader.LoadProducts()
                          select new
                          {
                              ProductID = prod.ProductID,
                              ProductName = prod.ProductName,
                              Category = prod.Category,
                              UnitPrice2 = prod.UnitPrice * 0.25M + prod.UnitPrice,
                              UnitsInStock = prod.UnitsInStock
                          };
            Console.WriteLine("{0,-10} {1,-33} {2,-15} {3,-10} {4}", "ProductID", "ProductName", "Category", "UnitPrice", "UnitsInStock");
            Console.WriteLine("================================================================================================");
            foreach(var prod in results)
            {
                Console.WriteLine("{0,-10} {1,-33} {2,-15} {3,-10} {4,-13}", prod.ProductID, prod.ProductName, prod.Category, prod.UnitPrice2, prod.UnitsInStock);
            }

        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            var results = from prod in DataLoader.LoadProducts()
                          select new
                          {
                              ProductName = prod.ProductName,
                              Category = prod.Category
                          };
            Console.WriteLine("{0,-50} {1}", "ProductName", "Category");
            Console.WriteLine("==============================================================================");
            foreach (var prod in results)
            {
                Console.WriteLine("{0,-50} {1}", prod.ProductName.ToUpper(), prod.Category.ToUpper());
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            var results = from prod in DataLoader.LoadProducts()
                          select new
                          {
                              ProductID = prod.ProductID,
                              ProductName = prod.ProductName,
                              Category = prod.Category,
                              UnitPrice = prod.UnitPrice,
                              UnitsInStock = prod.UnitsInStock,
                              ReOrder = ((prod.UnitsInStock < 3) ? "yes" : "no")
                          };
            Console.WriteLine("{0,-10} {1,-33} {2,-15} {3,-10} {4,-13} {5}", "ProductID", "ProductName", "Category", "UnitPrice", "UnitsInStock", "Re-Order?");
            Console.WriteLine("================================================================================================");
            foreach (var prod in results)
            {
                Console.WriteLine("{0,-10} {1,-33} {2,-15} {3,-10} {4,-13} {5}", prod.ProductID, prod.ProductName, prod.Category, prod.UnitPrice, prod.UnitsInStock, prod.ReOrder);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            var results = from prod in DataLoader.LoadProducts()
                          select new
                          {
                              ProductID = prod.ProductID,
                              ProductName = prod.ProductName,
                              Category = prod.Category,
                              UnitPrice = prod.UnitPrice,
                              UnitsInStock = prod.UnitsInStock,
                              StockValue = (prod.UnitPrice + prod.UnitsInStock)
                          };
            Console.WriteLine("{0,-10} {1,-33} {2,-15} {3,-10} {4,-13} {5}", "ProductID", "ProductName", "Category", "UnitPrice", "UnitsInStock", "StockValue");
            Console.WriteLine("================================================================================================");
            foreach(var prod in results)
            {
                Console.WriteLine("{0,-10} {1,-33} {2,-15} {3,-10} {4,-13} {5}", prod.ProductID, prod.ProductName, prod.Category, prod.UnitPrice, prod.UnitsInStock, prod.StockValue);
            }
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            var results = from number in DataLoader.NumbersA
                          where number % 2 == 0
                          select number;
            foreach(var number in results)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            var results = from customer in DataLoader.LoadCustomers()
                          where customer.Orders.Length > 0 && customer.Orders.Min(o => o.Total < 500)
                          select customer;
            PrintCustomerInformation(results);
        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            var results = from number in DataLoader.NumbersC
                          where number % 2 == 1
                          select number;
            var firstThree = from numbers in results.Take(3)
                             select numbers;
            foreach(var numbers in firstThree)
            {
                Console.WriteLine(numbers);
            }
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            var results = from number in DataLoader.NumbersB
                          select number;
            var skipThree = from numbers in results.Skip(3)
                            select numbers;
            foreach(var numbers in skipThree)
            {
                Console.WriteLine(numbers);
            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            var washingtonCustomers = from customers in DataLoader.LoadCustomers()
                                      where customers.Region == "WA"
                                      select customers;
            var results = from customer in washingtonCustomers
                          where customer.Orders.Length > 0
                          select new
                          {
                              CompanyName = customer.CompanyName,
                              LastOrder = customer.Orders.Max(o => o.OrderDate)
                          };
            Console.WriteLine("{0,-40} {1}", "CompanyName", "RecentOrder");
            Console.WriteLine("====================================================================");
            foreach(var customer in results)
            {
                Console.WriteLine("{0,-40} {1}", customer.CompanyName, customer.LastOrder);
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            var results = from numbers in DataLoader.NumbersC
                          select numbers;
            var halfOfNumbers = from num in results.TakeWhile(n => n < 6)
                                select num;
            foreach(var num in halfOfNumbers)
            {
                Console.WriteLine(num);
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            var results = from numbers in DataLoader.NumbersC
                          select numbers;
            var halfOfNumbers = from number in results.SkipWhile(n => n % 3 != 0).Skip(1)
                                select number;
            foreach(var num in halfOfNumbers)
            {
                Console.WriteLine(num);
            }
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            var results = from prod in DataLoader.LoadProducts()
                          orderby prod.ProductName
                          select prod;
            PrintProductInformation(results);
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            var results = from prod in DataLoader.LoadProducts()
                          orderby prod.UnitsInStock descending
                          select prod;
            PrintProductInformation(results);
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            var results = from prod in DataLoader.LoadProducts()
                          orderby prod.Category, prod.UnitPrice descending
                          select prod;
            PrintProductInformation(results);
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            var results = from number in DataLoader.NumbersB
                           select number;
            var reversed = from numbers in results.Reverse()
                           select numbers;
            foreach(var number in reversed)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            var results = from prods in DataLoader.LoadProducts()
                          group prods by prods.Category;
            foreach(var group in results)
            {
                Console.WriteLine(group.Key);
                foreach (var prod in group)
                {
                    Console.WriteLine("\t{0}", prod.ProductName);
                }
                Console.WriteLine("==============================================");
            }
        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {
            
            var results = from customers in DataLoader.LoadCustomers()
                          select new
                          {
                              CustName = customers.CompanyName,
                              Years = from o in customers.Orders
                                      group o by o.OrderDate.Year into yg
                                            select new
                                            {
                                                CustYear = yg.Key,
                                                Months = from y in yg
                                                         group y by y.OrderDate.Month into mg
                                                         select new
                                                         {
                                                             CustMonth = mg.Key,
                                                             Totals = from m in mg
                                                                      select m.Total
                                                         }
                                                
                                            }
                          };
            
            foreach(var cust in results)
            {
                Console.WriteLine(cust.CustName);
                foreach(var year in cust.Years)
                {
                    Console.WriteLine(year.CustYear);
                    
                    foreach (var month in year.Months)
                    {
                        
                        Console.WriteLine($"\t{month.CustMonth} - ${month.Totals.Sum()}");
                    }
                }
                Console.WriteLine("==============================================");
            }






        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            var list = from prod in DataLoader.LoadProducts()
                       select prod;
            //var categories = from cats in list
            //                 select new
            //                 {
            //                     Category = cats.Category
            //                 };
            var groupOfCats = from groups in list.Distinct()
                              group groups by groups.Category;
            foreach (var group in groupOfCats)
            {
                Console.WriteLine(group.Key);
                Console.WriteLine("==================");
            }
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            var list = from prod in DataLoader.LoadProducts()
                       select prod;
            var contains = list.Any(p => p.ProductID == 789);

            //use below line to test for a ProductID that is actually present

            //var contains = list.Any(p => p.ProductID == 50);
            Console.WriteLine(contains);
            
                       
        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            var list = from prod in DataLoader.LoadProducts()
                       select prod;
            var categories = from prods in list
                             where prods.UnitsInStock==0
                             select new
                             {
                                 Category = prods.Category,
                             };
            var groupOfCats = from groups in categories.Distinct()
                              group groups by groups.Category;
            foreach (var group in groupOfCats)
            {
                Console.WriteLine(group.Key);
                Console.WriteLine("==================");
            }
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {

            var list = from prod in DataLoader.LoadProducts()
                       group prod by prod.Category into pg
                       where pg.All(p => p.UnitsInStock > 0)
                       select new
                       {
                           Category = pg.Key,
                       };
            foreach (var group in list)
            {
                Console.WriteLine(group.Category);
                Console.WriteLine("==================");
            }

        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            var results = from num in DataLoader.NumbersA
                          where num % 2 != 0
                          select num;
            var count = from numbers in results
                        select numbers;
            Console.WriteLine(count.Count());
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            var results = from cust in DataLoader.LoadCustomers()
                          select new
                          {
                              CustomerID = cust.CustomerID,
                              OrderCount = cust.Orders.Count()
                          };
            foreach(var customer in results)
            {
                Console.WriteLine(customer.CustomerID);
                Console.WriteLine($"\t{ customer.OrderCount}");
                Console.WriteLine("==========================");
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            //var list = from prod in DataLoader.LoadProducts()
            //           select prod;
            //var categories = from cats in list
            //                 select new
            //                 {
            //                     Category = cats.Category,
            //                     prodCount = cats.ProductName.Count()
            //                 };
            //var groupOfCats = from groups in categories.Distinct()
            //                  group groups by groups.Category;
            //foreach (var group in groupOfCats)
            //{
            //    Console.WriteLine(group.Key);
                
            //    Console.WriteLine("==================");
            //}

            var list = from prod in DataLoader.LoadProducts()
                       select prod;
            var categories = from prods in list
                             select new
                             {
                                 Category = prods.Category,
                                 //ProdName = prods.ProductName
                             };
            var groupOfCats = from p in categories.Distinct()
                              group p by p.Category into pg
                              select new
                              {
                                  GroupCat = pg.Key,
                                  ProdCount = pg.Count()
                              };
            foreach (var group in groupOfCats)
            {
                Console.WriteLine(group.GroupCat);
                Console.WriteLine($"\t{group.ProdCount}");
                Console.WriteLine("==================");
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            var list = from prod in DataLoader.LoadProducts()
                       select prod;
            var categories = from prods in list
                             select new
                             {
                                 Category = prods.Category,
                                 UnitsInStock = prods.UnitsInStock
                             };
            var groupOfCats = from p in categories.Distinct()
                              group p by p.Category into pg
                              select new
                              {
                                  GroupCat = pg.Key,
                                  GroupUnits = pg.Sum(p=>p.UnitsInStock)
                              };
            foreach (var group in groupOfCats)
            {
                Console.WriteLine(group.GroupCat);
                Console.WriteLine($"\t{group.GroupUnits}");
                Console.WriteLine("==================");
            }



            //var list = from prod in DataLoader.LoadProducts()
            //           select prod;
            //var categories = from cats in list
            //                 select new
            //                 {
            //                     Category = cats.Category
            //                 };
            //var groupOfCats = from groups in categories.Distinct()
            //                  group groups by groups.Category;
            //foreach (var group in groupOfCats)
            //{
            //    Console.WriteLine(group.Key);
            //    Console.WriteLine("==================");
            //}
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            var list = from prod in DataLoader.LoadProducts()
                       group prod by prod.Category into pg
                       let lowPrice = pg.Min(p => p.UnitPrice)
                       select new
                       {
                           Category = pg.Key,
                           LowestProd = from p in pg
                                        where p.UnitPrice == lowPrice
                                        select new
                                        {
                                            ProdName = p.ProductName
                                        }
                       };
            foreach(var group in list)
            {
                Console.WriteLine(group.Category);
                foreach(var cat in group.LowestProd)
                {
                    Console.WriteLine($"\t{cat.ProdName}");
                }
                Console.WriteLine("==========================================");
            }
            /*pg.Where(p=>p.UnitPrice==lowPrice)*/

            //var categories = from cats in list
            //                 select new
            //                 {
            //                     Category = cats.Category
            //                 };
            //var groupOfCats = from groups in categories.Distinct()
            //                  group groups by groups.Category;
            //foreach (var group in groupOfCats)
            //{
            //    Console.WriteLine(group.Key);
            //    Console.WriteLine("==================");
            //}


            //var list = from prod in DataLoader.LoadProducts()
            //           select prod;
            //var groupedCategories = from prods in list
            //                        group prods by prods.Category into pg
            //                        select new
            //                        {
            //                            ProdCat = pg.Key,


            //                        };
            //foreach (var cat in groupedCategories)
            //{
            //    Console.WriteLine(cat.ProdCat);

            //}

        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            //var list = from prod in DataLoader.LoadProducts()
            //           select prod;
            //var categories = from cats in list
            //                 select new
            //                 {
            //                     Category = cats.Category
            //                 };
            //var groupOfCats = from groups in categories.Distinct()
            //                  group groups by groups.Category;
            //foreach (var group in groupOfCats)
            //{
            //    Console.WriteLine(group.Key);
            //    Console.WriteLine("==================");
            //}

            var list = from prod in DataLoader.LoadProducts()
                       select prod;
            var avgProductsByCategory = from prods in list
                                        group prods by prods.Category into prodGroup
                                        select new
                                        {
                                            Category = prodGroup.Key,
                                            AveragePrice = prodGroup.Average(p => p.UnitsInStock)
                                        };
            var orderedCats = from cats in avgProductsByCategory.Distinct()
                               orderby cats.AveragePrice
                               select cats;
            var topThree = from groups in orderedCats.Take(3)
                           select groups;
            foreach(var category in topThree)
            {
                Console.WriteLine(category.Category);
            }





        }
    }
}
