using System;

public class ConsoleWriter : IWritter
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
}

