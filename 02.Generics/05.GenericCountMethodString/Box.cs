using System;
using System.Linq;

public class Box<T>
    where T : IComparable
{
    public Box(T value)
    {
        this.Value = value;
    }

    public T Value { get; }

    public int CountGreaterThan(GenericCollection<Box<T>> elements)
    {
        return elements.Count(e => e.Value.CompareTo(this.Value) > 0);
    }
}

