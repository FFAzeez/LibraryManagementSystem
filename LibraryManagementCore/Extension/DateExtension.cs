using System;

namespace LibraryManagementCore.Extentions
{
    public static class DateExtension
    {
        public static DateTime AddWorkingDays(this DateTime date, int daysToAdd)
        {
            while (daysToAdd > 0)
            {
                date = date.AddDays(1);
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    daysToAdd--;
                }
            }

            return date;
        }
    }
}
