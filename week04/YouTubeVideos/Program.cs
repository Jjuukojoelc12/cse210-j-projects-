using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // in seconds
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"  - {comment.CommenterName}: {comment.Text}");
        }
        Console.WriteLine(new string('-', 40));
    }
}

class Program
{
    static void Main()
    {
        // Creating video instances
        Video video1 = new Video("C# Basics for Beginners", "Tech Guru", 1200);
        Video video2 = new Video("Baking a Chocolate Cake", "Cooking World", 900);
        Video video3 = new Video("Top 10 Travel Destinations", "Globe Trotter", 1500);
        Video video4 = new Video("Artificial Intelligence Explained", "Tech Insider", 1800);

        // Adding comments to videos
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "Nice explanation."));

        video2.AddComment(new Comment("Dave", "Loved the recipe!"));
        video2.AddComment(new Comment("Eve", "Tried it, and it's delicious!"));
        video2.AddComment(new Comment("Frank", "Any vegan alternatives?"));

        video3.AddComment(new Comment("Grace", "I want to visit all these places!"));
        video3.AddComment(new Comment("Hank", "Amazing recommendations."));
        video3.AddComment(new Comment("Ivy", "Which one is budget-friendly?"));

        video4.AddComment(new Comment("Jack", "AI is the future!"));
        video4.AddComment(new Comment("Kate", "Very informative."));
        video4.AddComment(new Comment("Leo", "Can't wait for the next video!"));

        // Storing videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // Displaying information for each video
        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }
}
