// Activities/BreathingActivity.cs
using System;
using System.Threading;

class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        Name = "Welcome to Breathing Activity";
        Description = "This activity helps you relax by guiding you through slow breathing exercises.\n";
    }

    protected override void Execute()
    {
        for (int i = 0; i < Duration / 6; i++)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(3000);
            Console.WriteLine("Breathe out...\n");
            Thread.Sleep(3000);
        }
    }
}
