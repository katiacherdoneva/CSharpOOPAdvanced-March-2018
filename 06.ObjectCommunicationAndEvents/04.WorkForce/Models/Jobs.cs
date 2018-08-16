using System;
using System.Collections.Generic;

public class Jobs : List<Job>
{
    public void AddEventListener(Job job)
    {
        this.Add(job);
        job.UpdateEmployees += this.RemoveJob;
    }

    public void RemoveJob(Job job)
    {
        this.Remove(job);
    }
}
