using System;
using System.Collections.Generic;

public class Iterator
{
    public Iterator(List<string> strings)
    {
        this.Strings = strings;
    }

    private List<string> strings;

    public List<string> Strings
    {
        get { return strings; }
        set
        {
            if (value.Count == 0)
            {
                throw new ArgumentNullException("Empty list.");
            }
            strings = value;
        }
    }

    public bool Move(int index)
    {
        if (HasNext(index))
        {
            string lastEl = this.Strings[this.Strings.Count - 1]; 
            for (int i = index; i < this.Strings.Count - 1; i++)
            {
                this.Strings[i] = this.Strings[i + 1];
            }
            this.Strings[index] = lastEl;
            return true;
        }
        return false;
    }

    public bool HasNext(int index)
    {
        if (index >= this.Strings.Count - 1)
        {
            return false;
        }
        return true;
    }

    public string Print(int index)
    {
        if (this.Strings.Count == 0)
        {
            throw new ArgumentNullException("Empty list.");
        }
        return this.Strings[index];
    }
}

