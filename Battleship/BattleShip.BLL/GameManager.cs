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
    public class GameManager
    {
        //pull logic from BLL to form a game to make an instance of
        
        private int firstTurn;
        //public Player player1 { get; set; }
        //public Player player2 { get; set; }

        public int RandomTurn()
        {
            Random _rng = new Random();
            firstTurn = _rng.Next(2);
            return firstTurn;
        }

        private void PlaceCarrier(Board board)
        {
            var request = new PlaceShipRequest()
            {
                Coordinate = new Coordinate(4, 4),
                Direction = ShipDirection.Right,
                ShipType = ShipType.Carrier
            };

            board.PlaceShip(request);
        }

        private void PlaceBattleship(Board board)
        {
            var request = new PlaceShipRequest()
            {
                Coordinate = new Coordinate(6, 10),
                Direction = ShipDirection.Down,
                ShipType = ShipType.Battleship
            };

            board.PlaceShip(request);
        }

        private void PlaceSubmarine(Board board)
        {
            var request = new PlaceShipRequest()
            {
                Coordinate = new Coordinate(5, 3),
                Direction = ShipDirection.Left,
                ShipType = ShipType.Submarine
            };

            board.PlaceShip(request);
        }

        private void PlaceCruiser(Board board)
        {
            var request = new PlaceShipRequest()
            {
                Coordinate = new Coordinate(3, 3),
                Direction = ShipDirection.Up,
                ShipType = ShipType.Cruiser
            };

            board.PlaceShip(request);
        }

        private void PlaceDestroyer(Board board)
        {
            var request = new PlaceShipRequest()
            {
                Coordinate = new Coordinate(8, 1),
                Direction = ShipDirection.Right,
                ShipType = ShipType.Destroyer
            };

            board.PlaceShip(request);
        }
        //public void AssignNames()
        //{
        //    player1 = new Player()
        //    {
        //        Board = new Board()
        //    };
        //}



    }
}
