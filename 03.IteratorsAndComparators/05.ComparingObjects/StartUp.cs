using System;
using System.Collections.Generic;

public class StartUp
{
    static void Main()
    {
        List<Person> people = GetList();

        int number = int.Parse(Console.ReadLine());
        int countEqual = CountEqualPeople(people, number);

        PrintStatistics(people, countEqual);
    }

    private static List<Person> GetList()
    {
        List<Person> people = new List<Person>();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] infoForPerson = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = infoForPerson[0];
            int age = int.Parse(infoForPerson[1]);
            string town = infoForPerson[2];

            Person person = new Person(name, age, town);
            people.Add(person);
        }
        return people;
    }

    private static void PrintStatistics(List<Person> people, int countEqual)
    {
        string statistics = string.Empty;
        if (countEqual == 1)
        {
            statistics = "No matches";
        }
        else
        {
            statistics = $"{countEqual} {Math.Abs(countEqual - people.Count)} {people.Count}";
        }
        Console.WriteLine(statistics);
    }

    private static int CountEqualPeople(List<Person> people, int number)
    {
        int countEqual = 0;
        for (int i = 0; i < people.Count; i++)
        {
            int result = people[number - 1].CompareTo(people[i]);
            if (result == 0)
            {
                countEqual++;
            }
        }
        return countEqual;
    }
}

