using System;
using System.Collections.Generic;
using System.Text;

namespace Eddy.Domain.Models
{
    public class Shift
    {
        public int ID { get; set; }
        public string EmployeeID {  get; set;  }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool TradePending { get; set; }
        public bool Assigned { get; set; }
        public List<Employee> RequestedOffEmployees { get; set; }
        public List<Manager> RequestedOffManager { get; set; }

        public Business PlaceOfBusiness { get; set; }
    }
}
