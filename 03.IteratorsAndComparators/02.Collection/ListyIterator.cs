using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class ListyIterator<T> : IEnumerable<T>
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
        bool hasNext = this.HasNext();
        if (hasNext)
        {
            ++this.index;
        }
        return hasNext;
    }

    public bool HasNext()
    {
        return index < this.Elements.Count - 1;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.Elements.Count; i++)
        {
            yield return this.Elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public string Print()
    {
        if (this.Elements.Count == 0)
        {
            throw new ArgumentException("Invalid Operation!");
        }

        return this.Elements[index].ToString();
    }

    public string PrintAll()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var element in this.Elements)
        {
            sb.Append($"{element} ");
        }
        return sb.ToString().Trim();
    }
}

