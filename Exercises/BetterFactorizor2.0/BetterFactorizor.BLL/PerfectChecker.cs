using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterFactorizor.BLL
{
    //find if a number's factors can be added to equal the number, besides the factor that is equal to the number
    public class PerfectChecker
    {
        public int _myNumber { get; }
        public bool IsPerfect { get; set; }
        public int[] FactorsFound { get; set; }

        public PerfectChecker(int number)
        {
            FactorFinder myFinder = new FactorFinder(number);
            _myNumber = myFinder.GetMyNumber();
            FactorsFound = myFinder.Factors;
            int count = 0;
            for (int i = 1; i <= _myNumber; i++)
            {
                if (_myNumber % i == 0)
                    count++;
            }

            FactorsFound = new int[count];
            count = 0;
            for (int i = 1; i <= _myNumber; i++)
            {
                if (_myNumber % i == 0)
                {
                    FactorsFound[count] = i;
                    count++;
                }

                
            }

            int sum = 0;
            for (int i = 0; i < FactorsFound.Length-1; i++)
            {
                sum += FactorsFound[i];
            }
            if (sum == _myNumber)
                IsPerfect = true;
            else
            {
                IsPerfect = false;
            }
        }

        public int GetMyNumber()
        {
            return _myNumber;
        }
    }
}
