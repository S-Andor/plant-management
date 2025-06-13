using Microsoft.EntityFrameworkCore;
using PlantCareAPI.Models;

namespace PlantCareAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Plant> Plants { get; set; }
    }
}