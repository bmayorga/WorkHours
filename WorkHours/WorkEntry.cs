using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkHours
{
    public class WorkEntry
    {
        public string Name { get; set; }
        public List<WorkInterval> Intervals;
    }
}