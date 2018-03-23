using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute();
            Console.ReadLine();
        }

        static void Execute()
        {
            Console.WriteLine("Welcome to FizzBuzz!");

            for(int i=1; i<=100; i++)
            {
                Console.Write(i);

                if(i%3==0)
                {
                    Console.Write(" Fizz");
                }

                if (i % 5 == 0)
                {
                    Console.Write(" Buzz");
                }

                Console.WriteLine();
                
            }
        }
    }
}
