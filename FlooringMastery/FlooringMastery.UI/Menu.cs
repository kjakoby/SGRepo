using FlooringMastery.UI.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI
{
    public class Menu
    {
        public static void Start()
        {
            ConsoleIO.SplashScreen();
            Console.ReadKey();

            while (true)
            {
                ConsoleIO.Header("\t~Order Menu~");
                Console.WriteLine("1. Display all orders by a date.");
                Console.WriteLine("2. Display a specific order.");
                Console.WriteLine("3. Add an order.");
                Console.WriteLine("4. Edit an order.");
                Console.WriteLine("5. Remove an order.");
                Console.WriteLine("6. Quit");
                Console.WriteLine();
                Console.Write("Enter selection: ");

                string selectionNum = Console.ReadLine();
                switch (selectionNum)
                {
                    case "1":
                        //Display orders by date
                        DisplayAllWorkflow allWorkflow = new DisplayAllWorkflow();
                        allWorkflow.Execute();
                        break;
                    case "2":
                        //Display single order
                        DisplaySingleWorkflow singleWorkflow = new DisplaySingleWorkflow();
                        singleWorkflow.Execute();
                        break;
                    case "3":
                        //Add
                        AddWorkflow addWorkflow = new AddWorkflow();
                        addWorkflow.Execute();
                        break;
                    case "4":
                        //Edit
                        EditWorkflow editWorkflow = new EditWorkflow();
                        editWorkflow.Execute();
                        break;
                    case "5":
                        //Remove
                        RemoveWorkflow removeWorkflow = new RemoveWorkflow();
                        removeWorkflow.Execute();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine();
                        ConsoleIO.EntryError();
                        ConsoleIO.TryAgain();
                        Console.ReadKey();
                        continue;
                }
            }
        }
    }
}
