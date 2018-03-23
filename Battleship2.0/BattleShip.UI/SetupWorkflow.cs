using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class SetupWorkflow
    {
        ConsoleInput input = new ConsoleInput();
        ConsoleOutput output = new ConsoleOutput();
        public Board SetupBoard(string name)
        {
            Board playerBoard = new Board();

            ConsoleOutput.CurrentPlayerTurn(name);
            Console.WriteLine();
            output.DrawBoard();
            Console.WriteLine();
            PlaceCarrier(playerBoard);
            Console.Clear();
            //output.DrawBoard();
            

            ConsoleOutput.CurrentPlayerTurn(name);
            Console.WriteLine();
            output.DrawBoard();
            Console.WriteLine();
            PlaceBattleship(playerBoard);
            Console.Clear();
            
            ConsoleOutput.CurrentPlayerTurn(name);
            Console.WriteLine();
            output.DrawBoard();
            Console.WriteLine();
            PlaceCruiser(playerBoard);
            Console.Clear();
            
            ConsoleOutput.CurrentPlayerTurn(name);
            Console.WriteLine();
            output.DrawBoard();
            Console.WriteLine();
            PlaceSubmarine(playerBoard);
            Console.Clear();


            ConsoleOutput.CurrentPlayerTurn(name);
            Console.WriteLine();
            output.DrawBoard();
            Console.WriteLine();
            PlaceDestroyer(playerBoard);
            Console.Clear();

            return playerBoard;

        }

        public ShipPlacement PlaceCarrier(Board board)
        {
            ShipPlacement response = default(ShipPlacement);
            
                ConsoleOutput.ShipPlacementMessage(ShipType.Carrier);
                Console.WriteLine();
            do
            {
                var request = new PlaceShipRequest();
                request.ShipType = ShipType.Carrier;
                request.Coordinate = input.GetCoordinates();
            
                request.Direction = input.GetShipDirection(ShipType.Carrier);
                response = board.PlaceShip(request);
                if(response == ShipPlacement.NotEnoughSpace)
                {
                    ConsoleOutput.NotEnoughSpaceMessage();
                }
                else if(response == ShipPlacement.Overlap)
                {
                    ConsoleOutput.OverlappingMessage();
                }
            } while (response == ShipPlacement.NotEnoughSpace || response == ShipPlacement.Overlap);
            
            return response;
            
        }

        //public void PlaceCarrier(Board board)
        //{
        //    var request = new PlaceShipRequest()
        //    {
        //        Coordinate = new Coordinate(4, 4),
        //        Direction = ShipDirection.Right,
        //        ShipType = ShipType.Carrier
        //    };

        //    board.PlaceShip(request);
        //}

        public ShipPlacement PlaceBattleship(Board board)
        {
            ShipPlacement response = default(ShipPlacement);

            
                ConsoleOutput.ShipPlacementMessage(ShipType.Battleship);
                Console.WriteLine();
            do
            {
                var request = new PlaceShipRequest();
                request.ShipType = ShipType.Battleship;
                request.Coordinate = input.GetCoordinates();
           
                request.Direction = input.GetShipDirection(ShipType.Battleship);
                response = board.PlaceShip(request);
                if (response == ShipPlacement.NotEnoughSpace)
                {
                    ConsoleOutput.NotEnoughSpaceMessage();
                }
                else if (response == ShipPlacement.Overlap)
                {
                    ConsoleOutput.OverlappingMessage();
                }
            } while (response == ShipPlacement.NotEnoughSpace || response == ShipPlacement.Overlap);

            return response;
        }

        public ShipPlacement PlaceSubmarine(Board board)
        {
            ShipPlacement response = default(ShipPlacement);

            
                ConsoleOutput.ShipPlacementMessage(ShipType.Submarine);
                Console.WriteLine();
            do
            {
                var request = new PlaceShipRequest();
                request.ShipType = ShipType.Submarine;
                request.Coordinate = input.GetCoordinates();
            
                request.Direction = input.GetShipDirection(ShipType.Submarine);
                response = board.PlaceShip(request);
                if (response == ShipPlacement.NotEnoughSpace)
                {
                    ConsoleOutput.NotEnoughSpaceMessage();
                }
                else if (response == ShipPlacement.Overlap)
                {
                    ConsoleOutput.OverlappingMessage();
                }
            } while (response == ShipPlacement.NotEnoughSpace || response == ShipPlacement.Overlap);

            return response;
        }

        public ShipPlacement PlaceCruiser(Board board)
        {
            ShipPlacement response = default(ShipPlacement);

            
                ConsoleOutput.ShipPlacementMessage(ShipType.Cruiser);
                Console.WriteLine();
            do
            {
                var request = new PlaceShipRequest();
                request.ShipType = ShipType.Cruiser;
                request.Coordinate = input.GetCoordinates();
            
                request.Direction = input.GetShipDirection(ShipType.Cruiser);
                response = board.PlaceShip(request);
                if (response == ShipPlacement.NotEnoughSpace)
                {
                    ConsoleOutput.NotEnoughSpaceMessage();
                }
                else if (response == ShipPlacement.Overlap)
                {
                    ConsoleOutput.OverlappingMessage();
                }
            } while (response == ShipPlacement.NotEnoughSpace || response == ShipPlacement.Overlap);

            return response;
        }

        public ShipPlacement PlaceDestroyer(Board board)
        {
            ShipPlacement response = default(ShipPlacement);

            
                ConsoleOutput.ShipPlacementMessage(ShipType.Destroyer);
                Console.WriteLine();
            do
            {
                var request = new PlaceShipRequest();
                request.ShipType = ShipType.Destroyer;
                request.Coordinate = input.GetCoordinates();
            
                request.Direction = input.GetShipDirection(ShipType.Destroyer);
                response = board.PlaceShip(request);
                if (response == ShipPlacement.NotEnoughSpace)
                {
                    ConsoleOutput.NotEnoughSpaceMessage();
                }
                else if (response == ShipPlacement.Overlap)
                {
                    ConsoleOutput.OverlappingMessage();
                }
            } while (response == ShipPlacement.NotEnoughSpace || response == ShipPlacement.Overlap);

            return response;
        }
    }
}
