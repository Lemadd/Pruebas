using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoWeb.util
{
    public static class DateUtil
    {

        public static DateTime EquivalentWeekDay(this DateTime dtOld)
        {
            int num = (int)dtOld.DayOfWeek;
            int num2 = (int)DateTime.Today.DayOfWeek;
            return DateTime.Today.AddDays(num - num2);
        }
    }
}