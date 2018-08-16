using System;
using System.Collections.Generic;

public class ListyIterator<T>
{
    private int index;

    public ListyIterator(params T[] elements)
    {
        this.Elements = new List<T>(elements);
        this.index = 0;
    }

    public List<T> Elements { get; private set; }

    public bool Move()
    {
        int currentIndex = index;
        if(currentIndex + 1 < this.Elements.Count)
        {
            ++this.index;
            return true;
        }
        return false;
    }

    public bool HasNext()
    {
        int currentIndex = this.index + 1;
        return currentIndex < this.Elements.Count;
    }

    public string Print()
    {
        if(this.Elements.Count == 0)
        {
            throw new ArgumentException("Invalid Operation!");
        }

        return this.Elements[index].ToString();
    }
}

