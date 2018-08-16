using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class People : IPeople
{
    private Dictionary<string, long> peopleInfo;

    public People(Dictionary<string, long> peopleInfo)
    {
        this.PeopleInfo = peopleInfo;
    }

    public Dictionary<string, long> PeopleInfo
    {
        get { return peopleInfo; }
        set { peopleInfo = value; }
    }

    public void Add(string username, long id)
    {
        int count = this.PeopleInfo.Count;
        if(count >= 16)
        {
            throw new InvalidOperationException("Full dictionary.");
        }

        if(this.PeopleInfo.ContainsKey(username.ToLower()) || this.PeopleInfo.ContainsValue(id))
        {
            throw new InvalidOperationException("There are already users with this username/id.");
        }

        this.PeopleInfo.Add(username.ToLower(), id);
    }

    public void Remove(string username)
    {
        int lenght = this.PeopleInfo.Count;

        if (lenght == 0)
        {
            throw new InvalidOperationException("No people.");
        }
        this.PeopleInfo.Remove(username);
    }

    public Dictionary<string, long> Fetch()
    {
        Dictionary<string, long> peopleClone = new Dictionary<string, long>();
        foreach (var person in this.PeopleInfo)
        {
            peopleClone.Add(person.Key, person.Value);
        }
        return peopleClone;
    }

    public long FindId(long id)
    {
        if(!this.PeopleInfo.ContainsValue(id))
        {
            throw new InvalidOperationException("Invalid id.");
        }

        return this.PeopleInfo.First(x => x.Value == id).Value;
    }

    public string FindUsername(string username)
    {
        if (!this.PeopleInfo.ContainsKey(username))
        {
            throw new InvalidOperationException("Invalid username.");
        }

        return this.PeopleInfo.First(x => x.Key == username).Key;
    }
}

