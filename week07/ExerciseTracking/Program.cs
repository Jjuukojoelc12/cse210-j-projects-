using System;
using System.Collections.Generic;

abstract class Activity
{
    private DateTime _date;
    private int _lengthInMinutes;

    public Activity(DateTime date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    public int GetLength() => _lengthInMinutes;
    public DateTime GetDate() => _date;

    public abstract double GetDistance(); // in kilometers
    public abstract double GetSpeed();    // kph
    public abstract double GetPace();     // min/km

    public virtual string GetSummary()
    {
        return $"{_date.ToString("dd MMM yyyy")} {this.GetType().Name} ({_lengthInMinutes} min): " +
               $"Distance: {GetDistance():0.0} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.00} min per km";
    }
}

class Running : Activity
{
    private double _distance; // in kilometers

    public Running(DateTime date, int lengthInMinutes, double distance) : base(date, lengthInMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed() => _distance / (GetLength() / 60.0);

    public override double GetPace() => GetLength() / _distance;
}

class Cycling : Activity
{
    private double _speed; // in kilometers per hour

    public Cycling(DateTime date, int lengthInMinutes, double speed) : base(date, lengthInMinutes)
    {
        _speed = speed;
    }

    public override double GetDistance() => _speed * (GetLength() / 60.0);

    public override double GetSpeed() => _speed;

    public override double GetPace() => 60.0 / _speed;
}

class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int lengthInMinutes, int laps) : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => (_laps * 50.0) / 1000.0; // 50 meters per lap converted to kilometers

    public override double GetSpeed() => GetDistance() / (GetLength() / 60.0);

    public override double GetPace() => GetLength() / GetDistance();
}

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 4.8),
            new Cycling(new DateTime(2022, 11, 3), 45, 20),
            new Swimming(new DateTime(2022, 11, 3), 40, 30)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
