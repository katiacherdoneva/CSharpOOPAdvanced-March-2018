using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StartUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Person> people = GetList(n);

        SortedSet<Person> sortName = new SortedSet<Person>(people, new NameIComparer());
        SortedSet<Person> sortAge = new SortedSet<Person>(people, new AgeIComparer());

        PrintSortedSet(sortName);
        PrintSortedSet(sortAge);
    }

    private static void PrintSortedSet(SortedSet<Person> peopleSort)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var person in peopleSort)
        {
            sb.AppendLine(person.ToString());
        }
        Console.WriteLine(sb.ToString().TrimEnd());
    }

    private static List<Person> GetList(int n)
    {
        List<Person> people = new List<Person>();

        for (int i = 0; i < n; i++)
        {
            string[] infoForPerson = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = infoForPerson[0];
            int age = int.Parse(infoForPerson[1]);
            Person person = new Person(name, age);
            people.Add(person);
        }
        return people;
    }
}

