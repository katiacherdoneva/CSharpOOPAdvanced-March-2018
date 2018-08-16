using System;

public class StartUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        GenericCollection<Box<string>> genericCollection = new GenericCollection<Box<string>>();

        FullGenericCollection(n, genericCollection);

        string element = Console.ReadLine();
        Box<string> box = new Box<string>(element);

        int countGreaterElements = box.CountGreaterThan(genericCollection);

        Console.WriteLine(countGreaterElements);
    }

    private static void FullGenericCollection(int n, GenericCollection<Box<string>> genericCollection)
    {
        for (int i = 0; i < n; i++)
        {
            string element = Console.ReadLine();
            Box<string> box = new Box<string>(element);

            genericCollection.AddElement(box);
        }
    }
}

