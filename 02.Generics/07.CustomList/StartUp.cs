using System;

public class StartUp
{
    static void Main()
    {
        GenericCollection<string> genericCollection = new GenericCollection<string>();
        string input = string.Empty;

        while ((input = Console.ReadLine()) != "END")
        {
            string result = string.Empty;
            CommandExecutor(genericCollection, input, ref result);

            if(result != string.Empty)
            {
                Console.WriteLine(result);
            }
        }
    }

    private static void CommandExecutor(GenericCollection<string> genericCollection, string input, ref string result)
    {
        string[] commandOfArgs = input
                        .Split(' ');

        switch (commandOfArgs[0])
        {
            case "Add":
                genericCollection.Add(commandOfArgs[1]);
                break;
            case "Remove":
                int index = int.Parse(commandOfArgs[1]);
                genericCollection.Remove(index);
                break;
            case "Contains":
                result = genericCollection.Contains(commandOfArgs[1]).ToString();
                break;
            case "Swap":
                int index1 = int.Parse(commandOfArgs[1]);
                int index2 = int.Parse(commandOfArgs[2]);
                genericCollection.Swap(index1, index2);
                break;
            case "Greater":
                result = genericCollection.CountGreaterThan(commandOfArgs[1]).ToString();
                break;
            case "Max":
                result = genericCollection.Max();
                break;
            case "Min":
                result = genericCollection.Min();
                break;
            case "Print":
                result = genericCollection.Print();
                break;
        }
    }
}

