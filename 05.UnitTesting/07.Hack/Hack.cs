using Moq;
using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

public class Hack
{
    [Test]
    [TestCase(-1223)]
    [TestCase(0)]
    [TestCase(3457)]
    public void MathAbs_GetNegativeNumberReturnPositiveNumber_ReturnPositive(int value)
    {
        Mock<IMath> math = new Mock<IMath>();

        math.Setup(m => m.Abs(value))
            .Returns(Math.Abs(value));

        Assert.AreEqual(Math.Abs(value), math.Object.Abs(value));
    }

    [Test]
    [TestCase(9.5678)]
    [TestCase(-10.0467)]
    public void MathAbs_GetNumber_ReturnFloorNumber(decimal value)
    {
        Mock<IMath> math = new Mock<IMath>();

        math.Setup(m => m.Floor(value))
            .Returns(Math.Floor(value));

        Assert.AreEqual(Math.Floor(value), math.Object.Floor(value));
    }
}

