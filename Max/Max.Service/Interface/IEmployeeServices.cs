using Eddy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eddy.Service.Interface
{
    public interface IEmployeeServices
    {
        // Read
        Employee GetSingleEmployeeById(string id);
        List<Employee> GetEmployeesByCompanyId(int id);

        // Create
        Employee CreateEmployee(Employee newEmployee);

        // Update
        Employee UpdateEmployee(Employee updatedEmployee);
        // Delete
        bool DeleteEmployee(string id);
    }
}
