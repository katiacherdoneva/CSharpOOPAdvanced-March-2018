using System;
using System.Collections.Generic;

public class StartUp
{
    static void Main()
    {
        SortedSet<Person> sortedSetPeople = new SortedSet<Person>();
        HashSet<Person> hashSetPeople = new HashSet<Person>();

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] infoForPerson = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = infoForPerson[0];
            int age = int.Parse(infoForPerson[1]);
            Person person = new Person(name, age);

            sortedSetPeople.Add(person);
            hashSetPeople.Add(person);
        }

        Console.WriteLine(sortedSetPeople.Count);
        Console.WriteLine(hashSetPeople.Count);
    }
}

