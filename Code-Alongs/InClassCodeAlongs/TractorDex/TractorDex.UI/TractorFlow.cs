using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TractorDex.BLL;
using TractorDex.BLL.Models;

namespace TractorDex.UI
{
    public class TractorFlow
    {
        public TractorManager MyTractorManager { get; set; }

        public void Start()
        {
            bool keepRunning = true;
            MyTractorManager = new TractorManager();
            int userKey = -1;
            ConsoleIO.WriteWelcome();
            

            do
            {
                ConsoleIO.PrintMenu();
                switch (ConsoleIO.GetSelection())
                {
                    case 1:
                        Console.Clear();
                        Dictionary<int, Tractor> tractorDictionary = MyTractorManager.GetAllTractors();
                        ConsoleIO.WriteAllTractors(tractorDictionary);
                        break;
                    case 2:
                        int key = ConsoleIO.GetTractorKeyFromUser();
                        Tractor current = MyTractorManager.GetATractorByKey(key);
                        ConsoleIO.WriteTractor(current);
                        ConsoleIO.PressAnyKey();
                        break;
                    case 3:
                        Tractor newTractor = ConsoleIO.GetTractorFromUser();
                        MyTractorManager.AddTractor(newTractor);
                        break;
                    case 4:
                        userKey = ConsoleIO.GetTractorKeyFromUser();
                        Tractor updatedTractor = ConsoleIO.GetTractorFromUser(MyTractorManager.GetATractorByKey(userKey));
                        MyTractorManager.UpdateTractor(userKey, updatedTractor);
                        break;
                    case 5:
                        userKey = ConsoleIO.GetTractorKeyFromUser();
                        Tractor deletedTractor = MyTractorManager.DeleteTractor(userKey);
                        ConsoleIO.ConfirmDelete(deletedTractor);
                        break;
                    default:
                        keepRunning = false ;
                        break;
                }
            } while (keepRunning);

            MyTractorManager.CloseManager();
        }
    }
}
