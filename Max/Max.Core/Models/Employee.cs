﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Eddy.Domain.Models
{
    public class Employee : Person
    {
        public DateTime RequestedOff { get; set; }
    }
}
