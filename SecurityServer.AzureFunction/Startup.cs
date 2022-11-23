using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SecurityServer.Data;
using SecurityServer.Data.UnitOfWork;
using SecurityServer.Data.UnitOfWork.Interface;
using SecurityServer.Service;
using SecurityServer.Service.Interface;
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
            string connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
            builder.Services.AddDbContext<SecurityServerDbContext>(
              options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));
            builder.Services.AddScoped<IApplicationUnitOfWork, ApplicationUnitOfWork>();
            builder.Services.AddTransient(typeof(IApplicationService), typeof(ApplicationService));
        }
    }
}
