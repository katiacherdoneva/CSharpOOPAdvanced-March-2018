using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Lake : IEnumerable<int>
{
    public Lake(List<int> stones)
    {
        this.Stones = stones;
    }

    public List<int> Stones { get; private set; }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < this.Stones.Count; i+=2)
        {
            yield return this.Stones[i];
        }

        int startIndex = this.Stones.Count - 1;
        if(startIndex % 2 == 0)
        {
            --startIndex;
        }

        for (int i = startIndex; i >= 0; i-=2)
        {
            yield return this.Stones[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

