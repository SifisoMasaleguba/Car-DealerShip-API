using Car_DealerShip_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Car_DealerShip_API.Data
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
        {
           
        }
        public DbSet<Car> Cars { get; set; }
    }
}
