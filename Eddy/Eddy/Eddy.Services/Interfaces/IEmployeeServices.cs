using Eddy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eddy.Services.Interfaces
{
    public interface IEmployeeServices
    {
        // Read
        Employee GetSingleEmployeeById(int id);
        List<Employee> GetEmployeesByCompanyId(int id);

        // Create
        Employee CreateEmployee(Employee newEmployee);

        // Update
        Employee UpdateEmployee(Employee updatedEmployee);
        // Delete
        bool DeleteEmployee(int id);
    }
}
