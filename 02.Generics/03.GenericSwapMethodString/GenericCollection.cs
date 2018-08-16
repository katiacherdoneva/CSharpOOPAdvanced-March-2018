using System.Collections.Generic;
using System.Text;

public class GenericCollection<T>
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

    public void GenericSwap(int firstIndex, int secondIndex)
    {
        T elementOnFirstIndex = this.Elements[firstIndex];

        this.Elements[firstIndex] = this.Elements[secondIndex];
        this.Elements[secondIndex] = elementOnFirstIndex;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var element in this.Elements)
        {
            sb.AppendLine($"{element.GetType().FullName}: {element}");
        }
        return sb.ToString().TrimEnd();
    }
}

