// Activities/ListingActivity.cs
using System;
using System.Collections.Generic;
using System.Threading;

class ListingActivity : Activity
{
    public ListingActivity()
    {
        Name = "Listing Activity";
        Description = "This activity helps you list positive aspects of your life to enhance gratitude.\n" ;
    }

    protected override void Execute()
    {
        Console.WriteLine("List as many things as you can that make you happy:");
        List<string> responses = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("- ");
            responses.Add(Console.ReadLine());
        }

        Console.WriteLine($"You listed {responses.Count} items. Well done!");
    }
}
