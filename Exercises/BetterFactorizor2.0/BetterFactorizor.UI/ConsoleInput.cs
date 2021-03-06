﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterFactorizor.UI
{
    public class ConsoleInput
    {
        public static int GetNumberFromUser()
        {
            ConsoleOutput.PromptForNumber();
            int output;
            bool isNumber;
            //ConsoleOutput prompt = new ConsoleOutput();

            do
            {
                string input = Console.ReadLine();
                //ConsoleOutput.PromptForNumber();
                //Console.ReadKey();
                isNumber = int.TryParse(input, out output);
                if (!isNumber)
                    ConsoleOutput.DisplayInvalid();
            } while (!isNumber);
            return output;

            //int output;
            //string input;
            ////bool isValid = false;

            //while (true)
            //{
            //    input = Console.ReadLine();
            //    if (int.TryParse(input, out output))
            //    {
            //        //isValid = true;
            //        return output;
            //    }
            //    else
            //    {
            //        ConsoleOutput.DisplayInvalid();
            //        continue;
            //    }
            //}
        }

        public static ConsoleKeyInfo ContinueOrQuit()
        {
            //ConsoleOutput.ContinueOrQuitMessage;
            return Console.ReadKey();
        }
    }
}
