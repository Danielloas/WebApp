using Microsoft.EntityFrameworkCore;
using WebApp.Data.Identity;

namespace WebApp.Data
{
    public class CarShopContext : ApplicationDbContext
    {
        public CarShopContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<Car> Cars { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
