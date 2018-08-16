using NUnit.Framework;
using System.Linq;
using System;


public class DatabaseTest
{
    [Test]
    public void InvalidArrayInConstructor_WithDrawThrowsException()
    {
        int[] arrayOfInt = new int[17];

        Assert.Throws<InvalidOperationException>(() => new Database(arrayOfInt), null);
    }

    [Test]
    public void CheckConstructor()
    {
        int[] arrayOfNum = new int[16];
        Database database = new Database(arrayOfNum);

        Assert.That(database.Numbers.Equals(arrayOfNum));
    }

    [Test]
    public void AddNumber()
    {
        int n = 5;
        int[] numbers = new int[4];
        Database database = new Database(numbers);

        database.Add(n);

        numbers[0] = n;
        Assert.That(database.Numbers.Equals(numbers));
    }

    [Test]
    public void RemoveNumber()
    {
        int[] numbers = new int[4];
        Database database = new Database(numbers);

        database.Remove();

        numbers[numbers.Length - 1] = 0;
        Assert.That(database.Numbers.Equals(numbers));
    }

    [Test]
    public void FetchArray()
    {
        int[] numbers = new int[7];
        Database database = new Database(numbers);

        int[] arrayClone = database.Fetch();

        Assert.AreEqual(arrayClone, numbers.Where(x => x != 0).ToArray());
    }
}

