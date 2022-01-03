using System;

namespace Base.Helpers.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsValidDate(this DateTime? date, int tolerance = 100)
        {
            if (date == null || date.Value.Date <= DateTime.MinValue.Date.AddDays(tolerance) || date.Value.Date >= DateTime.MaxValue.Date.AddDays(-tolerance))
            {
                return false;
            }

            return true;
        }

        public static bool IsValidDate(this DateTime date, int tolerance = 100)
        {
            if (date == null || date.Date <= DateTime.MinValue.Date.AddDays(tolerance) || date.Date >= DateTime.MaxValue.Date.AddDays(-tolerance))
            {
                return false;
            }

            return true;
        }
    }
}