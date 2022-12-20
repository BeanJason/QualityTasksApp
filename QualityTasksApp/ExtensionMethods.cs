using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QualityTasksApp
{
    //https://markb.uk/csharp-datetime-get-first-last-day-of-week-or-month.html
    //https://stackoverflow.com/questions/38039/how-can-i-get-the-datetime-for-the-start-of-the-week

    //extension methods for DateTime used to get the start of the week and end of the week
    public static class ExtensionMethods
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        public static DateTime LastDayOfWeek(this DateTime dt)
        {
            return dt.StartOfWeek(DayOfWeek.Monday).AddDays(6);
        }

        public static DateTime FirstDayOfMonth(this DateTime dt) =>
        new DateTime(dt.Year, dt.Month, 1);

        public static DateTime LastDayOfMonth(this DateTime dt) =>
            dt.FirstDayOfMonth().AddMonths(1).AddDays(-1);
    }

    
}
