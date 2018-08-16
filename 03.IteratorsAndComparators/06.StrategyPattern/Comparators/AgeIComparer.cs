using System;
using System.Collections.Generic;

public class AgeIComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        return x.Age.CompareTo(y.Age);
    }
}

