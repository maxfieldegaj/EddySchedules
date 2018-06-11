using Eddy.Data.Database;
using Eddy.Domain.Models;
using Eddy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eddy.Services.Implementations
{
    public class EFCoreShiftServices : IShiftServices
    {
        private readonly EddyDbContext _dbContext;

        public EFCoreShiftServices(EddyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Shift CreateShift(Shift newShift)
        {
            _dbContext.Schedules.Add(newShift);
            _dbContext.SaveChanges();

            return newShift;
        }

        public bool DeleteShift(int id)
        {
            var shift = _dbContext.Schedules.Find(id);

            _dbContext.Schedules.Remove(shift);
            _dbContext.SaveChanges();

            if (shift == null)
            {
                return true;
            }

            return false;
        }

        public List<Shift> GetScheduleByEmployeeId(string id)
        {
            return _dbContext.Schedules.Where(s => s.EmployeeID == id).ToList();
        }

        public Shift GetSingleShiftById(int id) => _dbContext.Schedules.Find(id);

        public Shift UpdateShift(Shift updatedShift)
        {
            var shift = _dbContext.Schedules.Update(updatedShift);
            _dbContext.SaveChanges();

            return shift.Entity;
        }
    }
}
