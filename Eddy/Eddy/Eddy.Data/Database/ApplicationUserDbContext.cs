using Eddy.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eddy.Data.Database
{
    public class ApplicationUserDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationUserDbContext(DbContextOptions<ApplicationUserDbContext> options)
            : base(options)
        {
            if (!Roles.Any())
            {
                string[] roles = new string[] { "Manager", "Employee" };

                foreach (var r in roles)
                {
                    var newrole = new IdentityRole
                    {
                        Name = r,
                        NormalizedName = r.ToUpper()
                    };

                    Roles.Add(newrole);
                }
                SaveChanges();
            }

        }
    }
}
