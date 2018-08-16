using System;

public class StartUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string value = Console.ReadLine();
            Box<string> boxString = new Box<string>(value);

            Console.WriteLine(boxString.ToString());
        }
    }
}

