using Microsoft.EntityFrameworkCore; //-- za DbContext klasu 

namespace Web_server.Models
{
    public class GarageContext : DbContext {
        public DbSet<Garaza> Garaza {get; set;}
        public DbSet<ParkingMesto> ParkingMesto {get; set;}
        public DbSet<Vozilo> Vozilo {get; set;}
        public GarageContext(DbContextOptions options) : base(options)
        {

        }
    }
}