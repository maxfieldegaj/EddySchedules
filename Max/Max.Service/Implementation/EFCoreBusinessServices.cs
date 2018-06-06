using Max.Data.Database;
using Max.Domain.Models;
using Max.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Max.Service.Implementation
{
    public class EFCoreBusinessServices : IBusinessServices
    {
        private readonly MaxDbContext _dbContext;

        public EFCoreBusinessServices(MaxDbContext dbContext)
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
            if(business == null)
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
