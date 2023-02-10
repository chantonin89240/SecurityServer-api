namespace SecurityServer.Data.Context
{
    using Microsoft.EntityFrameworkCore;
    using SecurityServer.Entities;

    public class SecurityServerDbContext : DbContext
    {
        public DbSet<Application>? Application { get; set; }

        public DbSet<ClaimEntity>? Claim { get; set; }

        public DbSet<Role>? Role { get; set; }

        public DbSet<UserEntity>? User { get; set; }

        public DbSet<ApplicationUserRole>? ApplicationUserRole { get; set; }

        //public DbSet<ApplicationRoleEntity>? ApplicationRole { get; set; }

        public DbSet<CodeGrantEntity>? CodeGrant { get; set; }

        public SecurityServerDbContext(DbContextOptions<SecurityServerDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUserRole>().HasKey(u => new { u.IdUser, u.IdApplication, u.IdRole });
            modelBuilder.Entity<Role>().HasMany(u => u.Applications);
            modelBuilder.Entity<Application>().HasMany(u => u.Roles);
            modelBuilder.Entity<ApplicationUserRole>().HasOne(a => a.Role).WithMany(a => a.ApplicationUserRoles).HasForeignKey(a => a.IdRole);
            modelBuilder.Entity<ApplicationUserRole>().HasOne(a => a.Application).WithMany(a => a.ApplicationUserRoles).HasForeignKey(a => a.IdApplication);
            modelBuilder.Entity<ApplicationUserRole>().HasOne(a => a.Claim).WithMany(a => a.ApplicationUserRoles).HasForeignKey(a => a.IdClaim);
            modelBuilder.Entity<ApplicationUserRole>().HasOne(a => a.User).WithMany(a => a.ApplicationUserRoles).HasForeignKey(a => a.IdUser);
            modelBuilder.Entity<CodeGrantEntity>().HasOne(c => c.User).WithOne(u => u.CodeGrantEntity).HasForeignKey<CodeGrantEntity>(c => c.IdUser);
        }
    }
}