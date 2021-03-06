using Microsoft.EntityFrameworkCore;

namespace CademeucarroApi.Models
{
    public class CadeMeuCarroDataContext : DbContext
    {
        public CadeMeuCarroDataContext(DbContextOptions<CadeMeuCarroDataContext> options)
            : base(options)
        {
            
        }
        
        public DbSet<Car> Cars { get; set; }
        public DbSet<TrackCar> Tracks { get; set; }
    }
}