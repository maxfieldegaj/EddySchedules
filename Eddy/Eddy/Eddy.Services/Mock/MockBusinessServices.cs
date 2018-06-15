using Eddy.Data.MockData;
using Eddy.Domain.Models;
using Eddy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eddy.Services.Mock
{
    public class MockBusinessServices : IBusinessServices
    {
        private List<Business> _context;

        public MockBusinessServices()
        {
            _context = MockBusiness.list;
        }

        public Business CreateBusiness(Business newBusiness)
        {
            int largestId = _context.OrderByDescending(b => b.Id).FirstOrDefault().Id;

            newBusiness.Id = largestId + 1;
            _context.Add(newBusiness);

            return newBusiness;
        }

        public bool DeleteBusiness(int id)
        {
            Business toBeDeleted = GetSingleBusinessById(id);
            _context.Remove(toBeDeleted);

            toBeDeleted = GetSingleBusinessById(id);
            if(toBeDeleted == null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Business GetSingleBusinessById(int id) => _context.SingleOrDefault(b => b.Id == id);

        public Business UpdateBusiness(Business updatedBusiness)
        {
            Business oldBiz = GetSingleBusinessById(updatedBusiness.Id);

            _context.Remove(oldBiz);
            _context.Add(updatedBusiness);

            return updatedBusiness;
        }
    }
}
