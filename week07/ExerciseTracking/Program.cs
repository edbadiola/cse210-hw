using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create activities with the current date
        List<Activity> activities = new List<Activity>
        {
            new Running(DateTime.Now, 30, 4.8),
            new Cycling(DateTime.Now, 45, 20.0),
            new Swimming(DateTime.Now, 30, 20)
        };

        // Display the summary for each activity
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
