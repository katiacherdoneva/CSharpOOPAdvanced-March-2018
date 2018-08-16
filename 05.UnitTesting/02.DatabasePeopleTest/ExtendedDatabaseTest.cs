using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

public class ExtendedDatabaseTest
{
    [Test]
    public void ConstructorAddValidDictionary()
    {
        Dictionary<string, long> humans = new Dictionary<string, long>()
        {
          { "katerina", 19 },
          { "pesho", 20 }
        };
        People people = new People(humans);

        Assert.That(people.PeopleInfo.Equals(humans));
    }

    [Test]
    public void AddPerson()
    {
        Dictionary<string, long> humans = new Dictionary<string, long>()
        {
          { "katerina", 193232323232333323 },
          { "pesho", 20999499999999 }
        };
        People people = new People(humans);

        people.Add("Aneliq", 133000044444444);
        humans.Add("Aneliq", 133000044444444);

        Assert.That(people.PeopleInfo.Equals(humans));
        Assert.Throws<InvalidOperationException>(() => people.Add("Aneliq", 133000044444444), null);
    }

    [Test]
    public void RemovePerson()
    {
        Dictionary<string, long> humans = new Dictionary<string, long>()
        {
          { "katerina", 193232323232333323 },
          { "pesho", 20999499999999 }
        };
        People people = new People(humans);

        people.Remove("pesho");
        humans.Remove("pesho");

        Assert.That(people.PeopleInfo.Equals(humans));
    }

    [Test]
    public void FetchArray()
    {
        Dictionary<string, long> humans = new Dictionary<string, long>()
        {
          { "katerina", 193232323232333323 },
          { "pesho", 20999499999999 }
        };
        People people = new People(humans);

        Dictionary<string, long> dictionaryClone = people.Fetch();

        Assert.AreEqual(dictionaryClone, humans);
    }

    [Test]
    public void FindId()
    {
        Dictionary<string, long> humans = new Dictionary<string, long>()
        {
          { "katerina", 193232323232333323 },
          { "pesho", 20999499999999 }
        };
        People people = new People(humans);

        long id = people.FindId(193232323232333323);

        Assert.That(id.Equals(humans.First(x => x.Value == 193232323232333323).Value));
    }

    [Test]
    public void FindUsername()
    {
        Dictionary<string, long> humans = new Dictionary<string, long>()
        {
          { "katerina", 193232323232333323 },
          { "pesho", 20999499999999 }
        };
        People people = new People(humans);

        string username = people.FindUsername("katerina");

        Assert.That(username.Equals(humans.First(x => x.Key == username).Key));
    }
}

