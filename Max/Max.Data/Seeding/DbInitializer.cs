using Max.Data.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Max.Data.Seeding
{
    public static class DbInitializer
    {
        public static void Init(ApplicationUserDbContext appUserDbContext, MaxDbContext maxDbContext)
        {
            appUserDbContext.Database.Migrate();
            maxDbContext.Database.Migrate();

            
        }
    }
}
