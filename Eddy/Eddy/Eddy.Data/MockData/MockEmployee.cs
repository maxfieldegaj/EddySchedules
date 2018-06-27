using Eddy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eddy.Data.MockData
{
    public static class MockEmployee
    {
        public static List<Employee> list = new List<Employee>()
        {
            new Employee{ID = "1", FirstName="Tom", LastName="Selleck",CurrentlyEmployed=true, Email="emp1@yahoo.com", IsManager= false, PhoneNumber="512555555", PlaceOfBusiness= MockBusiness.list.Find(b => b.Id == 1)},
            new Employee{ID = "2", FirstName="Sally", LastName="Lou", CurrentlyEmployed=true, Email="emp2@yahoo.com", IsManager= false, PhoneNumber="512555555", PlaceOfBusiness= MockBusiness.list.Find(b => b.Id == 1)},
            new Employee{ID = "3", FirstName="Frank", LastName="Selleck", CurrentlyEmployed=false, Email="emp3@yahoo.com", IsManager= false, PhoneNumber="512555555", PlaceOfBusiness= MockBusiness.list.Find(b => b.Id == 1)},
            new Employee{ID = "4", FirstName="James", LastName="Dean", CurrentlyEmployed=true, Email="emp4@yahoo.com", IsManager= false, PhoneNumber="512555555", PlaceOfBusiness= MockBusiness.list.Find(b => b.Id == 2)}
        };
    }
}
