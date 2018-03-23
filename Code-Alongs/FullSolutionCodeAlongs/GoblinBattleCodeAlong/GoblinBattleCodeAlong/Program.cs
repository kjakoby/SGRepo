using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinBattleCodeAlong
{
    class Program
    {
        static void Main(string[] args)
        {
            Goblin g1 = new Goblin();
            Goblin g2 = new Goblin();

            g1.SetName("Tom");
            g1.SetHitPoints(10);

            g2.SetName("Jerry");
            g2.SetHitPoints(10);

            int whoseTurn = 1;

            while (!g1.GetIsDead() && !g2.GetIsDead())
            {
                if (whoseTurn==1)
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

        private int _hitPoints;
        private string _name;
        private bool _isDead;

        public int GetHitPoints()
        {
            return _hitPoints;
        }

        public void SetHitPoints(int hp)
        {
            if (hp < 0)
                return;
            else
                _hitPoints = hp;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string newName)
        {
            _name = newName;
        }

        public bool GetIsDead()
        {
            return _isDead;
        }

        public void Attack(Goblin target)
        {
            int damage = _rng.Next(5);
            Console.WriteLine($"{_name} attacks {target.GetName()} for {damage} damage!");
            target.Hit(damage);
        }

        public void Hit(int damage)
        {
            _hitPoints -= damage;
            Console.WriteLine($"{_name} receives {damage} damage. {_name} has {_hitPoints} health.");

            if(_hitPoints <=0)
            {
                Console.WriteLine($"{_name} has died!");
                _isDead = true;
            }
        }
    }
}
