using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class StackClass<T> : IEnumerable<T>
{
    public StackClass()
    {
        this.Elements = new List<T>();
    }

    public List<T> Elements { get; private set; }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.Elements.Count - 1; i >= 0; i--)
        {
            yield return this.Elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public void Pop()
    {
        if (this.Elements.Count == 0)
        {
            throw new ArgumentException("No elements");
        }

        this.Elements.RemoveAt(this.Elements.Count - 1);
    }

    public void Push(T[] elements)
    {
        this.Elements.AddRange(elements);
    }

    public string Print()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var element in this.Elements)
        {
            sb.AppendLine(element.ToString());
        }
        return sb.ToString().TrimEnd();
    }
}

