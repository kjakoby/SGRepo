using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterFactorizor.BLL
{
    public class PerfectChecker
    {
        //public bool IsPerfect { get; set; }
        bool IsPerfect;
        public PerfectChecker (int number)
        {
            
            int sum = 0;
            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                {
                    sum += i;
                }
                else
                {
                    continue;
                }
            }
            if (sum == number)
            {
                IsPerfect = true;
                //Console.WriteLine($"{number} is a Perfect Number.");
            }
            else
            {
                IsPerfect = false;
                Console.WriteLine($"{number} is not a Perfect Number.");
            }
        }
        //public 
        //int sum = 0;
        //for (int i = 1; i<number; i++)
        //{
        //    if (number % i == 0)
        //    {
        //        sum += i;
        //    }
        //    else
        //    {
        //        continue;
        //    }
        //}
        //if (sum == number)
        //{
        //    Console.WriteLine($"{number} is a Perfect Number.");
        //}
        //else
        //{
        //    Console.WriteLine($"{number} is not a Perfect Number.");
        //}
    }
}
