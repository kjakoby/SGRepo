using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterFactorizor.BLL
{
    public class FactorFinder
    {
        private int _myNumber;
        //public int _myNumber { get; private set; }
        public int[] Factors { get; set; }

        public FactorFinder (int numToCalculate)
        {
            _myNumber = numToCalculate;
            int count = 0;
            for (int i = 1; i <= numToCalculate; i++)
            {
                if (numToCalculate % i == 0)
                    count++;
            }
            Factors = new int[count];
            count = 0;
            for (int i = 1; i <= numToCalculate; i++)
            {
                if (numToCalculate % i == 0)
                {
                    Factors[count] = i;
                    count++;
                }
            }
        }

        public int GetMyNumber()
        {
            return _myNumber;
        }
    }
}
