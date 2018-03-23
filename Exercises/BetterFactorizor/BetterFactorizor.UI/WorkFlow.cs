using BetterFactorizor.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterFactorizor.UI
{
    public class WorkFlow
    {
        public LogicManager Manager { get; set; }

        public void Factorize()
        {
            Manager = new LogicManager();

            int numberToFactor = ConsoleInput.GetNumberFromUser();
            FactorFinder factorResults = Manager.CalculateFactors(numberToFactor);
            

        }
    }
}
