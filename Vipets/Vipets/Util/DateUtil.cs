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

    }
}
