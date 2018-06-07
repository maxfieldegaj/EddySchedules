using Max.Data.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Max.Data.Seeding
{
    public static class DbInitializer
    {
        public static void Init(ApplicationUserDbContext appUserDbContext, MaxDbContext maxDbContext)
        {
            appUserDbContext.Database.Migrate();
            maxDbContext.Database.Migrate();

            if (!appUserDbContext.Roles.Any())
            {
                AddRoles(appUserDbContext);
            }
        }

        public static void AddRoles(ApplicationUserDbContext appUserDbContext)
        {
            string[] roles = new string[] { "Manager", "Employee" };

            foreach (var r in roles)
            {
                var newrole = new IdentityRole
                {
                    Name = r,
                    NormalizedName = r.ToUpper()
                };

                appUserDbContext.Roles.Add(newrole);
            }
            appUserDbContext.SaveChanges();
        }
    }
}
