using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkHours
{
    public enum DayType { weekday, weekend };
    class HourRate
    {
        public DateTime IniTime;
        public DateTime EndTime;
        public DayType IntervalDayType;
        public double Rate;

        public static List<HourRate> GetSchedule()
        {
            List<HourRate> list = new List<HourRate>();
            // Week days
            list.Add(NewHourRate(DayType.weekday, 0, 1, 9, 0, 25));
            list.Add(NewHourRate(DayType.weekday, 9, 1, 18, 0, 15));
            list.Add(NewHourRate(DayType.weekday, 18, 1, 0, 0, 20));
            //Weekend
            list.Add(NewHourRate(DayType.weekend, 0, 1, 9, 0, 30));
            list.Add(NewHourRate(DayType.weekend, 9, 1, 18, 0, 20));
            list.Add(NewHourRate(DayType.weekend, 18, 1, 0, 0, 25));
            return list;
        }
        private static HourRate NewHourRate(DayType dayType, int iniHour, int iniMin, int endHour, int endMin, double rate)
        {
            // 00:00 really means the end of the day?
            // if so, we set end time as 00:00 of next day (day = 2)
            // to be chronologically correct
            HourRate hourRate = new HourRate
            {
                IntervalDayType = dayType,
                IniTime = NewDateTime(iniHour, iniMin),
                EndTime = (endHour == 0 && endMin == 0) ? NewDateTime(endHour, endMin, 2) : NewDateTime(endHour, endMin),
                Rate = rate
            };
            return hourRate;
        }
        private static DateTime NewDateTime(int hour, int min, int day = 1)
        {
            // We create new DateTimes with year=1, month=1, day=1, by default
            return new DateTime(1, 1, day, hour, min, 0);
        }
    }
}
