using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class ConsoleInput
    {
        public static string name { get; private set; }

        public static string GetPlayerName()
        {
            ConsoleOutput.AskForName();
            name = Console.ReadLine();
            //string givenName = name; Console.ReadLine()
            return name;
        }

        //public string GetPlayer2Name()
        //{
        //    string givenName = Console.ReadLine();
        //    ConsoleOutput.AskForName();
        //    return givenName;
        //}

        public static ConsoleKeyInfo ContinueOrQuit()
        {
            return Console.ReadKey();
        }
    }
}
