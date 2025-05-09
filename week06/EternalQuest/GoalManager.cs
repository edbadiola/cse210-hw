using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> goals;
        public int TotalPoints { get; private set; }

        public GoalManager()
        {
            goals = new List<Goal>();
            TotalPoints = 0;
        }

        public void AddGoal(Goal goal)
        {
            goals.Add(goal);
        }

        public void DisplayGoals()
        {
            if (goals.Count == 0)
            {
                Console.WriteLine("No goals to show.");
            }
            else
            {
                for (int i = 0; i < goals.Count; i++)
                {
                    Console.Write($"{i}. ");
                    goals[i].Display();
                }
            }
        }

        public void RecordProgress()
        {
            Console.Write("Enter the index of the goal to record progress: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                if (index >= 0 && index < goals.Count)
                {
                    goals[index].RecordProgress();
                    TotalPoints += goals[index].Points;
                    Console.WriteLine($"Total Points: {TotalPoints}\n");
                }
                else
                {
                    Console.WriteLine("Invalid goal index.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }

        public void SaveProgress(string filename)
        {
            using (StreamWriter file = new StreamWriter(filename))
            {
                file.WriteLine(TotalPoints);
                foreach (var goal in goals)
                {
                    if (goal is ChecklistGoal checklistGoal)
                    {
                        file.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Points},{checklistGoal.TimesCompleted},{checklistGoal.TimesRequired},{checklistGoal.BonusPoints}");
                    }
                    else if (goal is EternalGoal eternalGoal)
                    {
                        file.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Points},{eternalGoal.TimesCompleted}");
                    }
                    else
                    {
                        file.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Points},{goal.GetStatus()}");
                    }
                }
            }
            Console.WriteLine("Progress saved.");
        }

        public void LoadProgress(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("No previous progress found.");
                return;
            }

            using (StreamReader file = new StreamReader(filename))
            {
                TotalPoints = int.Parse(file.ReadLine());
                goals.Clear();

                string line;
                while ((line = file.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    string goalType = parts[0];
                    string goalName = parts[1];
                    int points = int.Parse(parts[2]);

                    Goal goal = goalType switch
                    {
                        "SimpleGoal" => new SimpleGoal(goalName, points),
                        "EternalGoal" => new EternalGoal(goalName, points) { TimesCompleted = int.Parse(parts[3]) },
                        "ChecklistGoal" => new ChecklistGoal(goalName, points, int.Parse(parts[4]), int.Parse(parts[5]))
                        {
                            TimesCompleted = int.Parse(parts[3])
                        },
                        _ => null
                    };

                    if (goal != null)
                        goals.Add(goal);
                }
            }
            Console.WriteLine("Progress loaded.");
        }

        public void CreateGoal()
        {
            Console.WriteLine("Choose the type of goal to create:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            Console.Write("Enter the goal name: ");
            string goalName = Console.ReadLine();

            Console.Write("Enter the goal points: ");
            int points = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case "1":
                    AddGoal(new SimpleGoal(goalName, points));
                    Console.WriteLine("Simple goal added.");
                    break;
                case "2":
                    AddGoal(new EternalGoal(goalName, points));
                    Console.WriteLine("Eternal goal added.");
                    break;
                case "3":
                    Console.Write("Enter the number of times to complete: ");
                    int timesRequired = int.Parse(Console.ReadLine());

                    Console.Write("Enter bonus points: ");
                    int bonusPoints = int.Parse(Console.ReadLine());

                    AddGoal(new ChecklistGoal(goalName, points, timesRequired, bonusPoints));
                    Console.WriteLine("Checklist goal added.");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
