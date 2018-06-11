using Eddy.Data.Database;
using Eddy.Domain.Models;
using Eddy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eddy.Services.Implementations
{
    public class EFCoreBusinessServices : IBusinessServices
    {
        private readonly EddyDbContext _dbContext;

        public EFCoreBusinessServices(EddyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Business CreateBusiness(Business newBusiness)
        {
            _dbContext.Businesses.Add(newBusiness);
            _dbContext.SaveChanges();

            return newBusiness;
        }

        public bool DeleteBusiness(int id)
        {
            var business = _dbContext.Businesses.Find(id);

            _dbContext.Businesses.Remove(business);
            _dbContext.SaveChanges();
            if (business == null)
            {
                return true;
            }
            return false;
        }

        public List<Business> GetAllBusinesses() => _dbContext.Businesses.ToList();

        public Business GetSingleBusinessById(int id) => _dbContext.Businesses.Find(id);

        public Business UpdateBusiness(Business updatedBusiness)
        {
            var business = _dbContext.Businesses.Update(updatedBusiness);
            _dbContext.SaveChanges();

            return business.Entity;
        }
    }
}

