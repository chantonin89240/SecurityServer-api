namespace SecurityServer.Data
{
    using Microsoft.EntityFrameworkCore;
    using SecurityServer.Entities;
    using System;
    using System.Collections.Generic;
    using System.Reflection.Metadata;

    public class SecurityServerDbContext : DbContext
    {
        public DbSet<ApplicationEntity>? Application { get; set; }

        public DbSet<ClaimEntity>? Claim { get; set; }

        public DbSet<RoleEntity>? Role { get; set; }

        public DbSet<UserEntity>? User { get; set; }

        public SecurityServerDbContext(DbContextOptions<SecurityServerDbContext> options)
            : base(options)
        {
        }
    }
}