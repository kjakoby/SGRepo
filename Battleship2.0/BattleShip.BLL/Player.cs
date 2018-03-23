using BattleShip.BLL.GameLogic;
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
        public int turnNumber { get; set; }
    }
}
