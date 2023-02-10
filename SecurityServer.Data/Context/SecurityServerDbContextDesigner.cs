using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Data.Context
{
    public class SecurityServerDbContextDesigner : IDesignTimeDbContextFactory<SecurityServerDbContext>
    {
        public SecurityServerDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SecurityServerDbContext>();
            builder.UseSqlServer("Server=securityserverbdd.database.windows.net;Initial Catalog=securityserverbdd;Persist Security Info=False;" +
                "User ID=DiiageG5test;Password=6ix9ine6ix9ine!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            return new SecurityServerDbContext(builder.Options);

        }
    }
}
