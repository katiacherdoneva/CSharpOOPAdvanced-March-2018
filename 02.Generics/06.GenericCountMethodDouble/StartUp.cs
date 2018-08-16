using System;

public class StartUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        GenericCollection<Box<double>> genericCollection = new GenericCollection<Box<double>>();

        FullGenericCollection(n, genericCollection);

        double element = double.Parse(Console.ReadLine());
        Box<double> box = new Box<double>(element);

        int countGreaterElements = box.CountGreaterThan(genericCollection);

        Console.WriteLine(countGreaterElements);
    }

    private static void FullGenericCollection(int n, GenericCollection<Box<double>> genericCollection)
    {
        for (int i = 0; i < n; i++)
        {
            double element = double.Parse(Console.ReadLine());
            Box<double> box = new Box<double>(element);

            genericCollection.AddElement(box);
        }
    }
}

