using System;
using System.Collections.Generic;
using System.Text;

namespace Max.Domain.Models
{
    public class Manager : Person
    {
        public List<DateTime> RequestedOff { get; set; }

    }
}
