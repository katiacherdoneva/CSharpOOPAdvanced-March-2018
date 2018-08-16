using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LinkedListClass : IEnumerable
{
    public LinkedListClass()
    {
        this.Numbers = new LinkedList<int>();
    }

    public LinkedList<int> Numbers { get; private set; }

    public int Count => this.Numbers.Count;

    public void Add(int n)
    {
        this.Numbers.AddLast(n);
    }

    public void Remove(int n)
    {
        if (this.Numbers.Contains(n))
        {
            this.Numbers.Remove(n);
        }
    }

    public IEnumerator GetEnumerator()
    {
        return this.Numbers.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

