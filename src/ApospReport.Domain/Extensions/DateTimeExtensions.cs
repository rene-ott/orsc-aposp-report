using System;

namespace ApospReport.Domain.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime TruncateMillis(this DateTime date)
        {
            return new(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, DateTimeKind.Utc);
        }
    }
}
