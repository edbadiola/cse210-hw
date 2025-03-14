using System;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true; // Controls program loop

        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToShortDateString();
                    Entry newEntry = new Entry(date, prompt, response);
                    journal.AddEntry(newEntry);
                    Console.WriteLine("Entry added successfully.");
                    break;

                case "2":
                    Console.WriteLine("\nYour Journal Entries:");
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "5": // STRETCH feature - prevents accidental exit and reminding the user to save their work.
                    Console.Write("Are you sure you want to exit? (Y/N): ");
                    string exitChoice = Console.ReadLine().Trim().ToLower();

                    if (exitChoice == "y")
                    {
                        Console.WriteLine("Have a great day!");
                        running = false; // Stops the while loop, exiting the program
                    }
                    else
                    {
                        Console.WriteLine("We're back in the menu.");
                    }
                    break;

                default: 
                    Console.WriteLine("Invalid choice! Please enter a number between 1-5.");
                    break;
            }
        }
    }
}
