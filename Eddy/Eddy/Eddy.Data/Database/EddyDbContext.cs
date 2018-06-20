using Eddy.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eddy.Data.Database
{
    public class EddyDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shift> Schedules { get; set; }
        public DbSet<Message> SentMessages { get; set; }
        public DbSet<Message> ReceivedMessages { get; set; }
        public DbSet<Message> DeletedMessages { get; set; }

        public EddyDbContext(DbContextOptions<EddyDbContext> options)
            : base(options)
        {

        }
    }
}
