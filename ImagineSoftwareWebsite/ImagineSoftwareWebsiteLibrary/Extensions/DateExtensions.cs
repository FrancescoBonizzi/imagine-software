using System;

namespace ImagineSoftwareWebsiteLibrary.Extensions
{
    public static class DateExtensions
    {
        private static readonly TimeZoneInfo _italianTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");

        public static string ToItalianTimestampString(this DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.ToItalianTimestamp()
              .ToString("dd/MM/yyyy HH:mm");
        }

        public static string ToItalianTimestampStringFromUTC(this DateTime utcTime)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(utcTime, _italianTimeZoneInfo)
              .ToString("dd/MM/yyyy HH:mm");
        }

        public static string ToItalianTimestampStringOnlyDate(this DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.ToItalianTimestamp()
              .ToString("dd/MM/yyyy");
        }

        public static DateTimeOffset ToItalianTimestampOnlyDateWithOffset(this DateTimeOffset dateTimeOffset)
        {
            DateTime onlyDateItalianTimestamp = dateTimeOffset.ToItalianTimestamp();
            return new DateTimeOffset(
                onlyDateItalianTimestamp.Date,
                _italianTimeZoneInfo.GetUtcOffset(DateTimeOffset.Now));
        }

        public static string ToItalianTimestampStringOnlyTime(this DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.ToItalianTimestamp()
              .ToString("HH:mm");
        }

        public static DateTime ToItalianTimestamp(this DateTimeOffset dateTimeOffset)
        {
            DateTime utc = dateTimeOffset.ToUniversalTime().DateTime;
            return TimeZoneInfo.ConvertTimeFromUtc(utc, _italianTimeZoneInfo);
        }

        public static DateTimeOffset ToItalianTimestampWithOffset(this DateTimeOffset dateTimeOffset)
        {
            DateTime utc = dateTimeOffset.ToUniversalTime().DateTime;

            return new DateTimeOffset(
                TimeZoneInfo.ConvertTimeFromUtc(utc, _italianTimeZoneInfo),
                _italianTimeZoneInfo.GetUtcOffset(DateTimeOffset.Now));
        }

        public static DateTimeOffset FromItalianDate(this DateTime date)
            => new DateTimeOffset(date, _italianTimeZoneInfo.GetUtcOffset(DateTimeOffset.Now));
    }
}
