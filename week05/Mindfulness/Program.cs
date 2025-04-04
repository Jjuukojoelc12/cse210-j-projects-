using System;
using System.Threading;

class BreathingActivity
{
    private int duration;

    public void Start()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Breathing Activity!");
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly.");
        Console.WriteLine("Clear your mind and focus on your breathing.\n");

        Console.Write("Enter duration in seconds: ");
        if (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
        {
            Console.WriteLine("Please enter a valid positive number for the duration.");
            return;
        }

        Console.Clear();
        Console.WriteLine("Get ready to begin...");
        Thread.Sleep(2000);

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        bool breatheIn = true;

        while (DateTime.Now < endTime)
        {
            if (breatheIn)
                DisplayBreathing("Breathe in...", 4);
            else
                DisplayBreathing("Breathe out...", 6);

            breatheIn = !breatheIn;
        }

        Console.WriteLine("\nWell done! You have completed the Breathing Activity.");
        Console.WriteLine("You should feel more relaxed and calm now.\n");
    }

    private void DisplayBreathing(string message, int seconds)
    {
        Console.Write($"\n{message} ");
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}

// Reflection Activity
using System;
using System.Collections.Generic;
using System.Threading;

class ReflectionActivity
{
    private int duration;
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>
    {
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

    private Random random = new Random();

    public void Start()
    {
        ShowStartingMessage("Reflection Activity", 
            "This activity will help you reflect on times in your life when you have shown strength and resilience. " +
            "This will help you recognize the power you have and how you can use it in other aspects of your life.");

        Console.Write("Enter duration in seconds: ");
        if (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive number.");
            return;
        }

        Console.Clear();
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine("\nWhen you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on the following questions as they relate to this experience...");
        ShowSpinner(3);

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            Console.WriteLine($"\n> {question}");
            ShowSpinner(6);
        }

        ShowEndingMessage("Reflection Activity");
    }

    private string GetRandomPrompt()
    {
        return prompts[random.Next(prompts.Count)];
    }

    private string Get


// Listing Activity

using System;
using System.Collections.Generic;
using System.Threading;

class ListingActivity
{
    private int duration;
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random random = new Random();

    public void Start()
    {
        ShowStartingMessage("Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        Console.Write("Enter duration in seconds: ");
        if (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive number.");
            return;
        }

        string prompt = GetRandomPrompt();
        Console.Clear();
        Console.WriteLine("List as many responses as you can to the following prompt:\n");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine("\nYou will have a few seconds to think before you begin...");
        ShowCountdown(5);

        List<string> responses = CollectResponses(duration);

        Console.WriteLine($"\nYou listed {responses.Count} item(s). Great job!");
        ShowEndingMessage("Listing Activity");
    }

    private string GetRandomPrompt()
    {
        return prompts[random.Next(prompts.Count)];
    }

    private List<string> CollectResponses(int seconds)
    {
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        Console.WriteLine("\nStart listing now! (Press Enter after each item)");

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            if (Console.KeyAvailable)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    items.Add(input.Trim());
                }
            }
        }

        return items;
    }

    private void ShowStartingMessage(string activityName, string description)
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {activityName}!\n");
        Console.WriteLine(description + "\n");
    }

    private void ShowEndingMessage(string activityName)
    {
        Console.WriteLine($"\nWell done! You have completed the {activityName}.");
        Console.WriteLine("Reflect on the positive things you've listed and carry them with you.\n");
    }

    private void ShowCountdown(int seconds)
    {
        Console.WriteLine();
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine("\n");
    }
}
