using System;
using System.Collections.Generic;

namespace Google.Maps.WebServices.Tests.Data;

public class DirectionsTestData
{
    public static IEnumerable<object[]> GetDateTime()
    {
        yield return new object[] { new DateTime(2000, 1, 1, 1, 0, 0, DateTimeKind.Utc), "946688400" };
    }

    public static IEnumerable<object[]> GetDateTimeOffset()
    {
        yield return new object[] { new DateTimeOffset(2000, 1, 1, 1, 0, 0, TimeSpan.FromHours(-12)), "946731600" };
        yield return new object[] { new DateTimeOffset(2000, 1, 1, 1, 0, 0, TimeSpan.FromHours(-6)), "946710000" };
        yield return new object[] { new DateTimeOffset(2000, 1, 1, 1, 0, 0, TimeSpan.Zero), "946688400" };
        yield return new object[] { new DateTimeOffset(2000, 1, 1, 1, 0, 0, TimeSpan.FromHours(6)), "946666800" };
        yield return new object[] { new DateTimeOffset(2000, 1, 1, 1, 0, 0, TimeSpan.FromHours(12)), "946645200" };
    }
}