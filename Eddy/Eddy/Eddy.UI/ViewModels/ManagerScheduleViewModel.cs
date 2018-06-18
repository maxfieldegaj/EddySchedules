using Eddy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eddy.UI.ViewModels
{
    public class ManagerScheduleViewModel
    {
        public ApplicationUser Manager { get; set; }
        public List<Shift> VisibleSchedule { get; set; }
        public List<Shift> AllEmployeeSchedule { get; set; }
        public List<Shift> MySchedule { get; set; }
        public List<Person> Staff { get; set; }
        public List<Employee> EmpStaff { get; set; }
        public List<Manager> MgrStaff { get; set; }
        
    }
}
