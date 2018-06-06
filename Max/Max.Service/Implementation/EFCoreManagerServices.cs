using Max.Data.Database;
using Max.Domain.Models;
using Max.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Max.Service.Implementation
{
    public class EFCoreManagerServices : IManagerServices
    {
        private readonly MaxDbContext _dbContext;

        public EFCoreManagerServices(MaxDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public Manager CreateManager(Manager newManager)
        {
            _dbContext.Managers.Add(newManager);
            _dbContext.SaveChanges();

            return newManager;
        }

        public bool DeleteManager(string id)
        {
            var manager = _dbContext.Managers.Find(id);

            _dbContext.Remove(manager);
            _dbContext.SaveChanges();

            if (manager == null)
            {
                return true;
            }
            else return false;
        }

        public List<Manager> GetManagersByBusinessId(int id) => _dbContext.Managers
            .Where(m => m.PlaceOfBusiness.Id == id).ToList();

        public Manager GetSingleManagerById(string id) => _dbContext.Managers.Find(id);

        public Manager UpdateManager(Manager updatedManager)
        {
            var manager = _dbContext.Managers.Update(updatedManager);
            _dbContext.SaveChanges();

            return manager.Entity;
        }
    }
}
