using BetterFactorizor.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterFactorizor.UI
{
    public class ConsoleOutput
    {
        public static void DisplayTitle()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Better, Testable, Factorizor!");
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();
        }

        public static void PromptForNumber()
        {
            Console.Write("Enter a number to factor: ");
        }

        public static void DisplayFactors(FactorFinder value)
        {
            string factors = "";
            factors = string.Join(", ", value.Factors);
            Console.WriteLine($"The factors of {value.GetMyNumber()} are: {factors} ");
        }

        public static void DisplayPerfect(PerfectChecker value)
        {
            if (value.IsPerfect)
                Console.WriteLine($"{value.GetMyNumber()} is perfect.");
            else
                Console.WriteLine($"{value.GetMyNumber()} is not perfect.");
        }

        public static void DisplayPrime(PrimeChecker value)
        {
            if (value.IsPrime)
                Console.WriteLine($"{value.GetMyNumber()} is prime.");
            else
                Console.WriteLine($"{value.GetMyNumber()} is not prime.");
        }

        //public static void DisplayCalculations(Calculations results)
        //{
        //    switch (results)
        //    {
        //        case Calculations.Prime:
        //            DisplayPrime();
        //            break;
        //        case Calculations.NotPrime:
        //            DisplayNotPrime();
        //            break;
        //        case Calculations.Perfect:
        //            DisplayPerfect();
        //            break;
        //        case Calculations.NotPerfect:
        //            DisplayNotPerfect();
        //            break;
        //        case Calculations.Invalid:
        //            DisplayInvalid();
        //            break;
        //        default:
        //            break;
        //    }
        //}

        //public static void DisplayPrime(FactorFinder value)
        //{
        //    Console.WriteLine($"{value.GetMyNumber()} is Prime.");

        //}

        //public static void DisplayNotPrime(FactorFinder value)
        //{
        //    Console.WriteLine($"{value.GetMyNumber()} is not Prime.");

        //}

        //public static void DisplayPerfect(FactorFinder value)
        //{
        //    Console.WriteLine($"{value.GetMyNumber()} is perfect.");
        //}

        //public static void DisplayNotPerfect(FactorFinder value)
        //{
        //    Console.WriteLine($"{value.GetMyNumber()} is not perfect.");
        //}

        public static void DisplayInvalid()
        {
            Console.WriteLine("That was not a valid number!");
            Console.Write("Please try a different number: ");
        }

        public static void ContinueOrQuitMessage()
        {
            Console.WriteLine("Press any key to play again (Press \"Q\" or \"q\" to quit)");
            //Console.ReadKey();
        }
    }
}
