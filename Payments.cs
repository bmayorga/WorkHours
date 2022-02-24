using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkHours
{
    class Payments
    {
        string filePath = "c:\\inputfiles\\input.txt";
        public void Process()
        {
            string line;
            List<WorkEntry> workEntries = new List<WorkEntry>();

            StreamReader reader = File.OpenText(filePath);
            while ((line = reader.ReadLine()) != null)
            {
                workEntries.Add(Parse(line));
            }

            foreach (WorkEntry workEntry in workEntries)
            {
                float amount = Calculate(workEntry);
                Console.WriteLine($"The amount to pay {workEntry.Name} is: {amount.ToString("0.00")} USD");
            }
        }

        private float Calculate(WorkEntry workEntry)
        {
            float amount = 0;

            return amount;
        }

        private WorkEntry Parse(string line)
        {
            string[] sections = line.Split('=');
            string name = sections[0];

            WorkEntry workEntry = new WorkEntry();
            workEntry.Name = name;
            workEntry.Intervals = new List<WorkInterval>();

            string[] entries = sections[1].Split(',');
            foreach (string entry in entries)
            {
                string day = entry.Substring(0, 2);
                string period = entry.Substring(2);
                string[] hours = period.Split('-');

                int hour = Convert.ToInt32(hours[0].Substring(0, 2));
                int min = Convert.ToInt32(hours[0].Substring(3, 2));
                DateTime iniTime = new DateTime(1, 1, 1, hour, min, 0);

                hour = Convert.ToInt32(hours[1].Substring(0, 2));
                min = Convert.ToInt32(hours[1].Substring(3, 2));
                DateTime endTime = new DateTime(1, 1, 1, hour, min, 0);

                TimeSpan timespan = endTime - iniTime;

                WorkInterval workInterval = new WorkInterval();
                workInterval.Day = day;
                workInterval.IniTime = iniTime;
                workInterval.EndTime = endTime;
                workInterval.Interval = timespan;
                workEntry.Intervals.Add(workInterval);
            }

            return workEntry;
        }
    }
}
