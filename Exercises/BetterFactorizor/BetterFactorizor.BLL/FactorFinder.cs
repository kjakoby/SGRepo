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
        //public int[] factorList;
        public int[] FactorList { get; set; }

        public FactorFinder(int number)
        {
            _myNumber = number;
            int currentIndex = 0;
            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                {
                    FactorList[currentIndex]=i;
                    currentIndex++;
                    break;
                }
                else
                {
                    continue;
                }
            }
            //return FactorList;
        }

        public int GetMyNumber()
        {
            return _myNumber;
        }
    }
}
