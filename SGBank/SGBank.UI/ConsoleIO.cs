using SGBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI
{
    public class ConsoleIO
    {
        public static void DisplayAccountDetails(Account account)
        {
            Console.WriteLine($"Account Number: {account.AccountNumber}");
            Console.WriteLine($"Name: {account.Name}");
            Console.WriteLine($"Balance: {account.Balance:c}");
        }

        internal static decimal GetNumber(string type)
        {
            while (true)
            {
                Console.Write($"Enter a {type} amount: ");
                decimal answer;
                string response = Console.ReadLine();
                if (decimal.TryParse(response, out answer))
                {
                    return answer;
                }
                else
                {
                    Console.WriteLine("That is not a valid number!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            
        }
    }
}
