using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterFactorizor.BLL
{
    public class LogicManager
    {
        public FactorFinder CalculateFactors(int number)
        {
            return new FactorFinder(number);
        }

        public PerfectChecker GetPerfectChecker(int number)
        {
            Console.WriteLine($"{number} is a Perfect Number.");
        }

        //public int GetMyNumber()
        //{
        //    return _myNumber;
        //}
    }
}
