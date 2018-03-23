using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterFactorizor.BLL
{
    public class WorkManager
    {
        public void Start()
        {

        }

        public FactorFinder ProcessNumber(int number)
        {
            return new FactorFinder(number);
        }

        public PerfectChecker ProcessPerfect(int number)
        {
            return new PerfectChecker(number);
        }

        public PrimeChecker ProcessPrime(int number)
        {
            return new PrimeChecker(number);
        }
    }
}
