using System;

public class StartUp
{
    static void Main()
    {
        PrintNameAddressTown();

        PrintDrinker();

        PrintClientOfTheBank();
    }

    private static void PrintClientOfTheBank()
    {
        string[] input = Console.ReadLine()
                    .Split(' ');

        string name = input[0];
        double accountBalance = double.Parse(input[1]);
        string bankName = input[2];

        Treeuple<string, double, string> treeuple = new Treeuple<string, double, string>(name, accountBalance, bankName);
        Console.WriteLine(treeuple.ToString());
    }

    private static void PrintDrinker()
    {
        string[] input = Console.ReadLine()
                    .Split(' ');

        string name = input[0];
        int litersOfBeer = int.Parse(input[1]);
        bool isDrunk = input[2] == "drunk" ? true : false;

        Treeuple<string, int, bool> treeuple = new Treeuple<string, int, bool>(name, litersOfBeer, isDrunk);
        Console.WriteLine(treeuple.ToString());
    }

    private static void PrintNameAddressTown()
    {
        string[] input = Console.ReadLine()
            .Split(' ');

        string firstName = input[0];
        string secondName = input[1];
        string fullName = $"{firstName} {secondName}";
        string address = input[2];
        string town = input[3];

        Treeuple<string, string, string> treeuple = new Treeuple<string, string, string>(fullName, address, town);
        Console.WriteLine(treeuple.ToString());
    }
}

