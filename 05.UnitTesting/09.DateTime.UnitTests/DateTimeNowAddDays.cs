using System;
using NUnit.Framework;
using System.Globalization;
using Moq;

public class DateTimeNowAddDays
{
    private DateTime dateTimeNow = DateTime.Parse("11/09/2018");

    [Test]
    public void DayMiddleOfTheMonth_ReturnDayMiddleOfTheMonth()
    {
        const int AddDaysMiddle = 4;

        Mock<IDateTimeNowAddDays> dateTime = new Mock<IDateTimeNowAddDays>();

        dateTime.Setup(d => d.DayMiddleOfTheMonth(dateTimeNow))
            .Returns(dateTimeNow.AddDays(AddDaysMiddle).Date);

        DateTime dateTimeExpected = dateTimeNow.AddDays(AddDaysMiddle).Date;

        Assert.AreEqual(dateTimeExpected, dateTime.Object.DayMiddleOfTheMonth(dateTimeNow).Date);
    }
    
    [Test]
    public void NextMonth_DateTimeNowNextMonth_ReturnNextMonth()
    {
        const int AddDaysNextMonth = 20;

        Mock<IDateTimeNowAddDays> dateTime = new Mock<IDateTimeNowAddDays>();

        dateTime.Setup(d => d.NextMonth(dateTimeNow))
            .Returns(dateTimeNow.AddDays(AddDaysNextMonth).Month);

        int dateTimeExpected = dateTimeNow.AddDays(AddDaysNextMonth).Month;

        Assert.AreEqual(dateTimeExpected, dateTime.Object.NextMonth(dateTimeNow));
    }

    [Test]
    public void AddNegativeDays_DateTimeNowAddNegativeDays_ReturnPreviousMonth()
    {
        const int AddNegativeDays = -12;

        Mock<IDateTimeNowAddDays> dateTime = new Mock<IDateTimeNowAddDays>();

        dateTime.Setup(d => d.AddNegativeDay(dateTimeNow))
            .Returns(dateTimeNow.AddDays(AddNegativeDays).Month);

        int dateTimeExpected = dateTimeNow.AddDays(AddNegativeDays).Month;

        Assert.AreEqual(dateTimeExpected, dateTime.Object.AddNegativeDay(dateTimeNow));
    }

    [Test]
    public void AddDayLeapYear_ReturnYearWith29February()
    {
        string AddDayLeapYear = "29/02/2018";

        dateTimeNow = DateTime.Parse("28/02/2018");
        Mock<IDateTimeNowAddDays> dateTime = new Mock<IDateTimeNowAddDays>();

        dateTime.Setup(d => d.AddDayLeapYear(dateTimeNow))
            .Returns(AddDayLeapYear);

        Assert.AreEqual(AddDayLeapYear, dateTime.Object.AddDayLeapYear(dateTimeNow));
    }

    [Test]
    public void NonLeapYears_LeapYearNon29February_ReturnFirstMarch()
    {
        DateTime nextDateInLeapYear = DateTime.Parse("01/03/2016");

        dateTimeNow = DateTime.Parse("28/02/2016");
        Mock<IDateTimeNowAddDays> dateTime = new Mock<IDateTimeNowAddDays>();

        dateTime.Setup(d => d.NextDayLeapYear(dateTimeNow))
            .Returns(nextDateInLeapYear.Date);

        Assert.AreEqual(nextDateInLeapYear.Date, dateTime.Object.NextDayLeapYear(dateTimeNow));
    }

    [Test]
    public void AddDayDateTimeMinValue_ReturnDateTimeMinValue()
    {
        DateTime minValue = DateTime.MinValue;

        Mock<IDateTimeNowAddDays> dateTime = new Mock<IDateTimeNowAddDays>();

        dateTime.Setup(d => d.DateTimeMinValue())
            .Returns(minValue.Date);

        Assert.AreEqual(minValue.Date, dateTime.Object.DateTimeMinValue());
    }

    [Test]
    public void DateTimeMaxValue_ReturnDateTimeMaxValue()
    {
        DateTime maxValue = DateTime.MaxValue;

        Mock<IDateTimeNowAddDays> dateTime = new Mock<IDateTimeNowAddDays>();

        dateTime.Setup(d => d.DateTimeMaxValue())
            .Returns(maxValue.Date);

        Assert.AreEqual(maxValue.Date, dateTime.Object.DateTimeMaxValue());
    }

    public void DiffMinValueAndMaxValuedateTime_MaxValueMinusMinValueDateTime_ReturnDiffMaxValueAndMinValueDateTome()
    {
        DateTime minValue = DateTime.MinValue;
        DateTime maxValue = DateTime.MaxValue;

        Mock<IDateTimeNowAddDays> dateTime = new Mock<IDateTimeNowAddDays>();

        dateTime.Setup(d => d.DaysDiffDateTimeMixValueAndMaxValue())
            .Returns(maxValue.Subtract(minValue).TotalDays);

        double totalDayDiffMinAndMaxDateTime = maxValue.Subtract(minValue).TotalDays;

        Assert.AreEqual(totalDayDiffMinAndMaxDateTime, dateTime.Object.DaysDiffDateTimeMixValueAndMaxValue());
    }
}