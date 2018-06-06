﻿using Max.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Max.Service.Interface
{
    public interface IShiftServices
    {
        // Read
        Shift GetSingleShiftById(int id);
        List<Shift> GetScheduleByEmployeeId(string id);

        // Create
        Shift CreateShift(Shift newShift);

        // Update
        Shift UpdateShift(Shift updatedShift);
        // Delete
        bool DeleteShift(int id);
    }
}
