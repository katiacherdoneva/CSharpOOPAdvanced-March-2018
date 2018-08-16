using System;

public class StartUp
{
    static void Main()
    {
        PrintNameAndAddress();

        PrintNameAndAmountOfBeerCanDrink();

        PrintIntAndDouble();
    }

    private static void PrintIntAndDouble()
    {
        string[] input = Console.ReadLine()
                    .Split(' ');

        int integer = int.Parse(input[0]);
        double d = double.Parse(input[1]);

        Tuple<int, double> tuple = new Tuple<int, double>(integer, d);
        Console.WriteLine(tuple.ToString());
    }

    private static void PrintNameAndAmountOfBeerCanDrink()
    {
        string[] input = Console.ReadLine()
                    .Split(' ');

        string name = input[0];
        int litersOfBeer = int.Parse(input[1]);

        Tuple<string, int> tuple = new Tuple<string, int>(name, litersOfBeer);
        Console.WriteLine(tuple.ToString());
    }

    private static void PrintNameAndAddress()
    {
        string[] input = Console.ReadLine()
            .Split(' ');

        string firstName = input[0];
        string secondName = input[1];
        string fullName = $"{firstName} {secondName}";
        string address = input[2];

        Tuple<string, string> tuple = new Tuple<string, string>(fullName, address);
        Console.WriteLine(tuple.ToString());
    }
}

