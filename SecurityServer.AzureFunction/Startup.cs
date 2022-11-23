﻿using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SecurityServer.Data;
using SecurityServer.Data.Repository;
using SecurityServer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: FunctionsStartup(typeof(SecurityServer.AzureFunction.StartUp))]

namespace SecurityServer.AzureFunction
{
    public class StartUp : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string connectionString = "Server=bdd-p2-g5.database.windows.net;Initial Catalog=BDD-DIIAGE-P2-G5;Persist Security Info=False;User ID=diiage2bg;Password=Diiage_G5_P2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            builder.Services.AddDbContext<SecurityServerDbContext>(
              options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));
            builder.Services.AddScoped<UnitOfWork>();
            // scope des services
            builder.Services.AddScoped<ApplicationService>();
            builder.Services.AddScoped<ClaimService>();
            builder.Services.AddScoped<RoleService>();
            builder.Services.AddScoped<UserService>();

            // scope des repository
            builder.Services.AddScoped<ApplicationRepository>();
            builder.Services.AddScoped<ClaimRepository>();
            builder.Services.AddScoped<RoleRepository>();
            builder.Services.AddScoped<UserRepository>();
        }

       
    }
}
