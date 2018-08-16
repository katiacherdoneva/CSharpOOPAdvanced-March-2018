using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

public class BubbleSortUnitTest
{
    [Test]
    [TestCase(new int[] { 1, 4, 5, 3 })]
    [TestCase(new int[] { int.MaxValue, int.MinValue, 0 })]
    public void BubbleSortTest(int[] values)
    {
        Bubble bubble = new Bubble(values);
        bubble.BubbleSort();

        Type type = typeof(Bubble);
        FieldInfo fieldInfo = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .First(fi => fi.FieldType == typeof(int[]));
        int[] arrayBubbleSort = (int[])fieldInfo.GetValue(bubble);

        Array.Sort(values);

        Assert.AreEqual(values, arrayBubbleSort);
    }
}

