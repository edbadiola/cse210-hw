using System;
using System.Threading;

class ReflectingActivity : Activity
{
    public ReflectingActivity()
    {
        Name = "Welcome to Reflection Activity";
        Description = "This activity helps you reflect on times when you have shown strength and resilience.\n";
    }

    protected override void Execute()
    {
        // Prompts for the activity
        string[] prompts = {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        // Reflection questions
        string[] questions = {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        Random random = new Random();

        // Select a random prompt
        string selectedPrompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(selectedPrompt);
        Thread.Sleep(2000); // Wait for 2 seconds to let the user reflect

        // Ask reflection questions
        int questionCount = 0;
        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < Duration)
        {
            // Ensure we don't exceed the total time duration
            if (questionCount >= questions.Length)
            {
                questionCount = 0; // Loop back through questions if we run out
            }

            Console.WriteLine(questions[questionCount]);
            Thread.Sleep(10000);

            questionCount++; // Move to the next question
        }

    }
}

