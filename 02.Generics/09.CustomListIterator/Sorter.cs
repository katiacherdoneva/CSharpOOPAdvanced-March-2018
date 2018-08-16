using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Sorter
{
    public GenericCollection<T> Sort<T>(GenericCollection<T> genericCollection)
        where T : IComparable, IEnumerable
    {
        List<T> sorter = genericCollection.Elements
            .OrderBy(x => x)
            .ToList();

        return new GenericCollection<T>(sorter);
    }
}

