using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GenericCollection<T> : IEnumerable
    where T : IEnumerable, IComparable
{
    public GenericCollection()
    {
        this.Elements = new List<T>();
    }

    public GenericCollection(List<T> elements)
    {
        this.Elements = elements;
    }

    public List<T> Elements { get; private set; }

    public void Add(T element)
    {
        this.Elements.Add(element);
    }

    public void Remove(int index)
    {
        T element = this.Elements[index];

        this.Elements.RemoveAt(index);
    }

    public bool Contains(T element)
    {
        return this.Elements.Contains(element);
    }

    public void Swap(int index1, int index2)
    {
        T elementOnFirstIndex = this.Elements[index1];

        this.Elements[index1] = this.Elements[index2];
        this.Elements[index2] = elementOnFirstIndex;
    }
    public int CountGreaterThan(T element)
    {
        return this.Elements.Count(e => e.CompareTo(element) > 0);
    }
    public T Max()
    {
        return this.Elements.Max();
    }

    public T Min()
    {
        return this.Elements.Min();
    }

    public string Print()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var element in this)
        {
            sb.AppendLine($"{element}");
        }

        return sb.ToString().TrimEnd();
    }

    public IEnumerator GetEnumerator()
    {
        return this.Elements.GetEnumerator();
    }
}