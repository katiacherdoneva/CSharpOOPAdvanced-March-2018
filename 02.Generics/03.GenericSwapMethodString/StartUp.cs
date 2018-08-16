using System;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        GenericCollection<string> genericCollection = new GenericCollection<string>();

        FullGenericCollection(n, genericCollection);

        SwapGenericCollection(genericCollection);

        Console.WriteLine(genericCollection.ToString());
    }

    private static void FullGenericCollection(int n, GenericCollection<string> genericCollection)
    {
        for (int i = 0; i < n; i++)
        {
            string element = Console.ReadLine();

            genericCollection.AddElement(element);
        }
    }

    private static void SwapGenericCollection(GenericCollection<string> genericCollection)
    {
        int[] indexes = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        genericCollection.GenericSwap(indexes[0], indexes[1]);
    }
}

