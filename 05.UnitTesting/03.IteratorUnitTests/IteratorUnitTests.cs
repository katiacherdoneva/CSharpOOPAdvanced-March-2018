using NUnit.Framework;
using System;
using System.Collections.Generic;

public class IteratorUnitTests
{
    [Test]
    public void ConstructorAddEmptyList()
    {
        List<string> strings = new List<string>();

        Assert.Throws<ArgumentNullException>(() => new Iterator(strings), null);
    }

    [Test]
    public void ConstructorAddList()
    {
        List<string> strings = new List<string>() { "Pesho", "Stoqn" };

        Iterator iterator = new Iterator(strings);

        Assert.AreEqual(strings, iterator.Strings);
    }

    [Test]
    public void NoHasElement()
    {
        List<string> strings = new List<string>() { "Pesho", "Stoqn" };

        Iterator iterator = new Iterator(strings);

        Assert.That(iterator.HasNext(2).Equals(false));
    }

    [Test]
    public void HasElement()
    {
        List<string> strings = new List<string>() { "Pesho", "Stoqn" };

        Iterator iterator = new Iterator(strings);

        Assert.That(iterator.HasNext(0).Equals(true));
    }

    [Test]
    public void Print()
    {
        List<string> strings = new List<string>() { "Pesho", "Stoqn" };

        Iterator iterator = new Iterator(strings);

        Assert.That(strings[1], Is.EquivalentTo(iterator.Print(1)));
    }
}
