using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.BLL
{
    public class Player
    {
        public string Name { get; set; }
        public Board Board { get; set; }

//        private Board SetupBoard()
//        {
//            Board board = new Board();

//            PlaceDestroyer(board);
//            PlaceCruiser(board);
//            PlaceSubmarine(board);
//            PlaceBattleship(board);
//            PlaceCarrier(board);

//            return board;
//        }

//        private void PlaceCarrier(Board board)
//        {
//            var request = new PlaceShipRequest()
//            {
//                Coordinate = new Coordinate(4, 4),
//                Direction = ShipDirection.Right,
//                ShipType = ShipType.Carrier
//            };

//            board.PlaceShip(request);
//        }

//        private void PlaceBattleship(Board board)
//        {
//            var request = new PlaceShipRequest()
//            {
//                Coordinate = new Coordinate(6, 10),
//                Direction = ShipDirection.Down,
//                ShipType = ShipType.Battleship
//            };

//            board.PlaceShip(request);
//        }

//        private void PlaceSubmarine(Board board)
//        {
//            var request = new PlaceShipRequest()
//            {
//                Coordinate = new Coordinate(5, 3),
//                Direction = ShipDirection.Left,
//                ShipType = ShipType.Submarine
//            };

//            board.PlaceShip(request);
//        }

//        private void PlaceCruiser(Board board)
//        {
//            var request = new PlaceShipRequest()
//            {
//                Coordinate = new Coordinate(3, 3),
//                Direction = ShipDirection.Up,
//                ShipType = ShipType.Cruiser
//            };

//            board.PlaceShip(request);
//        }

//        private void PlaceDestroyer(Board board)
//        {
//            var request = new PlaceShipRequest()
//            {
//                Coordinate = new Coordinate(8, 1),
//                Direction = ShipDirection.Right,
//                ShipType = ShipType.Destroyer
//            };

//            board.PlaceShip(request);
//        }
    }
}
