using Eddy.Data.Database;
using Eddy.Domain.Models;
using Eddy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eddy.Services.Implementations
{
    public class EFCoreEmployeeServices : IEmployeeServices
    {
        private readonly EddyDbContext _dbContext;

        public EFCoreEmployeeServices(EddyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Employee CreateEmployee(Employee newEmployee)
        {
            _dbContext.Employees.Add(newEmployee);
            _dbContext.SaveChanges();

            return newEmployee;
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _dbContext.Employees.Find(id);

            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();

            if (employee == null)
            {
                return true;
            }
            return false;
        }

        public List<Employee> GetEmployeesByCompanyId(int id) => _dbContext.Employees
            .Where(e => e.PlaceOfBusiness.Id == id).ToList();

        public Employee GetSingleEmployeeById(int id) => _dbContext.Employees.Find(id);

        public Employee UpdateEmployee(Employee updatedEmployee)
        {
            var employee = _dbContext.Employees.Update(updatedEmployee);
            _dbContext.SaveChanges();

            return employee.Entity;
        }
    }
}

