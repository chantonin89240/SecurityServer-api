using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecurityServer.Data;
using SecurityServer.Data.Context;
using SecurityServer.Data.Repository;
using SecurityServer.Data.Repository.Interface;
using SecurityServer.Service;
using SecurityServer.Service.Interface;
using System.IO;

[assembly: FunctionsStartup(typeof(SecurityServer.AzureFunction.StartUp))]
namespace SecurityServer.AzureFunction
{
    public class StartUp : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("local.setting.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables()
               .Build();


            string connectionString = "Server=securityserverbdd.database.windows.net;Initial Catalog=securityserverbdd;Persist Security Info=False;User ID=DiiageG5test;Password=6ix9ine6ix9ine!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; //config.GetConnectionStringOrSetting("SqlConnectionString");
            builder.Services.AddDbContext<SecurityServerDbContext>(
              options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));
            builder.Services.AddScoped<IUnitOfWork<SecurityServerDbContext>, UnitOfWork<SecurityServerDbContext>>();

            // scope des services
            builder.Services.AddScoped<IApplicationService, ApplicationService>();
            builder.Services.AddScoped<ISalt,Salt>();
            builder.Services.AddScoped<ClaimService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IUserService, UserService >();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

            // scope des repository
            builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
            builder.Services.AddScoped<ClaimRepository>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICodeGrantRepository, CodeGrantRepository>();

        }

    }
}
