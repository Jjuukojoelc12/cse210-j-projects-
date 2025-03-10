using System;

public class Job
{
public string _company;
public string _jobtitle;
public string _job1;
public int _startyear;
public int _endyear;

public void DisplayResult()
{
    Console.WriteLine($"{_jobtitle} ({_company}) {_startyear}-{_endyear}");

    Job job1 = new Job();
        job1._jobtitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startyear = 2019;
        job1._endyear = 2022;

        Job job2 = new Job();
        job2._jobtitle = "Manager";
        job2._company = "Apple";
        job2._startyear = 2022;
        job2._endyear = 2023;

}
}
