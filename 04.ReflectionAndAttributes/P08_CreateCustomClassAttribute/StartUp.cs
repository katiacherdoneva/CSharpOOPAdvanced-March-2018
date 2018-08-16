using System;
using System.Linq;

[Info("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
public class StartUp
{
    static void Main()
    {
        var command = Console.ReadLine();
        InfoAttribute attr = (InfoAttribute)typeof(StartUp).GetCustomAttributes(false).First();

        while (command != "END")
        {
            switch (command)
            {
                case "Author":
                    Console.WriteLine($"Author: {attr.Author}");
                    break;
                case "Revision":
                    Console.WriteLine($"Revision: {attr.Revision}");
                    break;
                case "Description":
                    Console.WriteLine($"Class description: {attr.Description}");
                    break;
                case "Reviewers":
                    Console.WriteLine($"Reviewers: {string.Join(", ", attr.Reviewers)}");
                    break;
                default:
                    break;
            }

            command = Console.ReadLine();
        }
    }
}

