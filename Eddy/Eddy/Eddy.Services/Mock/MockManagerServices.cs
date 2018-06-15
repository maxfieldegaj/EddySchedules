using Eddy.Data.MockData;
using Eddy.Domain.Models;
using Eddy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eddy.Services.Mock
{
    public class MockManagerServices : IManagerServices
    {

        private List<Manager> _context;

        public MockManagerServices()
        {
            _context = MockManager.list;
        }

        public Manager CreateManager(Manager newManager)
        {
            int largestId = _context.OrderByDescending(e => e.ID).FirstOrDefault().ID;

            newManager.ID = largestId + 1;
            _context.Add(newManager);

            return newManager;
        }

        public bool DeleteManager(int id)
        {
            Manager toBeDeleted = GetSingleManagerById(id);
            _context.Remove(toBeDeleted);

            toBeDeleted = GetSingleManagerById(id);
            if (toBeDeleted == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Manager> GetManagersByBusinessId(int id) => _context.Where(b => b.PlaceOfBusiness.Id == id).ToList();

        public Manager GetSingleManagerById(int id) => _context.Find(b => b.ID == id);

        public Manager UpdateManager(Manager updatedManager)
        {
            Manager oldEmp = GetSingleManagerById(updatedManager.ID);

            _context.Remove(oldEmp);
            _context.Add(updatedManager);

            return updatedManager;
        }
    }
    
}
