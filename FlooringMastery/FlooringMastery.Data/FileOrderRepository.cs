using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using System.IO;
using System.Text.RegularExpressions;

namespace FlooringMastery.Data
{
    public class FileOrderRepository : IOrderRepository
    {
        private Dictionary<int, Order> _orderIndex;
        private static string orderFile = @"D:\SoftwareGuild\LocalDataFiles\FlooringMastery\MediumPlus\Orders_";
        private static string fileEXT = ".txt";
        private string fullPath;

        //private string fileName = Path.GetFileNameWithoutExtension(orderFile);

        public FileOrderRepository(DateTime date)
        {
            fullPath = orderFile + date.ToString("MMddyyyy") + fileEXT;
            _orderIndex = new Dictionary<int, Order>();

            //if (!File.Exists(fullPath))
            //{
            //    Console.WriteLine();
            //    Console.WriteLine("There is no order on that date!");
            //    Console.ReadKey();
            //    //File.Create(fullPath);
            //}
            if(File.Exists(fullPath))
            //else
            {
                using (StreamReader reader = new StreamReader(fullPath))
                {
                    reader.ReadLine();
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        Order order = new Order();
                        string[] values = line.Split(',');
                        if (values.Length == 12)
                        {
                            int key = int.Parse(values[0]);
                            string goodName = values[1]/*.Replace(';', ',')*/;
                            string name = goodName;
                            string state = values[2];
                            decimal taxrate = decimal.Parse(values[3]);
                            string prodType = values[4];
                            decimal area = decimal.Parse(values[5]);
                            decimal cost = decimal.Parse(values[6]);
                            decimal labor = decimal.Parse(values[7]);
                            decimal materialCost = decimal.Parse(values[8]);
                            decimal laborCost = decimal.Parse(values[9]);
                            decimal tax = decimal.Parse(values[10]);
                            decimal total = decimal.Parse(values[11]);
                            _orderIndex.Add(key, new Order()
                            {
                                OrderDate = date,
                                OrderNumber = key,
                                CustomerName = name,
                                State = state,
                                TaxRate = taxrate,
                                ProductType = prodType,
                                Area = area,
                                CostPerSquareFoot = cost,
                                LaborCostPerSquareFoot = labor,
                                MaterialCost = materialCost,
                                LaborCost = laborCost,
                                Tax = tax,
                                Total = total
                            });
                        }
                        if (values.Length > 12)
                        {
                            int key = int.Parse(values[0]);
                            string goodName = values[1]+", "+values[2];
                            string name = goodName.Substring(1,goodName.Length-2);
                            string state = values[3];
                            decimal taxrate = decimal.Parse(values[4]);
                            string prodType = values[5];
                            decimal area = decimal.Parse(values[6]);
                            decimal cost = decimal.Parse(values[7]);
                            decimal labor = decimal.Parse(values[8]);
                            decimal materialCost = decimal.Parse(values[9]);
                            decimal laborCost = decimal.Parse(values[10]);
                            decimal tax = decimal.Parse(values[11]);
                            decimal total = decimal.Parse(values[12]);
                            _orderIndex.Add(key, new Order()
                            {
                                OrderDate = date,
                                OrderNumber = key,
                                CustomerName = name,
                                State = state,
                                TaxRate = taxrate,
                                ProductType = prodType,
                                Area = area,
                                CostPerSquareFoot = cost,
                                LaborCostPerSquareFoot = labor,
                                MaterialCost = materialCost,
                                LaborCost = laborCost,
                                Tax = tax,
                                Total = total
                            });
                        }
                        //Order order = new Order();
                        //string[] values = line.Split(',');
                        ////for (int i = 1; i < values.Length-10; i++)
                        ////{
                        ////    string name = values[i];

                        ////}
                        //string state2 = values[values.Length - 10];
                        //string taxrate2 = values[values.Length - 9];
                        //string prodType2 = values[values.Length - 8];
                        //string area2 = values[values.Length - 7];
                        //string cost2 = values[values.Length - 6];
                        //string labor2 = values[values.Length - 5];
                        //string materialCost2 = values[values.Length - 4];
                        //string laborCost2 = values[values.Length - 3];
                        //string tax2 = values[values.Length - 2];
                        //string total2 = values[values.Length - 1];

                        //string secondHalf = state2 + taxrate2 + prodType2 + area2 + cost2 + labor2 + materialCost2 + laborCost2 + tax2 + total2;
                        //string full = values.ToString();

                        ////string[] secondA = second.Split(',');
                        //if (values.Length == 12)
                        //{
                        //    int key = int.Parse(values[0]);
                        //    string name = values[1];
                        //    //string state = values[2];
                        //    string state = state2;
                        //    //decimal taxrate = decimal.Parse(values[3]);
                        //    decimal taxrate = decimal.Parse(taxrate2);
                        //    //string prodType = values[4];
                        //    string prodType = prodType2;
                        //    //decimal area = decimal.Parse(values[5]);
                        //    decimal area = decimal.Parse(area2);
                        //    //decimal cost = decimal.Parse(values[6]);
                        //    decimal cost = decimal.Parse(cost2);
                        //    //decimal labor = decimal.Parse(values[7]);
                        //    decimal labor = decimal.Parse(labor2);
                        //    //decimal materialCost = decimal.Parse(values[8]);
                        //    decimal materialCost = decimal.Parse(materialCost2);
                        //    //decimal laborCost = decimal.Parse(values[9]);
                        //    decimal laborCost = decimal.Parse(laborCost2);
                        //    //decimal tax = decimal.Parse(values[10]);
                        //    decimal tax = decimal.Parse(tax2);
                        //    //decimal total = decimal.Parse(values[11]);
                        //    decimal total = decimal.Parse(total2);
                        //    _orderIndex.Add(key, new Order()
                        //    {
                        //        OrderDate = date,
                        //        OrderNumber = key,
                        //        CustomerName = name,
                        //        State = state,
                        //        TaxRate = taxrate,
                        //        ProductType = prodType,
                        //        Area = area,
                        //        CostPerSquareFoot = cost,
                        //        LaborCostPerSquareFoot = labor,
                        //        MaterialCost = materialCost,
                        //        LaborCost = laborCost,
                        //        Tax = tax,
                        //        Total = total
                        //    });
                        //}
                        //if (values.Length > 12)
                        //{
                        //    int key = int.Parse(values[0]);
                        //    string name = values[1] + values[2];
                        //    string state = values[3];
                        //    decimal taxrate = decimal.Parse(values[4]);
                        //    string prodType = values[5];
                        //    decimal area = decimal.Parse(values[6]);
                        //    decimal cost = decimal.Parse(values[7]);
                        //    decimal labor = decimal.Parse(values[8]);
                        //    decimal materialCost = decimal.Parse(values[9]);
                        //    decimal laborCost = decimal.Parse(values[10]);
                        //    decimal tax = decimal.Parse(values[11]);
                        //    decimal total = decimal.Parse(values[12]);
                        //    _orderIndex.Add(key, new Order()
                        //    {
                        //        OrderDate = date,
                        //        OrderNumber = key,
                        //        CustomerName = name,
                        //        State = state,
                        //        TaxRate = taxrate,
                        //        ProductType = prodType,
                        //        Area = area,
                        //        CostPerSquareFoot = cost,
                        //        LaborCostPerSquareFoot = labor,
                        //        MaterialCost = materialCost,
                        //        LaborCost = laborCost,
                        //        Tax = tax,
                        //        Total = total
                        //    });
                        //}
                    }
                }
            }
            //} while (!fileExists);
        }

