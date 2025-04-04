// Activities/Activity.cs
using System;
using System.Threading;

abstract class Activity
{
    protected string Name { get; set; }
    protected string Description { get; set; }
    protected int Duration { get; set; }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"{Name}...\n");
        Console.WriteLine(Description);
        Console.Write("How long, in seconds, would you like for your session? ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("\nGet ready...");
        Thread.Sleep(2000);

        Execute();

        Console.WriteLine("Well done! You've completed the activity.");
        Thread.Sleep(2000);
    }

    protected abstract void Execute();
}
