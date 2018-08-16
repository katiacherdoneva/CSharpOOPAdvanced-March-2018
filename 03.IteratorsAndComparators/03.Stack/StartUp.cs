using System;
using System.Linq;
using System.Text;

public class StartUp
{
    static void Main()
    {
        StackClass<int> stackClass = new StackClass<int>();
        GetStack(stackClass);

        PrintStack(stackClass);
        PrintStack(stackClass);
    }

    private static void GetStack(StackClass<int> stackClass)
    {
        string input = string.Empty;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] commandOfArgs = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string command = commandOfArgs[0];

            try
            {
                switch (command)
                {
                    case "Pop":
                        stackClass.Pop();
                        break;
                    case "Push":
                        int[] elements = commandOfArgs
                            .Skip(1)
                            .Select(int.Parse)
                            .ToArray();
                        stackClass.Push(elements);
                        break;
                    default:
                        break;
                }
            }
            catch (ArgumentException ArgEx)
            {
                Console.WriteLine(ArgEx.Message);
            }
        }
    }

    private static void PrintStack(StackClass<int> stackClass)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var element in stackClass)
        {
            sb.AppendLine(element.ToString());
        }

        if(sb.ToString().Trim() != string.Empty)
        {
            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}

