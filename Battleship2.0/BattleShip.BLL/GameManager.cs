using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
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
        public Player player1 { get; set; }
        public Player player2 { get; set; }
        
        //public Board p1Board { get; set; }
        //public Board p2Board { get; set; }

        public void Start()
        {
            player1 = new Player();
            player2 = new Player();
            //p1Board = new Board();
            //    //Player player1;
            //    //Player player2;
            //    player1 = new Player();
            //    {
            //        player1.Name = ConsoleInput.GetPlayerName(player1);
            //    }
            //    player2 = new Player();
            //    //player1.Name = ConsoleInput.GetPlayerName(player1);
            //    player2.Name = ConsoleInput.GetPlayerName(player2);
            ////this needs to be where I get names and Boards for players
        }

        //public Board SetupBoard()
        //{
        //    Board playerBoard = new Board();
        //    PlaceDestroyer(playerBoard);
        //    PlaceCruiser(playerBoard);
        //    PlaceSubmarine(playerBoard);
        //    PlaceBattleship(playerBoard);
        //    PlaceCarrier(playerBoard);

        //    return playerBoard;
        //}

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

        //public void PlaceBattleship(Board board)
        //{
        //    var request = new PlaceShipRequest()
        //    {
        //        Coordinate = new Coordinate(6, 10),
        //        Direction = ShipDirection.Down,
        //        ShipType = ShipType.Battleship
        //    };

        //    board.PlaceShip(request);
        //}

        //public void PlaceSubmarine(Board board)
        //{
        //    var request = new PlaceShipRequest()
        //    {
        //        Coordinate = new Coordinate(5, 3),
        //        Direction = ShipDirection.Left,
        //        ShipType = ShipType.Submarine
        //    };

        //    board.PlaceShip(request);
        //}

        //public void PlaceCruiser(Board board)
        //{
        //    var request = new PlaceShipRequest()
        //    {
        //        Coordinate = new Coordinate(3, 3),
        //        Direction = ShipDirection.Up,
        //        ShipType = ShipType.Cruiser
        //    };

        //    board.PlaceShip(request);
        //}

        //public void PlaceDestroyer(Board board)
        //{
        //    var request = new PlaceShipRequest()
        //    {
        //        Coordinate = new Coordinate(8, 1),
        //        Direction = ShipDirection.Right,
        //        ShipType = ShipType.Destroyer
        //    };

        //    board.PlaceShip(request);
        //}




        //public FireShotResponse SinkCarrier(Board board)
        //{
        //    var coordinate = new Coordinate(4, 4);
        //    board.FireShot(coordinate);

        //    coordinate = new Coordinate(4, 5);
        //    board.FireShot(coordinate);

        //    coordinate = new Coordinate(4, 6);
        //    board.FireShot(coordinate);

        //    coordinate = new Coordinate(4, 7);
        //    board.FireShot(coordinate);

        //    coordinate = new Coordinate(4, 8);
        //    return board.FireShot(coordinate);
        //}

        //public FireShotResponse SinkBattleship(Board board)
        //{
        //    var coordinate = new Coordinate(6, 10);
        //    board.FireShot(coordinate);

        //    coordinate = new Coordinate(7, 10);
        //    board.FireShot(coordinate);

        //    coordinate = new Coordinate(8, 10);
        //    board.FireShot(coordinate);

        //    coordinate = new Coordinate(9, 10);
        //    return board.FireShot(coordinate);
        //}

        //public FireShotResponse SinkSubmarine(Board board)
        //{
        //    var coordinate = new Coordinate(5, 1);
        //    board.FireShot(coordinate);

        //    coordinate = new Coordinate(5, 2);
        //    board.FireShot(coordinate);

        //    coordinate = new Coordinate(5, 3);
        //    return board.FireShot(coordinate);
        //}

        //public FireShotResponse SinkCruiser(Board board)
        //{
        //    var coordinate = new Coordinate(1, 3);
        //    board.FireShot(coordinate);

        //    coordinate = new Coordinate(2, 3);
        //    board.FireShot(coordinate);

        //    coordinate = new Coordinate(3, 3);
        //    return board.FireShot(coordinate);
        //}

        //public FireShotResponse SinkDestroyer(Board board)
        //{
        //    var coordinate = new Coordinate(8, 1);
        //    board.FireShot(coordinate);

        //    coordinate = new Coordinate(8, 2);
        //    return board.FireShot(coordinate);
        //}
    }
}
