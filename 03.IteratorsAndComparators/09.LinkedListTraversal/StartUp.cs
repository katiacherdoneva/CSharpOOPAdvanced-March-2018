using System;
using System.Linq;
using System.Text;

public class StartUp
{
    static void Main()
    {
        LinkedListClass linkedListClass = GetLinkedList();

        Console.WriteLine(linkedListClass.Count);
        PrintLinkedList(linkedListClass);
    }

    private static void PrintLinkedList(LinkedListClass linkedListClass)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var number in linkedListClass)
        {
            sb.Append($"{number.ToString()} ");
        }
        Console.WriteLine(sb.ToString());
    }

    private static LinkedListClass GetLinkedList()
    {
        LinkedListClass linkedListClass = new LinkedListClass();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine()
                .Split(' ');
            string command = input[0];
            int number = int.Parse(input[1]);


            switch (command)
            {
                case "Add":
                    linkedListClass.Add(number);
                    break;
                case "Remove":
                    linkedListClass.Remove(number);
                    break;
            }
        }
        return linkedListClass;
    }
}

