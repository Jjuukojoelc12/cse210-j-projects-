class Program
{
    static void Main(string[] args)
    {
    
    }
}

abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract int RecordEvent(); // returns earned points
    public abstract bool IsComplete();
    public abstract string GetStatus();
    public abstract string Serialize();
}


class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) 
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return _points;
        }
        return 0;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetStatus() => _isComplete ? "[X]" : "[ ]";

    public override string Serialize() => $"SimpleGoal|{_name}|{_description}|{_points}|{_isComplete}";
}


class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) 
        : base(name, description, points) { }

    public override int RecordEvent() => _points;

    public override bool IsComplete() => false;

    public override string GetStatus() => "[~]";

    public override string Serialize() => $"EternalGoal|{_name}|{_description}|{_points}";
}


class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus) 
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
            return _currentCount == _targetCount ? _points + _bonus : _points;
        }
        return 0;
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override string GetStatus() => IsComplete() ? "[X]" : $"[{_currentCount}/{_targetCount}]";

    public override string Serialize() => $"ChecklistGoal|{_name}|{_description}|{_points}|{_currentCount}|{_targetCount}|{_bonus}";
}
