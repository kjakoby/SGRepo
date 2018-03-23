using BattleShip.BLL;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class ConsoleInput
    {
        public string GetPlayerName()
        {
            string playerName;
            ConsoleOutput.AskForName();
            playerName = Console.ReadLine();
            return playerName;
        }

        public static ConsoleKeyInfo ContinueOrQuit()
        {
            Console.Clear();
            ConsoleOutput.ContinueOrQuitMessage();
            return Console.ReadKey();
        }

        public ShipDirection GetShipDirection(ShipType ship)
        {
            PlaceShipRequest placeShip = new PlaceShipRequest();
            ShipDirection shipDirection;

                ConsoleOutput.AskForDirection(ship);
                string givenDirection = Console.ReadLine();
                switch (givenDirection)
                {
                    case "up":
                        shipDirection = ShipDirection.Up;
                        break;
                    case "down":
                        shipDirection = ShipDirection.Down;
                        break;
                    case "left":
                        shipDirection = ShipDirection.Left;
                        break;
                    //case "right":
                    //    shipDirection = ShipDirection.Right;
                    //    break;
                    default:
                        shipDirection = ShipDirection.Right;
                        break;
                }
            
            return shipDirection;
        }

        public Coordinate GetCoordinates()
        {
            int resultX=0;
            int resultY=0;
            int numberX;
            int numberY;
            bool IsvalidY = false;
            bool IsvalidX = false;
            do
            {
                IsvalidY = false;
                IsvalidX = false;
                ConsoleOutput.AskForCoords();
                string input = Console.ReadLine();
                if ((input == " ") || (input == null) || (input == ""))
                {
                    ConsoleOutput.MissingComma();
                }
                else if (input.Contains(','))
                {

                    string[] together = input.Split(',');
                    if (int.TryParse(together[0], out numberY) && numberY <= 10 && numberY >= 1)
                    {
                        resultY = numberY;
                        IsvalidY = true;
                    }
                    else
                    {
                        ConsoleOutput.InvalidNumber(numberY);
                        
                    }

                    if (int.TryParse(together[1], out numberX) && numberX <= 10 && numberX >= 1)
                    {
                        resultX = numberX;
                        IsvalidX = true;
                    }
                    else
                    {
                        ConsoleOutput.InvalidNumber(numberX);
                        
                    }
                }
                else
                {
                    ConsoleOutput.MissingComma();
                    
                }
                

            } while (!(IsvalidX && IsvalidY));
            Coordinate coordinate = new Coordinate(resultY, resultX);
            return coordinate;
        }

        //public Coordinate GetCoordinates(ShipType shipType)
        //{
        //    int resultX = 0;
        //    int resultY = 0;
        //    int numberX;
        //    int numberY;
        //    bool IsvalidY = false;
        //    bool IsvalidX = false;
        //    do
        //    {
        //        ConsoleOutput.AskForCoords();
        //        string input = Console.ReadLine();
        //        if ((input == " ") || (input == null) || (input == ""))
        //        {
        //            ConsoleOutput.MissingComma();
        //        }
        //        else if (input.Contains(','))
        //        {

        //            string[] together = input.Split(',');
        //            if (int.TryParse(together[0], out numberY) || numberY <= 10)
        //            {
        //                resultY = numberY;
        //                IsvalidY = true;
        //            }
        //            else
        //            {
        //                ConsoleOutput.InvalidNumber(numberY);
        //            }

        //            if (int.TryParse(together[1], out numberX) || numberX <= 10)
        //            {
        //                resultX = numberX;
        //                IsvalidX = true;
        //            }
        //            else
        //            {
        //                ConsoleOutput.InvalidNumber(numberX);
        //            }
        //        }
        //        else
        //        {
        //            ConsoleOutput.MissingComma();
        //            continue;
        //        }


        //    } while (!IsvalidY && !IsvalidX);
        //    Coordinate coordinate = new Coordinate(resultY, resultX);
        //    return coordinate;
        //}
    }
}
