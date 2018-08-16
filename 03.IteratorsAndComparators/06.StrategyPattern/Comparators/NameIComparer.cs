using System;
using System.Collections.Generic;

public class NameIComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        string firstName = x.Name.ToLower();
        string secondName = y.Name.ToLower();

        int result = firstName.Length.CompareTo(secondName.Length);
        if (result == 0)
        {
           result = firstName[0].CompareTo(secondName[0]); ;
        }
        return result;
    }
}

