using Max.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Max.Data.Database
{
    public class MaxDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shift> Schedules { get; set; }

        public MaxDbContext(DbContextOptions<MaxDbContext> options)
            : base(options)
        {

        }
    }
}
