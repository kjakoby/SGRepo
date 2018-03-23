using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Factorizor!");
            int number = GetNumberFromUser();

            Calculator.PrintFactors(number);
            Calculator.IsPerfectNumber(number);
            Calculator.IsPrimeNumber(number);
            Console.WriteLine();
            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Prompt the user for an integer.  Make sure they enter a valid integer!
        /// 
        /// See the String Input lesson for TryParse() examples
        /// </summary>
        /// <returns>the user input as an integer</returns>
        static int GetNumberFromUser()
        {
            int number;
            //bool isParsed = false;

            while (true)
            {
                Console.Write("Please enter a number:\t");
                string response = Console.ReadLine();
                if (int.TryParse(response, out number) && number>0)
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("That was not a valid number!");
                }
            }
        }
    }

    class Calculator
    {
        /// <summary>
        /// Given a number, print the factors per the specification
        /// </summary>
        public static void PrintFactors(int number)
        {
            Console.Write($"The factors of {number} are: ");
            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                {
                    Console.Write($"{i}, ");
                }
                else
                {
                    continue;
                }
            }
            Console.Write(number);
            Console.WriteLine();
        }

        /// <summary>
        /// Given a number, print if it is perfect or not
        /// </summary>
        public static void IsPerfectNumber(int number)
        {
            int sum = 0;
            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                {
                    sum += i;
                }
                else
                {
                    continue;
                }
            }
            if (sum == number)
            {
                Console.WriteLine($"{number} is a Perfect Number.");
            }
            else
            {
                Console.WriteLine($"{number} is not a Perfect Number.");
            }
        }

        /// <summary>
        /// Given a number, print if it is prime or not
        /// </summary>
        public static void IsPrimeNumber(int number)
        {
            bool prime = false;
            int factors = 0;
            for (int i = 1; i <=number; i++)
            {
               if (number % i == 0)
               {
                    factors++;
               }

               if(factors == 2)
               {
                    prime = true;
               }
                else
                {
                    continue;
                }
            }

            if (prime==true)
            {
                Console.WriteLine($"{number} is a Prime Number.");
            }
            else
            {
                Console.WriteLine($"{number} is not a Prime Number.");
            }
        }
    }
}
