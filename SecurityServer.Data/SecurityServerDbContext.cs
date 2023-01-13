namespace SecurityServer.Data
{
    using Microsoft.EntityFrameworkCore;
    using SecurityServer.Entities;

    public class SecurityServerDbContext : DbContext
    {
        public DbSet<ApplicationEntity>? Application { get; set; }

        public DbSet<ClaimEntity>? Claim { get; set; }

        public DbSet<RoleEntity>? Role { get; set; }

        public DbSet<UserEntity>? User { get; set; }
        public DbSet<UserApplicationEntity>? UserApplication { get; set; }

        public DbSet<CodeGrantEntity>? CodeGrant { get; set; }

        public SecurityServerDbContext(DbContextOptions<SecurityServerDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserApplicationEntity>().HasKey(u => new { u.IdUser, u.IdApplication });
        }
    }
}