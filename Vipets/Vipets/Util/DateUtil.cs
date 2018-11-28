using System;
using System.Collections.Generic;
using System.Text;

namespace Vipets.Util
{
    class DateUtil
    {
        public static DateTime NullDateTime { get; set; }

        public static bool isSameDate(DateTime a, DateTime b)
        {
            if (a.Date.CompareTo(b.Date) == 0) return true;
            else return false;
        }

        public static string GetStringToDateTime(DateTime dt)
        {
            return String.Format("{0:dd/MM/yyyy - HH:mm}", dt);
        }

        public static DateTime GetFormatRest(DateTime dt)
        {
            string str = String.Format("{0:yyyy-MM-dd HH:mm:ss}", dt);
            DateTime myDate = DateTime.ParseExact(str, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            return myDate;
        }

        public static DateTime GetFormatDateRest(DateTime dt)
        {
            string str = String.Format("{0:yyyy-MM-dd}", dt);
            DateTime myDate = DateTime.ParseExact(str, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            return myDate;
        }

        public static TimeSpan CalculateTime(TimeSpan current, int hours, int minutes)
        {
            try
            {
                int newHour = current.Hours + hours;
                int newMinute = current.Minutes + minutes;
                TimeSpan time = new TimeSpan(newHour, newMinute, current.Seconds);
                return time;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error to calculate time: '{0}'", e);
            }
            return current;
        }

    }
}
