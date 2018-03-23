using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterFactorizor.BLL
{
    public class PrimeChecker
    {
        private int _myNumber;
        public bool IsPrime { get; set; }

        public PrimeChecker (int number)
        {
            _myNumber = number;
            int factors;
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    factors++;
                }

                if (factors == 2)
                {
                    IsPrime = true;
                }
                else
                {
                    continue;
                }
            }

            if (IsPrime == true)
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
