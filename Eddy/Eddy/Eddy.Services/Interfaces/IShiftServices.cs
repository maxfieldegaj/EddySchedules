using Eddy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eddy.Services.Interfaces
{
    public interface IShiftServices
    {
        // Read
        Shift GetSingleShiftById(int id);
        List<Shift> GetScheduleByEmployeeId(int id);

        // Create
        Shift CreateShift(Shift newShift);

        // Update
        Shift UpdateShift(Shift updatedShift);
        // Delete
        bool DeleteShift(int id);
    }
}
