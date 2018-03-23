using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class ConsoleOutput
    {
        

        public static void DisplayTitle()
        {
            Console.WriteLine("Welcome to Battleship!");
            Console.WriteLine();
            Console.WriteLine("We will start by finding out who is playing.");
            Console.WriteLine();
            Console.WriteLine("Press any key to begin.");
            Console.ReadKey();
        }

        public static void AskForName()
        {
            Console.Write("Please enter the name for your player: ");
        }

        public static void CurrentPlayerTurn(string name)
        {
            Console.WriteLine($"{name} is the current player.");
        }

        public static void ContinueOrQuitMessage()
        {
            Console.WriteLine("Press any key to play again (Press \"Q\" to quit.)");
        }

        public static void ShipPlacementMessage(ShipType ship)
        {
            Console.WriteLine($"Lets place your {ship} on the board");
        }

        public static void AskForDirection(ShipType ship)
        {
            Console.Write($"Enter the direction you would like to place the {ship} (Up, Down, Left, Right): ");
        }

        //public static void AskForYCoord()
        //{
        //    Console.Write("Enter the coordinate you would like for the Y axis (1-10): ");
        //}

        //public static void AskForXCoord()
        //{
        //    Console.Write("Enter the coordinate you would like for the X axis (1-10): ");
        //}

        public static void AskForCoords()
        {
            Console.Write("Enter the coordinates you would like to use with a comma seperating the two coordinates(The first number is the y-axis, the second number is the x-axis): ");
        }

        public static void SwitchPlayerPrompt()
        {
            Console.Clear();
            Console.WriteLine("Your turn has ended.");
            Console.WriteLine("Please switch players.");
            Console.ReadKey();
        }

        public static void OverlappingMessage()
        {
            Console.WriteLine("This ship is overlapping another!");
            Console.WriteLine("Press any key to try again.");
            Console.ReadKey();
        }

        public static void NotEnoughSpaceMessage()
        {
            Console.WriteLine("That is not a valid direction!");
            Console.WriteLine("Press any key to try again.");
            Console.ReadKey();
        }

        public static void VictoryMessage(string currentPlayerName)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Congratulations {currentPlayerName} you have one the game!");
            Console.WriteLine();
            Console.ResetColor(); 
        }

        public void DrawBoard(Board myBoard)
        {
            Coordinate myCoord;
            ShotHistory checkedShot;
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j <= 11; j++)
                {
                    myCoord = new Coordinate(i, j);
                    checkedShot = myBoard.CheckCoordinate(myCoord);
                    if (checkedShot == ShotHistory.Unknown)
                    {
                        if(j!=11)
                            Console.Write(" - ");
                    }
                    else
                    {
                        if (checkedShot == ShotHistory.Hit)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" H ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(" M ");
                            Console.ResetColor();
                        }
                        //Console.ForegroundColor = ConsoleColor.White;
                    }

                    if (j % 10 != 0)
                        Console.Write("|");

                }
                Console.WriteLine();
                if (i % 10 != 0) Console.WriteLine("---------------------------------------");
            }
        }

        public void DrawBoard()
        {
            Coordinate myCoord;
            //ShotHistory checkedShot;
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j <= 11; j++)
                {
                    myCoord = new Coordinate(i, j);
                    //checkedShot = myBoard.CheckCoordinate(myCoord);
                    //if (checkedShot == ShotHistory.Unknown)
                    //{
                        if (j != 11)
                            Console.Write(" - ");
                    //}
                    //else
                    //{
                    //    if (checkedShot == ShotHistory.Hit)
                    //    {
                    //        Console.ForegroundColor = ConsoleColor.Red;
                    //        Console.Write(" H ");
                    //        Console.ResetColor();
                    //    }
                    //    else
                    //    {
                    //        Console.ForegroundColor = ConsoleColor.Yellow;
                    //        Console.Write(" M ");
                    //        Console.ResetColor();
                    //    }
                    //    //Console.ForegroundColor = ConsoleColor.White;
                    //}

                    if (j % 10 != 0)
                        Console.Write("|");

                }
                Console.WriteLine();
                if (i % 10 != 0) Console.WriteLine("---------------------------------------");
            }
        }

        internal static void MissingComma()
        {
            Console.WriteLine("There is no comma detected in your coordinates.");
            Console.WriteLine("Press any key to try again.");
            Console.ReadKey();
        }

        public static void MissMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The fired shot was a Miss.");
            Console.ResetColor();
            Console.WriteLine("Press any key to switch turns.");
        }

        public static void HitMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The fired shot was a Hit!");
            Console.ResetColor();
            Console.WriteLine("Press any key to switch turns.");
        }

        public void DisplayShotStatus(ShotStatus shot)
        {
            
            switch (shot)
            {
                case ShotStatus.Victory:
                    break;
                case ShotStatus.HitAndSunk:
                    //HitAndSunkMessage(ShipType);
                    Console.ReadKey();
                    break;
                case ShotStatus.Duplicate:
                    //DuplicateMessage();
                    Console.ReadKey();
                    break;
                case ShotStatus.Hit:
                    HitMessage();
                    Console.ReadKey();
                    break;
                case ShotStatus.Miss:
                    MissMessage();
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
        }

        public void HitAndSunkMessage(string impactedShip)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The fired shot was a Hit!");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You have sunk the other player's {impactedShip}.");
            Console.ResetColor();
            Console.WriteLine("Press any key to switch turns.");
        }

        public void DuplicateMessage()
        {
            Console.WriteLine("This shot has been fired already.");
            Console.WriteLine("Press any key to try again.");
        }

        public static void InvalidNumber(int number)
        {
            Console.WriteLine($"{number} is not a valid number or is not on the board.");
            Console.WriteLine("Press any key to try again.");
        }

        public static void PlayerTurnMessage(string player)
        {
            Console.WriteLine($"It is now {player}'s turn.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }


    }
}
