using System.Collections;
using System.Collections.Generic;

public class GenericCollection<T> : IEnumerable<T>
{
    public GenericCollection()
    {
        this.Elements = new List<T>();
    }

    public List<T> Elements { get; private set; }

    public void AddElement(T element)
    {
        this.Elements.Add(element);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.Elements.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.Elements.GetEnumerator();
    }
}

