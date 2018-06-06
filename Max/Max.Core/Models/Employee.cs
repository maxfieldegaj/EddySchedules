using System;
using System.Collections.Generic;
using System.Text;

namespace Max.Domain.Models
{
    public class Employee : Person
    {
        public int NoShows { get; set; }
        public int WeeklyPerformance { get; set; }
        public List<int> AveragePerformance { get; set; }
        public List<DateTime> RequestedOff { get; set; }
    }
}
