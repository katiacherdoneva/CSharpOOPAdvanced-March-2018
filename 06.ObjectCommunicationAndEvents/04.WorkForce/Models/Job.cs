using System;

public delegate void UpdateEmployeesEventHardler(Job job);

public class Job
{
    public event UpdateEmployeesEventHardler UpdateEmployees;

    public Job(IEmployee employee, string name, int hoursOfWorkRequired)
    {
        this.Employee = employee;
        this.Name = name;
        this.HoursOfWorkRequired = hoursOfWorkRequired;
    }

    public string Name { get; private set; }

    public int HoursOfWorkRequired { get; private set; }

    public IEmployee Employee { get; private set; }

    public void Update()
    {
        this.HoursOfWorkRequired -= this.Employee.WorkHoursPerWeek;

        if (this.HoursOfWorkRequired <= 0)
        {
            Console.WriteLine($"Job {this.Name} done!");
            this.UpdateEmployees?.Invoke(this);
        }
    }

    public override string ToString()
    {
        return $"Job: {this.Name} Hours Remaining: {this.HoursOfWorkRequired}";
    }
}

