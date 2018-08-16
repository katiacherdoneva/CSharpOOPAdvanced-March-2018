using System;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        string[] createList = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        ListyIterator<string> listyIterator = new ListyIterator<string>(createList.Skip(1).ToArray());

        string command = string.Empty;
        while ((command = Console.ReadLine()) != "END")
        {
            try
            {
                string result = string.Empty;
                switch (command)
                {
                    case "Move":
                        result = listyIterator.Move().ToString();
                        break;
                    case "HasNext":
                        result = listyIterator.HasNext().ToString();
                        break;
                    case "Print":
                        result = listyIterator.Print();
                        break;
                    case "PrintAll":
                        result = listyIterator.PrintAll();
                        break;
                    default:
                        break;
                }

                if(result != string.Empty)
                {
                    Console.WriteLine(result);
                }
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }
    }
}


