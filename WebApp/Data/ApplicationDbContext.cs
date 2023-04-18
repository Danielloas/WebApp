using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Data.Identity;
using WebApp.Models;

namespace WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationIdentityUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Manager>().Property(z => z.Id).UseIdentityColumn();
            builder.Entity<Manager>().Property(z => z.Name).HasMaxLength(100);

            builder.Entity<Manager>().HasData(
                new Manager
                {
                    Id = 1,
                    Name = "Daniel",
                    BirthDate = DateTime.Now.AddYears(-20),
                    Salary = 1200m,
                });

            base.OnModelCreating(builder);

        }

        public DbSet<Manager> Mangers { get; set; }
    }
}