using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SecurityServer.Data;
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
        }
    }
}
