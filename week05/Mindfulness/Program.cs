// Program.cs
using System;
using System.Threading;

class Program
{
    static void Main()
    {
        int totalActivitiesDone = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness Program!");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine();
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. View Activity Log");
            Console.WriteLine("5. Quit");
            Console.WriteLine();
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectingActivity(),
                "3" => new ListingActivity(),
                _ => null
            };

            if (choice == "1" || choice == "2" || choice == "3")
            {
                activity.Start();
                totalActivitiesDone++;
            }
            else if (choice == "4")
            {
                Console.Clear();
                Console.WriteLine("Activity Log:");
                Console.WriteLine($"You have completed {totalActivitiesDone} activity(ies).");
                Console.WriteLine();
                Console.WriteLine("Press Enter to return to the menu...");
                Console.ReadLine();
            }
            else if (choice == "5")
            {
                Console.WriteLine();
                Console.WriteLine($"You completed {totalActivitiesDone} mindfulness activity(ies) today. Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid choice. Press Enter to try again...");
                Console.ReadLine();
            }
        }
    }
}
