using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkHours
{
    class ScheduleRules
    {
        public enum DayType { weekday, weekend };
        public static DayType GetDayType(string day)
        {
            DayType dayType = new DayType();
            switch (day)
            {
                case "MO":
                case "TU":
                case "WE":
                case "TH":
                case "FR":
                    dayType = DayType.weekday;
                    break;
                case "SA":
                case "SU":
                    dayType = DayType.weekend;
                    break;
            }
            return dayType;
        }
    }
}
