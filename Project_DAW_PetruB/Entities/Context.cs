using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DAW_PetruB.Entities
{
    public class Context : IdentityDbContext<User, Role, string, IdentityUserClaim<string>, UserRole,
        IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public DbSet<Producer> Producers { get; set; }
        public DbSet<License> Licenses{ get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<LicenseCart> LicenseCarts { get; set;  }

        public Context(DbContextOptions<Context> options) : base(options) { }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(LoggerFactory.Create(DbContextOptionsBuilder => DbContextOptionsBuilder.AddConsole()))
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true");
        }*/
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Cart>()
                .HasOne(a => a.User)
                .WithOne(aa => aa.Cart);
            builder.Entity<Producer>()
                .HasMany(a => a.Licenses)
                .WithOne(b => b.Producer);
            builder.Entity<LicenseCart>()
                .HasKey(lc => new { lc.LicenseId, lc.CartId });
            builder.Entity<LicenseCart>()
                .HasOne<License>(lc => lc.License)
                .WithMany(l => l.LicenseCarts)
                .HasForeignKey(lc => lc.LicenseId);
            builder.Entity<LicenseCart>()
                .HasOne<Cart>(lc => lc.Cart)
                .WithMany(l => l.LicenseCarts)
                .HasForeignKey(lc => lc.CartId);
            base.OnModelCreating(builder);
        }
    }
}
