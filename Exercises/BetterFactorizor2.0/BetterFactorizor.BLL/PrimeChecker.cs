using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterFactorizor.BLL
{
    //find if number has only 2 factors
    public class PrimeChecker
    {
        public bool IsPrime { get; set; }
        public int myNumber { get; }
        public int[] FactorsFound { get; set; }

        public PrimeChecker(int number)
        {
            FactorFinder myFinder = new FactorFinder(number);
            myNumber = myFinder.GetMyNumber();
            FactorsFound = myFinder.Factors;

            int count = 0;
            for (int i = 1; i <= myNumber; i++)
            {
                if (myNumber % i == 0)
                    count++;
            }

            FactorsFound = new int[count];
            count = 0;
            for (int i = 1; i <= myNumber; i++)
            {
                if (myNumber % i == 0)
                {
                    FactorsFound[count] = i;
                    count++;
                }


            }

            if (FactorsFound.Length == 2)
                IsPrime = true;
            else
                IsPrime = false;

        }

        public int GetMyNumber()
        {
            return myNumber;
        }
    }
}
