using Eddy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eddy.Data.MockData
{
    public static class MockShift
    {
        public static List<Shift> list = new List<Shift>()
        {
            new Shift{ID=1, Assigned=true, EmployeeID=1, StartTime= new DateTime(2018,01,01,08,00,00), EndTime= new DateTime(2018,01,01,16,00,00), PlaceOfBusiness= MockBusiness.list.Find(b => b.Id == 1)},
            new Shift{ID=2, Assigned=true, ManagerShift=true, EmployeeID=1, StartTime= new DateTime(2018,01,01,08,00,00), EndTime= new DateTime(2018,01,01,16,00,00), PlaceOfBusiness= MockBusiness.list.Find(b => b.Id == 1)},
            new Shift{ID=3, Assigned=false, StartTime= new DateTime(2018,01,01,16,00,00), EndTime= new DateTime(2018,01,02,01,00,00), PlaceOfBusiness= MockBusiness.list.Find(b => b.Id == 1)}
        };
    }
}
