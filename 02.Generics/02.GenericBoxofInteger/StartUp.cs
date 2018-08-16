using System;

public class StartUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int value = int.Parse(Console.ReadLine());
            Box<int> boxInt = new Box<int>(value);

            Console.WriteLine(boxInt.ToString());
        }
    }
}

