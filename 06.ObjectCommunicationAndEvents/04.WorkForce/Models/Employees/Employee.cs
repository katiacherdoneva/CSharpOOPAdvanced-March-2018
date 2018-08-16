public class Employee : IEmployee
{
    public Employee(string name)
    {
        this.Name = name;
    }

    public string Name { get; set; }

    public int WorkHoursPerWeek { get; set; }
}

