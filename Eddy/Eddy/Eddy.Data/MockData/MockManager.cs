using Eddy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eddy.Data.MockData
{
    public static class MockManager
    {
        public static List<Manager> list = new List<Manager>()
        {
            new Manager{ID = "1", FirstName="Roger", LastName="Selleck", CurrentlyEmployed=true, Email="mgr1@yahoo.com", IsManager= true, PhoneNumber="512555555", PlaceOfBusiness= MockBusiness.list.Find(b => b.Id == 1)},
            new Manager{ID = "2", FirstName="Sue", LastName="Green", CurrentlyEmployed=true, Email="mgr2@yahoo.com", IsManager= true, PhoneNumber="512555555", PlaceOfBusiness= MockBusiness.list.Find(b => b.Id == 1)},
            new Manager{ID = "3", FirstName="Jessica", LastName="Day", CurrentlyEmployed=false, Email="mgr3@yahoo.com", IsManager= true, PhoneNumber="512555555", PlaceOfBusiness= MockBusiness.list.Find(b => b.Id == 1)},
            new Manager{ID = "4", FirstName="James", LastName="Ford", CurrentlyEmployed=true, Email="mgr4@yahoo.com", IsManager= true, PhoneNumber="512555555", PlaceOfBusiness= MockBusiness.list.Find(b => b.Id == 2)}
        };
    }
}
