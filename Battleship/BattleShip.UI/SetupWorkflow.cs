using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class SetupWorkflow
    {
        //private static ShotHistory currentShot;
        public Player player1 { get; set; }
        public Player player2 { get; set; }

        public void SetupPlayers()
        {
            player1 = new Player();
            player2 = new Player();
            player1.Name = ConsoleInput.GetPlayerName();
            player2.Name = ConsoleInput.GetPlayerName();
            //Board p1board = new Board();
            //Board p2board = new Board();

            
            //ConsoleOutput.DrawBoard(p1board, currentShot);
        }

        public Board SetupBoard(Player currentPlayer)
        {
            Board p1board = currentPlayer.Board;

            PlaceDestroyer(p1board);
            PlaceCruiser(p1board);
            PlaceSubmarine(p1board);
            PlaceBattleship(p1board);
            PlaceCarrier(p1board);

            return p1board;
        }

        //Board p1board = ConsoleOutput.DrawBoard();
        //public void DrawBoard(Board myBoard, ShotHistory currentShot)
        //{
        //    Coordinate myCoord;
        //    ShotHistory checkedShot;
        //    for (int i = 1; i < 11; i++)
        //    {
        //        for (int j = 1; j < 11; j++)
        //        {
        //            myCoord = new Coordinate(i, j);
        //            checkedShot = myBoard.CheckCoordinate(myCoord);
        //            if (checkedShot == ShotHistory.Unknown)
        //            {
        //                Console.Write(" ");
        //            }
        //            else
        //            {
        //                if (checkedShot == currentShot || currentShot == ShotHistory.Hit)
        //                {
        //                    Console.ForegroundColor = ConsoleColor.Red;
        //                    Console.Write(checkedShot);
        //                    Console.ResetColor();
        //                }
        //                else
        //                {
        //                    Console.ForegroundColor = ConsoleColor.Green;
        //                    Console.Write(" ");
        //                    Console.ResetColor();
        //                }
        //            }
        //            if (j % 10 != 0)
        //                Console.Write("|");
        //        }
        //        Console.WriteLine();
        //        if (i % 10 != 0)
        //            Console.WriteLine("-------------------");
        //    }
        //}
    }
}
