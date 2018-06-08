using Eddy.Domain.Models;
using System;
using System.Collections.Generic;

namespace Eddy.Domain.Models
{
    public class Business
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Business> AffiliatedBusinesses { get; set; }
        public string PhoneNumber { get; set; }
        public List<Shift> Schedule { get; set; }
        public List<Employee> Staff { get; set; }
        public List<Manager> Managers { get; set; }
    }
}
