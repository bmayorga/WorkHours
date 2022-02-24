using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkHours
{
    class HourRate
    {
        public DateTime iniTime;
        public DateTime endTime;
        public ScheduleRules.DayType dayType;
        public float Rate;
    }
    class HourRates
    {
        public static List<HourRate> GetSchedule()
        {
            List<HourRate> list = new List<HourRate>();

            // Week days
            list.Add(new HourRate
            {
                dayType = ScheduleRules.DayType.weekday,
                iniTime = NewTime(0, 1),
                endTime = NewTime(9, 0),
                Rate = 25
            });
            list.Add(new HourRate
            {
                dayType = ScheduleRules.DayType.weekday,
                iniTime = NewTime(9, 1),
                endTime = NewTime(18, 0),
                Rate = 15
            });
            list.Add(new HourRate
            {
                dayType = ScheduleRules.DayType.weekday,
                iniTime = NewTime(18, 1),
                endTime = NewTime(0, 0),
                Rate = 20
            });

            //Weekend
            list.Add(new HourRate
            {
                dayType = ScheduleRules.DayType.weekend,
                iniTime = NewTime(0, 1),
                endTime = NewTime(9, 0),
                Rate = 30
            });
            list.Add(new HourRate
            {
                dayType = ScheduleRules.DayType.weekend,
                iniTime = NewTime(9, 1),
                endTime = NewTime(18, 0),
                Rate = 20
            });
            list.Add(new HourRate
            {
                dayType = ScheduleRules.DayType.weekend,
                iniTime = NewTime(18, 1),
                endTime = NewTime(0, 0),
                Rate = 25
            });
            return list;
        }
        public static DateTime NewTime(int hour, int min)
        {
            return new DateTime(1, 1, 1, hour, min, 0);
        }
    }
}
