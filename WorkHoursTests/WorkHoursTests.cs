using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkHours;

namespace WorkHoursTests
{
    [TestClass]
    public class WorkHoursTests
    {
        [TestMethod]
        public void ParseNewEntry()
        {
            WorkEntry expected = weSample();

            string line = "JUAN=SU06:00-11:00,FR16:00-22:00";
            WorkEntry actual = Payments.ParseNewEntry(line);

            var expectedJ = JsonConvert.SerializeObject(expected);
            var actualJ = JsonConvert.SerializeObject(actual);
            Assert.AreEqual(expectedJ, actualJ);
        }
        [TestMethod]
        public void Calculate()
        {
            double expected = 239.33;
            double actual = Math.Round(Payments.CalculatePayment(weSample()),2);

            Assert.AreEqual(expected, actual);
        }
        WorkEntry weSample()
        {
            WorkEntry sample = new WorkEntry();
            sample.Name = "JUAN";
            sample.Intervals = new List<WorkInterval>();
            sample.Intervals.Add(new WorkInterval { Day = "SU", IniTime = new DateTime(1, 1, 1, 6, 0, 0), EndTime = new DateTime(1, 1, 1, 11, 0, 0) });
            sample.Intervals.Add(new WorkInterval { Day = "FR", IniTime = new DateTime(1, 1, 1, 16, 0, 0), EndTime = new DateTime(1, 1, 1, 22, 0, 0) });
            return sample;
        }
    }
}
