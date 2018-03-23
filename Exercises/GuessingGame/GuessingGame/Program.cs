using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int easyAnswer;
            int normalAnswer;
            int hardAnswer;
            int playerGuess;
            string playerName;
            string modeCheck;
            string guess;
            

            Random easyR = new Random();
            easyAnswer = easyR.Next(1, 6);

            Random normalR = new Random();
            normalAnswer = normalR.Next(1, 21);

            Random hardR = new Random();
            hardAnswer = hardR.Next(1, 51);

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("WELCOME TO THE GUESSING GAME!");
            Console.WriteLine("----------------------------------");
            Console.WriteLine();
            Console.Write("What is your name?: ");
            playerName = Console.ReadLine();
            Console.Clear();

            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("MAIN MENU");
                Console.WriteLine("---------------");
                Console.WriteLine();
                Console.WriteLine($"What mode would you like to play, {playerName}?");
                Console.WriteLine($"Type the first letter of the mode you would like to play: Easy, Normal, or Hard.");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Easy = 2 guesses of (1-5), Normal = 4 guesses of (1-20), Hard = 6 guesses of (1-50)");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Or press Q to quit.");
                modeCheck = Console.ReadLine();
                if (modeCheck == "Q" || modeCheck == "q")
                {
                    break;
                }
                if (modeCheck.ToUpper() == "E")
                {
                    int easyGuesses = 2;
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("EASY MODE");
                    Console.WriteLine("---------------");
                    Console.WriteLine();
                    do
                    {
                        
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"{playerName}, you have {easyGuesses} guesses remaining!");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("Enter your guess (1-5): or press \"Q\" to return to the MAIN MENU: ");
                        guess = Console.ReadLine();
                        if (guess == "Q" || guess == "q")
                        {
                            break;
                        }
                        if (int.TryParse(guess, out playerGuess))
                        {
                            if (playerGuess == easyAnswer)
                            {
                                Console.Clear();
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("\tCONGRATS!!");
                                Console.ResetColor();
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{easyAnswer} was the number.  You Win, {playerName}!");
                                Console.ResetColor();
                                Console.WriteLine("Press any key to return to the MAIN MENU.");
                                Console.ReadKey();
                                break;
                            }
                            else if (playerGuess < 1 || playerGuess > 5)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"That number is not valid, {playerName}!");
                                Console.ResetColor();
                            }
                            else if (playerGuess > easyAnswer)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Your guess was TOO HIGH, {playerName}!");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Your guess was too low, {playerName}!");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"That wasn't a number, {playerName}!");
                            Console.ResetColor();
                        }
                        easyGuesses -= 1;
                        
                    } while (easyGuesses>0);
                    if(easyGuesses==0)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("EASY MODE");
                        Console.WriteLine("---------------");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"{playerName}, you are out of guesses. Press any key to return to the MAIN MENU.");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                    
                }
                if (modeCheck.ToUpper() == "N")
                {
                    int normalGuesses = 4;
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("NORMAL MODE");
                    Console.WriteLine("---------------");
                    Console.WriteLine();
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"{playerName}, you have {normalGuesses} guesses remaining!");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("Enter your guess (1-20): or press \"Q\" to return to the MAIN MENU: ");
                        guess = Console.ReadLine();
                        if (guess == "Q" || guess == "q")
                        {
                            break;
                        }
                        if (int.TryParse(guess, out playerGuess))
                        {
                            if (playerGuess == normalAnswer)
                            {
                                Console.Clear();
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("\tCONGRATS!!");
                                Console.ResetColor();
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{normalAnswer} was the number.  You Win, {playerName}!");
                                Console.ResetColor();
                                Console.WriteLine("Press any key to return to the MAIN MENU.");
                                Console.ReadKey();
                                break;
                            }
                            else if (playerGuess < 1 || playerGuess > 20)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"That number is not valid, {playerName}!");
                                Console.ResetColor();
                            }
                            else if (playerGuess > normalAnswer)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Your guess was TOO HIGH, {playerName}!");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Your guess was too low, {playerName}!");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"That wasn't a number, {playerName}!");
                            Console.ResetColor();
                        }
                        normalGuesses -= 1;

                    } while (normalGuesses>0);
                    if (normalGuesses == 0)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("NORMAL MODE");
                        Console.WriteLine("---------------");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"{playerName}, you are out of guesses. Press any key to return to the MAIN MENU.");
                        Console.ResetColor();
                        Console.ReadKey();
                    }

                }
                if (modeCheck.ToUpper() == "H")
                {
                    int hardGuesses = 6;
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("HARD MODE");
                    Console.WriteLine("---------------");
                    Console.WriteLine();
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"{playerName}, you have {hardGuesses} guesses remaining!");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("Enter your guess (1-50): or press \"Q\" to quit: ");
                        guess = Console.ReadLine();
                        if (guess == "Q" || guess == "q")
                        {
                            break;
                        }
                        if (int.TryParse(guess, out playerGuess))
                        {
                            if (playerGuess == hardAnswer)
                            {
                                Console.Clear();
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("\tCONGRATS!!");
                                Console.ResetColor();
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{hardAnswer} was the number.  You Win, {playerName}!");
                                Console.ResetColor();
                                Console.WriteLine("Press any key to return to the MAIN MENU.");
                                Console.ReadKey();
                                break;
                            }
                            else if (playerGuess < 1 || playerGuess > 50)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"That number is not valid, {playerName}!");
                                Console.ResetColor();
                            }
                            else if (playerGuess > hardAnswer)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Your guess was TOO HIGH, {playerName}!");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Your guess was too low, {playerName}!");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"That wasn't a number, {playerName}!");
                            Console.ResetColor();
                        }
                        hardGuesses -= 1;

                    } while (hardGuesses>0);
                    if(hardGuesses==0)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("HARD MODE");
                        Console.WriteLine("---------------");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"{playerName}, you are out of guesses. Press any key to return to the MAIN MENU.");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                }
            } while (true);
        }
    }
}


// get player input
//Console.Write("Enter your guess (1-20): or press \"Q\" to quit: ");
//playerInput = Console.ReadLine();
//if (playerInput == "Q" || playerInput=="q")
//{
//    break;
//}
////attempt to convert the string to a number
//if (int.TryParse(playerInput, out playerGuess))
//{
//    if (playerGuess == theAnswer)
//    {
//        Console.ForegroundColor = ConsoleColor.Green;
//        Console.WriteLine($"{theAnswer} was the number.  You Win, {playerName}!");
//        Console.ResetColor();
//        Console.ReadKey();
//        break;
//    }
//    else if(playerGuess<1 || playerGuess>20)
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine($"That number is not valid, {playerName}!");
//        Console.ResetColor();
//    }
//    else if (playerGuess > theAnswer)
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine($"Your guess was TOO HIGH, {playerName}!");
//        Console.ResetColor();
//    }
//    else
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine($"Your guess was too low, {playerName}!");
//        Console.ResetColor();
//    }
//}
//else
//{
//    Console.ForegroundColor = ConsoleColor.Red;
//    Console.WriteLine($"That wasn't a number, {playerName}!");
//    Console.ResetColor();
//}

//Console.WriteLine("Press any key to quit.");
//Console.ReadKey();