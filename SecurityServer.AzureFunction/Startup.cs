using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SecurityServer.Data;
using SecurityServer.Service;
using SecurityServer.Service.Interface;
using SecurityServer.Data.Repository;
using SecurityServer.Data.Repository.Interface;
using Microsoft.Extensions.Configuration;
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
               .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables()
               .Build();

            string connectionString = config.GetConnectionStringOrSetting("SqlConnectionString"); // "Server=bdd-p2-g5.database.windows.net;Initial Catalog=BDD-DIIAGE-P2-G5;Persist Security Info=False;User ID=diiage2bg;Password=Diiage_G5_P2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            builder.Services.AddDbContext<SecurityServerDbContext>(
              options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));
            builder.Services.AddScoped<IUnitOfWork<SecurityServerDbContext>, UnitOfWork<SecurityServerDbContext>>();

            // scope des services
            builder.Services.AddScoped<IApplicationService, ApplicationService>();
            builder.Services.AddScoped<ISalt,Salt>();
            builder.Services.AddScoped<ClaimService>();
            builder.Services.AddScoped<RoleService>();
            builder.Services.AddScoped<IUserService,UserService >();
            builder.Services.AddScoped<IAuthenticationService,AuthenticationService>();

            // scope des repository
            builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
            builder.Services.AddScoped<ClaimRepository>();
            builder.Services.AddScoped<RoleRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICodeGrantRepository, CodeGrantRepository>();

        }

    }
}
