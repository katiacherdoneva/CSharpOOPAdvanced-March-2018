using System;

public interface IDateTimeNowAddDays
{
    DateTime DayMiddleOfTheMonth(DateTime dateTimeNow);

    int NextMonth(DateTime dateTimeNow);

    int AddNegativeDay(DateTime dateTimeNow);

    string AddDayLeapYear(DateTime dateTimeNow);

    DateTime NextDayLeapYear(DateTime dateTimeNow);

    DateTime DateTimeMinValue();

    DateTime DateTimeMaxValue();

    double DaysDiffDateTimeMixValueAndMaxValue();
}

