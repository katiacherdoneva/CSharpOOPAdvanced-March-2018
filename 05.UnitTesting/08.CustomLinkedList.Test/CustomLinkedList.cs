using CustomLinkedList;
using Moq;
using NUnit.Framework;
using System;

public class ListNode
{
    private DynamicList<int> dynamicList;

    [SetUp]
    public void CreateClassDynamicList()
    {
        dynamicList = new DynamicList<int>();
    }

    [Test]
    [TestCase(-12)]
    [TestCase(int.MinValue)]
    [TestCase(int.MaxValue)]
    public void TElementOnIndex_InvalidIndex_ArgumentOutOfRangeException(int index)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            int element = this.dynamicList[index];
        });
    }

    [Test]
    [TestCase(0)]
    public void TElementOnIndex_ValidIndex_ReturnElementOnIndex(int index)
    {
        int elementAdd = 5;
        this.dynamicList.Add(elementAdd);

        Assert.That(elementAdd.Equals(this.dynamicList[index]));
    }

    [Test]
    [TestCase(-13)]
    [TestCase(0)]
    [TestCase(12)]
    public void Count_CountOnCollectionIncrease_CountIncrease(int value)
    {
        this.dynamicList.Add(value);

        Assert.AreEqual(1, this.dynamicList.Count);
    }

    [Test]
    [TestCase(new int[] { int.MinValue, 0, int.MaxValue })]
    public void Add_AddCollection_IncreaseCount(int[] values)
    {
        for (int index = 0; index < values.Length; index++)
        {
            int value = values[index];
            this.dynamicList.Add(value);

            Assert.AreEqual(value, dynamicList[index]);
        }       
    }

    [Test]
    public void RemoveAt_RemoveAtInvalidIndex_ArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => this.dynamicList.RemoveAt(0));
    }

    [Test]
    [TestCase(-12, 0)]
    public void RemoveAt_RemoveAtValidIndex_RemoveElement(int value, int index)
    {
        this.dynamicList.Add(value);

        Assert.AreEqual(value, this.dynamicList[index]);      
    }

    [Test]
    [TestCase(new int[] { int.MinValue, 0, int.MaxValue }, 5)]
    public void Remove_RemoveInvalidElement_ReturnMinusOne(int[] values, int invalidElement)
    {
        this.AddValues(values);

        Assert.AreEqual(-1, dynamicList.Remove(invalidElement));
    }

    [Test]
    [TestCase(new int[] { int.MinValue, 0, int.MaxValue }, 0)]
    public void Remove_RemoveValidElement_ReturnOne(int[] values, int validElement)
    {
        this.AddValues(values);

        Assert.AreEqual(1, dynamicList.Remove(validElement));
    }

    [Test]
    [TestCase(int.MaxValue, int.MinValue)]
    public void IndexOf_FindInvalidElement_ReturnMinusOne(int value, int findElement)
    {
        this.dynamicList.Add(value);

        Assert.AreEqual(-1, this.dynamicList.IndexOf(findElement));
    }

    [Test]
    [TestCase(int.MaxValue, int.MinValue)]
    public void IndexOf_FindValidElement_ReturnOne(int value, int findElement)
    {
        this.dynamicList.Add(value);
        this.dynamicList.Add(findElement);

        Assert.AreEqual(1, this.dynamicList.IndexOf(findElement));
    }

    [Test]
    [TestCase(int.MinValue, int.MaxValue)]
    public void Contains_ConvertIndexOfNegative_ReturnFalse(int value, int findElement)
    {
        this.dynamicList.Add(value);

        Assert.IsFalse(this.dynamicList.Contains(findElement));
    }

    [Test]
    [TestCase(new int[] { int.MinValue, int.MaxValue }, int.MinValue)]
    public void Contains_ConvertIndexOfPossitive_ReturnTrue(int[] values, int findElement)
    {
        this.AddValues(values);

        Assert.IsTrue(this.dynamicList.Contains(findElement));
    }

    private void AddValues(int[] values)
    {
        for (int index = 0; index < values.Length; index++)
        {
            int value = values[index];
            this.dynamicList.Add(value);
        }
    }

}

