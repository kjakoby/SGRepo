using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TractorDex.BLL.Models;

namespace TractorDex.UI
{
    public class ConsoleIO
    {
        internal static void WriteWelcome()
        {
            Console.WriteLine("Welcome to our Tractor Index.");
            PressAnyKey();
        }

        internal static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Please select from the following menu items:");
            Console.WriteLine("1. View all tractors ");
            Console.WriteLine("2. View a tractor by key");
            Console.WriteLine("3. Add a tractor ");
            Console.WriteLine("4. Update a tractor ");
            Console.WriteLine("5. Delete a tractor ");
            Console.Write("Enter your selection (or any other number to exit): ");
            //Console.ReadKey();
        }

        internal static int GetSelection()
        {
            string entry = "";
            int selection = -1;
            bool validEntry = true;
            do
            {
                entry = Console.ReadLine();
                validEntry = int.TryParse(entry, out selection);
                if (!validEntry)
                    Console.Write("Please enter a valid value: ");

            } while (!validEntry);

            return selection;
            

        }

        internal static void WriteAllTractors(Dictionary<int, Tractor> tractorDictionary)
        {
            foreach(KeyValuePair<int,Tractor> kv in tractorDictionary)
            {
                Console.WriteLine($"Tractor at key: {kv.Key}");
                if (kv.Value!=null)
                {
                    WriteTractor(kv.Value);
                    Console.WriteLine("==========================================");
                }
            }
            PressAnyKey();
        }

        internal static Tractor GetTractorFromUser(Tractor tractor)
        {
            if (tractor != null)
            {
                string tempName = GetStringFromUser($"Please give the new name or hit enter to keep\t{tractor.Name}: ");
                if (!string.IsNullOrEmpty(tempName))
                {
                    tractor.Name = tempName;
                }
                string tempDriver = GetStringFromUser($"Please give the new driver or hit enter to keep\t{tractor.Driver}: ");
                if (!string.IsNullOrEmpty(tempDriver))
                {
                    tractor.Driver = tempDriver;
                }
                string entry = "";
                int selection = -1;
                bool validEntry = false;
                Console.Write($"Please enter a new weight or hit enter to keep\t  {tractor.Weight}: ");
                do
                {
                    entry = Console.ReadLine();
                    if (!string.IsNullOrEmpty(entry))
                    {
                        validEntry = int.TryParse(entry, out selection);
                        if (validEntry)
                        {
                            tractor.Weight = selection;
                        }
                    }
                    else
                    {
                        validEntry = true;
                    }
                    if (!validEntry)
                        Console.Write("Please enter a valid value: ");

                } while (!validEntry);
            }
            else
            {
                Console.WriteLine("No tractor was found.");
            }
            return tractor;
        }

        internal static int GetTractorKeyFromUser()
        {
            Console.Clear();
            Console.Write("Please enter a tractor key to search by (Valid keys are a whole number): ");
            return GetSelection();
        }

        internal static void WriteTractor(Tractor current)
        {
            if (current!=null)
            {
                Console.WriteLine($"Tractor Name is: {current.Name}");
                Console.WriteLine($"Tractor Driver is: {current.Driver}");
                Console.WriteLine($"Tractor Weight is: {current.Weight}");
            }
            else
                Console.WriteLine("No tractor to write.");
            
        }

        internal static void ConfirmDelete(Tractor deletedTractor)
        {
            Console.WriteLine("Tractor has been deleted: ");
            WriteTractor(deletedTractor);
            Console.ReadKey();
        }

        internal static void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        internal static void FieldCantBeBlank()
        {
            Console.WriteLine("This field can not be blank! Please try again.");
        }

        internal static Tractor GetTractorFromUser()
        {
            bool IsEmpty;
            Tractor userTractor = new Tractor();
            do
            {
                IsEmpty = true;
                userTractor.Name = GetStringFromUser("Please give the name of your Tractor: ");
                if(userTractor.Name == "" || userTractor.Name == " ")
                {
                    FieldCantBeBlank();
                    continue;
                }
                IsEmpty = false;
            } while (IsEmpty);
            do
            {
                IsEmpty = true;
                userTractor.Driver = GetStringFromUser("Please give the driver of your Tractor: ");
                if (userTractor.Driver == "" || userTractor.Driver == " ")
                {
                    FieldCantBeBlank();
                    continue;
                }
                IsEmpty = false;
            } while (IsEmpty);
            do
            {
                IsEmpty = true;
                Console.Write("Enter the Tractor Weight: ");
                userTractor.Weight = GetSelection();
                if (userTractor.Weight == 0)
                {
                    FieldCantBeBlank();
                    continue;
                }
                IsEmpty = false;
            } while (IsEmpty);

            
            
            return userTractor;
        }

        private static string GetStringFromUser(string v)
        {
            Console.Write(v);
            return Console.ReadLine();
        }
    }
}
