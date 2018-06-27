using Eddy.Data.MockData;
using Eddy.Domain.Models;
using Eddy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eddy.Services.Mock
{
    public class MockEmployeeServices : IEmployeeServices
    {
        private List<Employee> _context;

        public MockEmployeeServices()
        {
            _context = MockEmployee.list;
        }

        public Employee CreateEmployee(Employee newEmployee)
        {
            
            _context.Add(newEmployee);

            return newEmployee;
        }

        public bool DeleteEmployee(string id)
        {
            Employee toBeDeleted = GetSingleEmployeeById(id);
            _context.Remove(toBeDeleted);

            toBeDeleted = GetSingleEmployeeById(id);
            if (toBeDeleted == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Employee> GetEmployeesByCompanyId(int id) => _context.Where(b => b.PlaceOfBusiness.Id == id).ToList();

        public Employee GetSingleEmployeeById(string id) => _context.Find(b => b.ID == id);

        public Employee UpdateEmployee(Employee updatedEmployee)
        {
            Employee oldEmp = GetSingleEmployeeById(updatedEmployee.ID);

            _context.Remove(oldEmp);
            _context.Add(updatedEmployee);

            return updatedEmployee;
        }
    }
}
