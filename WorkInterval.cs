using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkHours
{
    class WorkInterval
    {
        public string Day;
        public DateTime IniTime;
        public DateTime EndTime;
        public DayType GetDayType()
        {
            // Is it weekday or weekend?
            DayType dayType = new DayType();
            switch (Day)
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