        public bool FileExists()
        {
            if (File.Exists(fullPath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SaveOrder(Order newOrder)
        {
            int newKey;

            if (_orderIndex.Count > 0)
            {
                newKey = _orderIndex.Keys.Max(i => i) + 1;
            }
            else
            {
                newKey = 1;
            }
            _orderIndex.Add(newKey, newOrder);
            //if (_orderIndex.ContainsKey(newKey))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        public bool RemoveOrder(int orderNumber)
        {
            if (_orderIndex.Keys.Contains(orderNumber))
            {
                _orderIndex.Remove(orderNumber);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Dictionary<int, Order> GetAllOrders(DateTime date)
        {
            if (!File.Exists(fullPath))
            {
                Console.WriteLine($"{date.ToShortDateString()} does not have any orders associated!");
                return _orderIndex;
                //File.Create(fullPath);
            }
            else
            {

                return _orderIndex;
            }


        }

        public Order GetOrder(int id)
        {
            if (_orderIndex.Keys.Contains(id))
            {
                return _orderIndex[id];
            }
            else
            {
                return null;
            }
        }

        //public void CloseRepo()
        //{
        //    using (StreamWriter writer = new StreamWriter(orderFile))
        //    {
        //        foreach (KeyValuePair<int,Order> kv in _orderIndex)
        //        {
        //            if (kv.Value!=null)
        //            {
        //                writer.WriteLine($"{kv.Key},{kv.Value.CustomerName},{kv.Value.State},{kv.Value.TaxRate},{kv.Value.ProductType},{kv.Value.Area},{kv.Value.CostPerSquareFoot},{kv.Value.LaborCostPerSquareFoot},{kv.Value.MaterialCost},{kv.Value.LaborCost},{kv.Value.Tax},{kv.Value.Total}");
        //            }
        //        }
        //    }
        //}

        public Order LoadOrder(int orderNumber)
        {
            throw new NotImplementedException();
        }

        public bool LastOrder()
        {
            if (_orderIndex.Count==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteOrderFile()
        {
            File.Delete(fullPath);
        }


        public void CloseRepo(Order order)
        {
            //if (_orderIndex.Count>0)
            //{
            //using (StreamWriter writer = new StreamWriter(fullPath))
            //{
            //    writer.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
            //    foreach (KeyValuePair<int, Order> kv in _orderIndex)
            //    {
            //        if (kv.Value != null)
            //        {
            //        if (kv.Value.CustomerName.Contains(","))
            //        {
            //            string[] splitName = kv.Value.CustomerName.Split(',');
            //            string validName = splitName[0] + "','" + splitName[1];
            //        }
            //        else
            //        {
            //            string validName = kv.Value.CustomerName;
            //        }
            //            writer.WriteLine($"{kv.Key},{kv.Value.CustomerName},{kv.Value.State},{kv.Value.TaxRate},{kv.Value.ProductType},{kv.Value.Area},{kv.Value.CostPerSquareFoot},{kv.Value.LaborCostPerSquareFoot},{kv.Value.MaterialCost},{kv.Value.LaborCost},{kv.Value.Tax},{kv.Value.Total}");
            //        }
            //        //else
            //        //{
            //        //    File.Delete(fullPath);
            //        //}
            //    }
            //}
            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                string validName;
                writer.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                foreach (KeyValuePair<int, Order> kv in _orderIndex)
                {
                    if (kv.Value != null)
                    {
                        if (kv.Value.CustomerName.Contains(","))
                        {
                            validName = '"'+kv.Value.CustomerName+'"';

                        }
                        else
                        {
                            validName = kv.Value.CustomerName;
                        }
                        writer.WriteLine($"{kv.Key},{validName},{kv.Value.State},{kv.Value.TaxRate},{kv.Value.ProductType},{kv.Value.Area},{kv.Value.CostPerSquareFoot},{kv.Value.LaborCostPerSquareFoot},{kv.Value.MaterialCost},{kv.Value.LaborCost},{kv.Value.Tax},{kv.Value.Total}");
                    }
                    //else
                    //{
                    //    File.Delete(fullPath);
                    //}
                }
            }
            //}            
        }

        public Order GetSingleOrder(int orderNumber, DateTime date)
        {
            var foundOrder = _orderIndex.Where(v => v.Value.OrderDate == date);
            if (foundOrder == null)
            {
                return null;
            }
            else
            {
                if (_orderIndex.Keys.Contains(orderNumber))
                {
                    return _orderIndex[orderNumber];
                }
                else
                {
                    return null;
                }
            }
        }

        public Order GetLastOrder(DateTime date)
        {
            var foundOrder = _orderIndex.Where(v => v.Value.OrderDate == date);
            KeyValuePair<int, Order> lastOrderList = foundOrder.FirstOrDefault(o => o.Value == foundOrder);
            Order order = lastOrderList.Value;

            if (foundOrder == null)
            {
                return null;
            }
            else
            {
                return order;
            }
        }

        public Dictionary<int, Order> DeleteOrder(int orderNumber)
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

        //public void RemoveOrder(int orderNumber)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
