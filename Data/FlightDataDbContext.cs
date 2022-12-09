using FlightDataApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightDataApi.Data
{
    public class FlightDataDbContext :DbContext
    {
        public FlightDataDbContext(DbContextOptions<FlightDataDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Flight> Flights { get; set; }
    }
}
