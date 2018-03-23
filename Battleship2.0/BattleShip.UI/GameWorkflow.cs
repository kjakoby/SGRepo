using BattleShip.BLL;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class GameWorkflow
    {
        GameManager _manager;
        int _turn;
        //int _sunkCount;
        //ShotHistory p1currentShot;
        //ShotHistory p2currentShot;

        public void RunProg()
        {
            CreateGameManagerInstance();
            ConsoleOutput.DisplayTitle();
            Console.Clear();
            ConsoleKeyInfo keyPressed;
            //string player1Name;
            //string player2Name;
            FireShotResponse fireShotResponseP1 = new FireShotResponse();
            FireShotResponse fireShotResponseP2 = new FireShotResponse();
            ConsoleInput input = new ConsoleInput();
            ConsoleOutput output = new ConsoleOutput();
            //ConsoleOutput.ContinueOrQuitMessage;

            CreateRandomTurn();
            Coordinate coordinate;
            SetupWorkflow setup = new SetupWorkflow();

            do
            {
                //SetupWorkflow.SetupPlayers();
                //setup.SetupBoard();
                Console.Clear();
                _manager.player1.Name = input.GetPlayerName();
                _manager.player2.Name = input.GetPlayerName();
                Console.Clear();
                ConsoleOutput.PlayerTurnMessage(_manager.player1.Name);
                _manager.player1.Board = setup.SetupBoard(_manager.player1.Name);
                ConsoleOutput.PlayerTurnMessage(_manager.player2.Name);
                _manager.player2.Board = setup.SetupBoard(_manager.player2.Name);
                _manager.player1.turnNumber = 0;
                _manager.player2.turnNumber = 1;
                //CreateRandomTurn();
                bool victory=false;
                do
                {
                    
                    
                    if (_manager.player1.turnNumber == _turn)
                    {
                        Console.Clear();
                        ConsoleOutput.PlayerTurnMessage(_manager.player1.Name);
                        ConsoleOutput.CurrentPlayerTurn(_manager.player1.Name);
                        Console.WriteLine();
                        output.DrawBoard(_manager.player2.Board);
                        Console.WriteLine();
                        Console.WriteLine("Lets try to hit an opponent's ship.");
                        Console.WriteLine();

                        do
                        {
                            coordinate = input.GetCoordinates();
                            fireShotResponseP1 = _manager.player2.Board.FireShot(coordinate);
                            if(fireShotResponseP1.ShotStatus == ShotStatus.Duplicate)
                                output.DuplicateMessage();
                        } while (fireShotResponseP1.ShotStatus == ShotStatus.Duplicate);


                        if (fireShotResponseP1.ShotStatus == ShotStatus.HitAndSunk)
                        {
                            output.HitAndSunkMessage(fireShotResponseP1.ShipImpacted);
                            
                            Console.ReadKey();
                        }
                        else
                        {
                            output.DisplayShotStatus(fireShotResponseP1.ShotStatus);
                        }


                        if (fireShotResponseP1.ShotStatus == ShotStatus.Victory)
                        {
                            victory = true;
                            string currentPlayerName = _manager.player1.Name;
                            ConsoleOutput.VictoryMessage(currentPlayerName);
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            break;
                        }
                        //else
                        //{
                        //    ConsoleOutput.SwitchPlayerPrompt();
                        //}
                        
                        //Console.ReadKey();
                        _turn = 1;
                    }

                    else
                    {
                        Console.Clear();
                        ConsoleOutput.PlayerTurnMessage(_manager.player2.Name);
                        ConsoleOutput.CurrentPlayerTurn(_manager.player2.Name);
                        Console.WriteLine();
                        output.DrawBoard(_manager.player1.Board);
                        Console.WriteLine();
                        Console.WriteLine("Lets try to hit an opponent's ship.");
                        Console.WriteLine();

                        do
                        {
                            coordinate = input.GetCoordinates();
                            fireShotResponseP2 = _manager.player1.Board.FireShot(coordinate);
                            if (fireShotResponseP2.ShotStatus == ShotStatus.Duplicate)
                                output.DuplicateMessage();
                        } while (fireShotResponseP2.ShotStatus == ShotStatus.Duplicate);


                        if(fireShotResponseP2.ShotStatus==ShotStatus.HitAndSunk)
                        {
                            output.HitAndSunkMessage(fireShotResponseP2.ShipImpacted);
                            
                            Console.ReadKey();
                        }
                        else
                        {
                            output.DisplayShotStatus(fireShotResponseP2.ShotStatus);
                        }


                        if (fireShotResponseP2.ShotStatus == ShotStatus.Victory)
                        {
                            victory = true;
                            string currentPlayerName = _manager.player2.Name;
                            ConsoleOutput.VictoryMessage(currentPlayerName);
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                        }
                        //else
                        //{
                        //    ConsoleOutput.SwitchPlayerPrompt();
                        //}
                        _turn = 0;
                    }
                } while (/*!(fireShotResponseP1.ShotStatus == ShotStatus.Victory) || (fireShotResponseP2.ShotStatus == ShotStatus.Victory)*/!victory);
                
                

                keyPressed = ConsoleInput.ContinueOrQuit();

            } while (!(keyPressed.Key == ConsoleKey.Q));

            
        }

        private void CreateGameManagerInstance()
        {
            _manager = new GameManager();
            _manager.Start();
        }

        private int CreateRandomTurn()
        {
            Random rng = new Random();
            _turn = rng.Next(2);
            return _turn;
        }
    }
}
