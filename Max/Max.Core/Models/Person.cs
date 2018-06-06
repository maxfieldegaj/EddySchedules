using System;
using System.Collections.Generic;
using System.Text;

namespace Max.Domain.Models
{
    public class Person
    {
        public string ID { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CurrentlyEmployed { get; set; }
        public List<Shift> Schedule { get; set; }
        public bool IsManager { get; set; }

        public Business PlaceOfBusiness { get; set; }
    }
}
