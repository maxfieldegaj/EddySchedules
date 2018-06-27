using Eddy.Data.MockData;
using Eddy.Domain.Models;
using Eddy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eddy.Services.Mock
{
    public class MockShiftServices : IShiftServices
    {
        private List<Shift> _context;

        public MockShiftServices()
        {
            _context = MockShift.list;
        }

        public Shift CreateShift(Shift newShift)
        {
            int largestId = _context.OrderByDescending(s => s.ID).FirstOrDefault().ID;

            newShift.ID = largestId + 1;
            _context.Add(newShift);

            return newShift;
        }

        public bool DeleteShift(int id)
        {
            Shift toBeDeleted = GetSingleShiftById(id);
            _context.Remove(toBeDeleted);

            toBeDeleted = GetSingleShiftById(id);
            if (toBeDeleted == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Shift> GetAllShiftsByBusinessId(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Shift> GetScheduleByEmployeeId(string id) => _context.Where(s => s.AssignedTo.ID == id).ToList();

        public Shift GetSingleShiftById(int id) => _context.Find(s => s.ID == id);

        public Shift UpdateShift(Shift updatedShift)
        {
            Shift oldShift = GetSingleShiftById(updatedShift.ID);

            _context.Remove(oldShift);
            _context.Add(updatedShift);

            return updatedShift;
        }
    }
}
