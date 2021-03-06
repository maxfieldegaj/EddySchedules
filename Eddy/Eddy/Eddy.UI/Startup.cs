﻿using Eddy.Data.Database;
using Eddy.Domain.Models;
using Eddy.Services.Implementations;
using Eddy.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eddy.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IBusinessServices, EFCoreBusinessServices>();
            services.AddScoped<IEmployeeServices, EFCoreEmployeeServices>();
            services.AddScoped<IManagerServices, EFCoreManagerServices>();
            services.AddScoped<IShiftServices, EFCoreShiftServices>();
            services.AddScoped<IMessageServices, EFCoreMessageServices>();


            services.AddDbContext<ApplicationUserDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("AppIdentityConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationUserDbContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<EddyDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("EddyConnection")));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
        }
    }
}
