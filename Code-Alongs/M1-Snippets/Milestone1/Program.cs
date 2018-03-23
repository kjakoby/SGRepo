using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone1
{
    class Program
    {
        //int x;
        //int y;

        public class Person
        {
            public string Name;
            public int Age;
        }

        static void Main(string[] args)
        {
            Lesson4_1();
            //Lesson4_2();
            //Lesson5_1();
            //Lesson6_1();
            //Lesson6_2();
            //Lesson6_3();
            //Lesson6_4();
            //Lesson6_5();
            //Lesson6_6();
            //Lesson6_7();
            //Lesson6_8();
            //Lesson6_9();
            //Lesson6_10();
            //Lesson6_11();
            //Lesson6_12();
            //Lesson6_13();
            //Lesson6_14();
            //Lesson6_15();
            //Lesson6_16();
            //Lesson8_1();
            //Lesson8_2();

            Console.Write("Press any key to continue.");
            Console.ReadKey();
        }



        //~~~~Lesson4 Variables~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        //~~Ex. of how memory works~~
        static void Lesson4_1()
        {
            Person p = new Person();   //~~~~~~~~~~~~~~~~~~create a Person instance in p~~
            Person p2 = p;   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~assign p2 to the person instance referenced by p~~
            p.Name = "Mary";   //~~~~~~~~~~~~~~~~~~~~~~~~~~assign p's instance Name member to Mary~~
            p2.Age = 19;   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~assign p2's instance Age member to 19
            Console.WriteLine(p.Age);   //~~~~~~~~~~~~~~~~~prints 19~~
            Console.WriteLine(p2.Name);   //~~~~~~~~~~~~~~~prints Mary~~
            Console.WriteLine("\r");   //~~~~~~~~~~~~~~~~~~prints a blank line
        }

        //~~Ex. of printing a value from a nullable type
        static void Lesson4_2()
        {
            int? nullableNumber = 5;
            if (nullableNumber.HasValue)   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~only print the value if it has a value~~
            {
                Console.WriteLine(nullableNumber.Value);
            }
            Console.WriteLine("\r");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~prints a blank line
        }



        //~~~~Lesson5 Expressions and Operations~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        //~~declare two person objects but assign the same data to their fields~~
        static void Lesson5_1()
        {
            Person p = new Person();   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~create a Person instance in p~~
            p.Name = "Mary";   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~assign p's instance Name member to Mary
            p.Age = 19;   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~assign p2's instance Age member to 19
            Person p2 = new Person();   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~create a Person instance in p2~~
            p2.Name = "Mary";   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~assign p2's instance Name member to Mary
            p2.Age = 19;   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~assign p2's instance Age member to 19
            Console.WriteLine(p.Name);   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~prints Mary
            Console.WriteLine(p.Age);   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~prints 19
            Console.WriteLine("\r");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~prints a blank line
            Console.WriteLine(p2.Name);   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~prints Mary
            Console.WriteLine(p2.Age);   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~prints 19
            Console.WriteLine("\r");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~prints a blank line
        }



        //~~~~Lesson6 Flow Of Control~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        //~~examples of valid "if" statements~~
        static void Lesson6_1()
        {
            int x = 5;
            int y = 10;
            if (x > y)
                Console.WriteLine("x is bigger");
            if (x < y)
            {
                Console.WriteLine("x is smaller");
                Console.WriteLine("y is bigger");
            }
            Console.WriteLine("\r");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~prints a blank line
        }

        //~~using an expression containing methods as a test condition~~
        static void Lesson6_2()
        {
            int Add(int x, int y)
            {
                return x + y;
            }
            if (Add(2, 3) > Add(5, 10))
            {
                Console.WriteLine("The first sum is bigger.");
            }
            else
                Console.WriteLine("The second sum is bigger.");
            Console.WriteLine("\r");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~prints a blank line
        }

        //~~execute some statements if the test condition is true but different ones if the test condition is false with "else"~~
        static void Lesson6_3()
        {
            int x = 5;
            int y = 10;
            if (x > y)
                Console.WriteLine("x is bigger");
            else
                Console.WriteLine("y is bigger");
            Console.WriteLine("\r");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~prints a blank line
        }

        //~~using "else if" for more than two conditions to evaluate~~
        static void Lesson6_4()
        {
            int x = 5;
            int y = 10;
            if (x < 20 && y < 20)
            {
                Console.WriteLine("Both values are < 20");
            }
            else if (x < 15 && y < 15)
            {
                Console.WriteLine("Both values are < 15");
            }
            else if (x < 10 && y < 10)
            {
                Console.WriteLine("Both values < 10");
            }
            else
            {
                Console.WriteLine("None of the above");
            }
            Console.WriteLine("\r");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~prints a blank line
        }

        //~~execute the same statements for multiple cases with a "switch" statement~~
        static void Lesson6_5()
        {
            int x = 2;
            switch (x)
            {
                case 0:   
                    Console.WriteLine("x is 0");
                    break;   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~single case printed
                case 1:   
                case 2:   
                case 3:  
                    Console.WriteLine("x is 1, 2, or 3");
                    break;   ////~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~multi. cases printed
                default:
                    Console.WriteLine("x is not 0, 1, 2, or 3");
                    break;
            }
            Console.WriteLine("\r");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~prints a blank line
        }

        //~~equivalent to "switch" statement above~~
        static void Lesson6_6()
        {
            int x = 2;
            if (x == 0)
                Console.WriteLine("x is 0");
            else if (x == 1 || x == 2 || x == 3)
                Console.WriteLine("x is 1, 2, or 3");
            else
                Console.WriteLine("x is not 0, 1, 2, or 3");
            Console.WriteLine("\r");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~prints a blank line
        }

        //~~a "while" loop to count from 1 to 3~~
        static void Lesson6_7()
        {
            int x = 1;
            while (x < 4)
            {
                Console.WriteLine(x);
                x++;
            }
            Console.WriteLine("\r");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~prints a blank line
        }

        //~~a "while" loop that is already false and is skipped~~
        static void Lesson6_8()
        {
            int x = 5;
            while (x < 4)
            {
                Console.WriteLine(x);
                x++;
            }
            Console.WriteLine(@"The while statement ""x < 4"" was skipped since x was already at 5.");
            Console.WriteLine("\r");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~prints a blank line
        }

        //~~a "do...while" loop so code block is executed at least once no matter what~~
        static void Lesson6_9()
        {
            int x = 5;
            do
            {
                Console.WriteLine(x);
                x++;
            } while (x < 4);
            Console.WriteLine("\r");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~prints a blank line
        }

        //~~a "for" loop to display 1-10 by increasing the increment by one each time it loops~~
        static void Lesson6_10()
        {
            for (int i = 1; i <= 10; i++)   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~starts at 1 and ends after i=10, i goes up by 1
            {
                Console.Write($"{i} ");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~writes what number i is and then goes through the "for" part again
            }
            Console.WriteLine("\r");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~allows looped numbers to be on their own line
            Console.WriteLine("\r");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~prints a blank line
        }

        //~~a "for" loop with a math expression for the increment value of the iterator~~
        static void Lesson6_11()
        {
            for (int i = 1; i <= 10; i *= 2)   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~starts at 1 and ends after i=10, i goes up by 2
            {
                Console.Write($"{i} ");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~writes what number i is and then goes through the "for" part again
            }
            Console.WriteLine("\r");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~allows looped numbers to be on their own line
            Console.WriteLine("\r");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~prints a blank line
        }

        //~~a "for" loop to display 10-0 decreasing increment value of the iterator by 2~~
        static void Lesson6_12()
        {
            for (int i = 10; i >= 0; i -= 2)   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~starts at 10 and ends after i=1, i goes down by 2
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine("\r");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~allows looped numbers to be on their own line
            Console.WriteLine("\r");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~prints a blank line
        }

        //~~using a "for" loop to print only the vowels in the "hello" string~~
        static void Lesson6_13()
        {
            string s = "hello";   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~h=[0],e=[1],l=[2],l=[3],o=[4]
            for (int i = 0; i < s.Length; i++)   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~i starts at 0 index(h), ends after the last index which is one less than the str's length(4)
            {
                char current = s[i];   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~get character at index i
                switch (current)   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~is current a vowel?
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                        Console.Write(current);
                        break;
                }
            }
            Console.WriteLine("\r");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~allows looped letters to be on their own line
            Console.WriteLine("\r");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~prints a blank line
        }

        //~~a "for" loop using "break" to print numbers but stop at a certain number
        static void Lesson6_14()
        {
            for (int i = 1; i <= 10; i++)   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~starts at 1 and ends after i=10, i goes up by 1
            {
                if (i % 3 == 0)   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~break or stop if i is divisible by 3
                    break;
                Console.Write($"{i} ");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~prints the numbers before the divisible by 3 number
            }
            Console.WriteLine("\r");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~allows looped numbers to be on their own line
            Console.WriteLine("\r");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~prints a blank line
        }

        //~~a "for" loop using "continue" to print numbers but skip a number and finish the rest of the "for" loop
        static void Lesson6_15()
        {
            for (int i = 1; i <= 10; i++)   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~starts at 1 and ends after i=10, i goes up by 1
            {
                if (i % 3 == 0)   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~skip if i is divisible by 3
                    continue;
                Console.Write($"{i} ");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~prints the numbers before the divisible by 3 number, skips it, and prints numbers after
            }
            Console.WriteLine("\r");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~allows looped numbers to be on their own line
            Console.WriteLine("\r");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~prints a blank line
        }

        //~~ask for an odd number and loop back to asking for one until given number is odd
        static void Lesson6_16()
        {
            string input;
            int output;
            while (true)
            {
                Console.Write("Enter an odd number: ");
                input = Console.ReadLine();
                if (int.TryParse(input, out output))   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~is it a number?
                {
                    if (output % 2 == 0)   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~is it odd?
                    {
                        Console.WriteLine("That is not an odd number, try again!");
                        continue;   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~go back to while(true)
                    }
                    else
                        break;   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~stop looping, output is odd
                }
                else
                    Console.WriteLine("That is not a number!");
            }
            Console.Write(output);
            Console.WriteLine("\r");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~allows number to be on it's own line
            Console.WriteLine("\r");   //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~prints a blank line
        }



        //~~~~Lesson8 Advanced Methods~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        //~~Show how value types and reference types pass data

        static void Lesson8_1()
        {
            void PassingValues(int valueType, Person referenceType)
            {
                valueType = 5;
                referenceType.Name = "Jane";
            }

            int x = 1;
            // instantiate a person object, assign to p
            Person p = new Person();
            p.Name = "Samantha";

            PassingValues(x, p);
            Console.WriteLine(x);
            Console.WriteLine(p.Name);
        }

        //~~using "ref" keyword to treat value type like a reference type so changes in method reflect back

        static void Lesson8_2()
        {
            void PassByValue(int num)
            {
                num = 5;
            }

            void PassByRef(ref int num)
            {
                num = 5;
            }

            int x = 1;

            PassByValue(x);
            Console.WriteLine(x);
            // "ref" has to be in the signature and when the method is invoked
            PassByRef(ref x);
            Console.WriteLine(x);
        }
    }
}
