namespace SecurityServer.Data.Context
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class SecurityServerDbContextDesigner : IDesignTimeDbContextFactory<SecurityServerDbContext>
    {
        public SecurityServerDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SecurityServerDbContext>();
            builder.UseSqlServer("Server=serverbddsecurityg5caltest.database.windows.net;Initial Catalog=securityserverbdd;Persist Security Info=False;User ID=CloudSA9ba4e899;Password=Diiage_P2_G5_Test;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            return new SecurityServerDbContext(builder.Options);

        }
    }
}
