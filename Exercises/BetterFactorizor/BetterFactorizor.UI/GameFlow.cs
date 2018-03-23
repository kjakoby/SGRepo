using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetterFactorizor.BLL;

namespace BetterFactorizor.UI
{
    public class GameFlow
    {
        public void Start()
        {
            ConsoleOutput.DisplayTitle();

            Calculations result;
            int number;

            do
            {
                number = ConsoleInput.GetNumberFromUser();
                result = 
                //ConsoleOutput.DisplayFactors();
            } while (result == Calculations.Invalid);
        }

        private bool IsValidNumber(int number)
        {
            if (number >= 1)
                return true;
            else
                return false;
        }

        public Calculations ProcessNumber (int number)
        {
            if (!IsValidNumber(number))
                return Calculations.Invalid;
            else if ()

        }

        //public Calculations ProcessNumber(int number)
        //{
        //    if ()
        //}
    }
}
