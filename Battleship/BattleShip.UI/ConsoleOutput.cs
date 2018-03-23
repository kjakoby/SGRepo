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
    public class ConsoleOutput
    {
        public static void DisplayTitle()
        {
            Console.WriteLine("Welcome to Battleship!");
            Console.WriteLine();
            Console.WriteLine("We will start by finding out who is playing.");
            Console.ReadKey();
        }

        public static void AskForName()
        {
            Console.Write("Please enter the name for your player: ");
        }

        public static void ContinueOrQuitMessage()
        {
            Console.Write("Press any key to play again (Press \"Q\" or \"q\" to quit)");
        }

        public static void AskForDirection()
        {
            Console.Write("Enter the direction you would like to place the ship(Up, Down, Left, Right): ");
        }

        public static void AskForCoord()
        {
            Console.Write("Enter the coordinate you would like to start the ship on: ");
        }

        public static void SwitchPlayerPrompt()
        {
            Console.Clear();
            Console.WriteLine("Your turn has ended.");
            Console.WriteLine("Please switch players.");
            Console.ReadKey();
        }

        public static void DrawBoard(Board myBoard, ShotHistory currentShot)
        {
            Coordinate myCoord;
            ShotHistory checkedShot;
            int yAxis = 0;
            int xAxis = 0;
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 43; j++)
                {
                    myCoord = new Coordinate(i, j);

                    checkedShot = myBoard.CheckCoordinate(myCoord);
                    //if (yAxisZero == j)
                    //{
                    //    Console.Write(yAxisZero);
                    //    yAxisZero++;
                    //    continue;
                    //}

                    //see if at spot 0 for x or y
                    if(j==0 || i==0)
                    {
                        if (j == 0 && i == 0)
                            Console.Write(" ");
                        else if (j == 0)
                        {
                            if(i%2!=0)
                            {
                                Console.WriteLine("-------------------------------------------");
                            }
                            else
                                Console.Write(i/2);
                        }
                        else if (j % 4 == 0)
                        {
                            Console.Write(j / 4);
                        }
                        else
                            Console.Write(" ");
                    }
                    else
                    {
                        if (checkedShot == ShotHistory.Unknown)
                        {
                            Console.Write("~");
                        }
                        else
                        {
                            if (checkedShot == currentShot || currentShot == ShotHistory.Hit)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(checkedShot);
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(" ");
                                Console.ResetColor();
                            }
                        }
                    }
                    //else if(myCoord.XCoordinate==xAxis)
                    //{
                    //    Console.Write(xAxis);
                    //    xAxis++;
                    //}

                    //if (checkedShot == ShotHistory.Unknown)
                    //{
                    //    Console.Write("~");
                    //}
                    //else
                    //{
                    //    if (checkedShot == currentShot || currentShot == ShotHistory.Hit)
                    //    {
                    //        Console.ForegroundColor = ConsoleColor.Red;
                    //        Console.Write(checkedShot);
                    //        Console.ResetColor();
                    //    }
                    //    else
                    //    {
                    //        Console.ForegroundColor = ConsoleColor.Green;
                    //        Console.Write(" ");
                    //        Console.ResetColor();
                    //    }
                    //}
                    //if (j % 2 != 0)
                    //    Console.Write("|");
                    
                }
                Console.WriteLine();
                //if (i % 12 != 0)
                //{
                //    Console.WriteLine("- - - - - - - - - - - - - - - - - - - - -");
                //}
                //if (xAxisZero == i)
                //{
                //    Console.Write(xAxisZero);
                //    xAxisZero++;
                //}
            }
        }
    }
}
