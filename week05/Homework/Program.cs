
public class MathAssignment : Assignment
    {
    private string _textbookSection = "";
    private string _problems = "";

    public MathAssignment(string studentName, string topic, string _textbookSection, string problems)
    :base(studentName, topic)
    {
        _textbookSection = _textbookSection;
        _problems _problems;
    }
    
    public  string GetHomeworkList()
    {
        return $"section {_textbookSection} Problems {_problems}";
    }
    }


public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title)
    : base(studentName, topic)
    {
        _title = title;
    } 
public string GetWritingInformation()
{
    string studentName = GetStudentName();
    return $"title {_title} by {studentName}";
}
}