using System;

public class StandardEmployee : Employee
{
    public StandardEmployee(string name)
        : base(name)
    {
        this.WorkHoursPerWeek = 40;
    }
}

