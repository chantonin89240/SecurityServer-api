namespace SecurityServer.Data
{
    using Microsoft.EntityFrameworkCore;
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Reflection.Metadata;

    public class SecurityServerDbContext : DbContext
    {
        public DbSet<ApplicationEntity>? Applications { get; set; }

        public DbSet<ClaimEntity>? Claims { get; set; }

        public DbSet<RoleEntity>? Roles { get; set; }

        public DbSet<UserEntity>? Users { get; set; }

        public SecurityServerDbContext(DbContextOptions<SecurityServerDbContext> Options)
            : base(Options)
        {
        }
    }
}