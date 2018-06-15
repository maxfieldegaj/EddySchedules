using System;
using System.Collections.Generic;
using System.Text;

namespace Eddy.Domain.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool CurrentlyEmployed { get; set; }
        public List<Shift> Schedule { get; set; }
        public bool IsManager { get; set; }
        public DateTime RequestedOff { get; set; }

        public Business PlaceOfBusiness { get; set; }
        public List<Message> Messages { get; set; }
    }
}
