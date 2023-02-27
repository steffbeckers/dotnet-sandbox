using System;

namespace Sandbox.TimeZones;

public class DateTimeOffsetTests
{
    [Fact]
    public void Test1()
    {
        DateTimeOffset dateTimeOffset1 = DateTimeOffset.UtcNow;

        Console.WriteLine(dateTimeOffset1.ToString());

        DateTimeOffset dateTimeOffset2 = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Today, "Romance Standard Time");

        Console.WriteLine(dateTimeOffset2.ToString());
    }
}
