using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private List<IEmployee> employees;
    private Jobs jobs;

    public Engine()
    {
        this.employees = new List<IEmployee>();
        this.jobs = new Jobs();
    }

    public void Run()
    {
        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] commandOfArgs = input.Split(' ');
            string command = commandOfArgs[0];

            switch (command)
            {
                case "Job":
                    string nameOfJob = commandOfArgs[1];
                    int hoursOfWorkRequired = int.Parse(commandOfArgs[2]);
                    string employeeName = commandOfArgs[3];

                    IEmployee employee = employees.First(x => x.Name ==  employeeName);
                    Job job = new Job(employee, nameOfJob, hoursOfWorkRequired);
                    this.jobs.AddEventListener(job);
                    break;
                case "StandardEmployee":
                    StandardEmployee standardEmployee = new StandardEmployee(commandOfArgs[1]);
                    this.employees.Add(standardEmployee);
                    break;
                case "PartTimeEmployee":
                    PartTimeEmployee partTimeEmployee = new PartTimeEmployee(commandOfArgs[1]);
                    this.employees.Add(partTimeEmployee);
                    break;
                case "Pass":
                    foreach (var j in this.jobs.ToList())
                    {
                        j.Update();
                    }
                    break;
                case "Status":
                    foreach (var j in this.jobs)
                    {
                        Console.WriteLine(j.ToString());
                    }
                    break;
            }
        }
    }
}
