using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    public class GameWorkflow
    {
        //public GameManager MyManager { get; set; }
        //public SetupWorkflow SetupGame { get; set; }
        private ShotHistory currentShot;
        public void RunProg()
        {
            ConsoleOutput.DisplayTitle();
            Console.Clear();
            ConsoleKeyInfo keyPressed;
            

            do
            {
                mySetup = new SetupWorkflow();
                //myManager = new GameManager();
                SetupWorkflow.SetupPlayers();
                SetupWorkflow.SetupBoard();
                int firstTurn = myManager.RandomTurn();
                //if(firstTurn==0)

                keyPressed = ConsoleInput.ContinueOrQuit();

                Console.Clear();
            } while (!(keyPressed.Key == ConsoleKey.Q));
        }
    }
}
