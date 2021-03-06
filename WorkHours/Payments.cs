using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkHours
{
    public class Payments
    {
        string filePath = "C:\\inputfiles\\input.txt";
        public void Process()
        {
            // Parse input text file to create work entries
            Console.WriteLine("Processing input file and calculating payments...");
            StreamReader reader = File.OpenText(filePath);
            string textLine;
            while ((textLine = reader.ReadLine()) != null)
            {
                WorkEntry workEntry = ParseNewEntry(textLine);

                // Calculate payments from work entries
                double amount = CalculatePayment(workEntry);
                Console.WriteLine($"The amount to pay {workEntry.Name} is: {amount.ToString("0.00")} USD");
            }
        }

        public static WorkEntry ParseNewEntry(string line)
        {
            WorkEntry workEntry = new WorkEntry();

            // Get name
            string[] sections = line.Split('=');
            workEntry.Name = sections[0];

            workEntry.Intervals = new List<WorkInterval>();
            string[] entries = sections[1].Split(',');
            // Get work entries
            foreach (string entry in entries)
            {
                // Week day
                string day = entry.Substring(0, 2); // 2 first chars
                string[] hours = entry.Substring(2).Split('-'); // from 3rd char 

                // Initial hour
                int hour = Convert.ToInt32(hours[0].Substring(0, 2));
                int min = Convert.ToInt32(hours[0].Substring(3, 2));
                DateTime iniTime = new DateTime(1, 1, 1, hour, min, 0);

                // End hour
                hour = Convert.ToInt32(hours[1].Substring(0, 2));
                min = Convert.ToInt32(hours[1].Substring(3, 2));
                DateTime endTime = new DateTime(1, 1, 1, hour, min, 0);

                workEntry.Intervals.Add(new WorkInterval { Day = day, IniTime = iniTime, EndTime = endTime });
            }

            return workEntry;
        }
        public static double CalculatePayment(WorkEntry workEntry)
        {
            double value = 0;
            // Get schedule and hour rates
            List<HourRate> schedule = HourRate.GetSchedule();

            // Intervals fronm input file
            foreach (WorkInterval interval in workEntry.Intervals)
            {
                // Pre defined hour rates
                foreach (HourRate hourRate in schedule)
                {
                    // Same day type?
                    if (interval.GetDayType() == hourRate.IntervalDayType)
                    {
                        // Is it not out of boundaries? Calculate the portion the interval shares with the current hour rate
                        if (!(interval.IniTime > hourRate.EndTime || interval.EndTime < hourRate.IniTime))
                        {
                            DateTime earlierEnd = interval.EndTime < hourRate.EndTime ? interval.EndTime : hourRate.EndTime;
                            DateTime laterStart = interval.IniTime > hourRate.IniTime ? interval.IniTime : hourRate.IniTime;
                            double minutes = (earlierEnd - laterStart).TotalMinutes;
                            value += (minutes / 60.0) * hourRate.Rate;
                        }
                    }
                }
            }
            return value;
        }
    }
}
