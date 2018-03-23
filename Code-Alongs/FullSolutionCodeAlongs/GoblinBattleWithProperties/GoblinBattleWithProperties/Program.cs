using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinBattleWithProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            Goblin g1 = new Goblin();
            Goblin g2 = new Goblin();

            g1.Name = "Tom";
            g1.HitPoints = 10;

            g2.Name = "Jerry";
            g2.HitPoints = 10;

            int whoseTurn = 1;

            while (!g1.IsDead && !g2.IsDead)
            {
                if (whoseTurn == 1)
                {
                    g1.Attack(g2);
                    whoseTurn = 2;
                }
                else
                {
                    g2.Attack(g1);
                    whoseTurn = 1;
                }
            }

            Console.WriteLine("The battle is ended!");
            Console.ReadLine();
        }
    }

    class Goblin
    {
        private static Random _rng = new Random();

        public bool IsDead { get; private set; }
        private int _hitPoints;
        public string Name { get; set; } 
        
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                if (value < 0)
                    return;
                else
                    _hitPoints = value;
            }
        }

        public void Attack (Goblin target)
        {
            int damage = _rng.Next(5);
            Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage!");
            target.Hit(damage);
        }

        public void Hit(int damage)
        {
            _hitPoints -= damage;
            Console.WriteLine($"{Name} receives {damage} damage. {Name} has {_hitPoints} health.");

            if (_hitPoints <= 0)
            {
                Console.WriteLine($"{Name} has died!");
                IsDead = true;
            }
        }
    }
}
