using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetterFactorizor.BLL;

namespace BetterFactorizor.UI
{
    public class WorkFlow
    {
        public WorkManager MyManager { get; set; }
        public void RunProg()
        {
            ConsoleOutput.DisplayTitle();
            Console.Clear();
            ConsoleKeyInfo keyPressed;
            do
            {
                MyManager = new WorkManager();

                int enteredNumber = ConsoleInput.GetNumberFromUser();

                FactorFinder factorResults = MyManager.ProcessNumber(enteredNumber);
                ConsoleOutput.DisplayFactors(factorResults);

                PerfectChecker perfectResults = MyManager.ProcessPerfect(enteredNumber);
                ConsoleOutput.DisplayPerfect(perfectResults);

                PrimeChecker primeResults = MyManager.ProcessPrime(enteredNumber);
                ConsoleOutput.DisplayPrime(primeResults);

                ConsoleOutput.ContinueOrQuitMessage();
                keyPressed = ConsoleInput.ContinueOrQuit();

                Console.Clear();

            } while (!(keyPressed.Key == ConsoleKey.Q));
        }
    }
}
