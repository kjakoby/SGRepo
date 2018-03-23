using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowShovel
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isSnow = true;
            int DrivewayWidth = 10;
            int DrivewayLength = 100;

            if (!isSnow)
            {
                Console.WriteLine("Watching TV");
            }
            else
            {
                for (int i=DrivewayWidth; i>0; i--)
                {
                    Console.WriteLine($"Starting pass {i} of driving clearing.");
                    for (int j=0; j<DrivewayLength; j++)
                    {
                        if(j==50)
                        {
                            break;
                        }
                        Console.WriteLine($"Step {j} of pass {i}.");
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
