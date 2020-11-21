using Microsoft.EntityFrameworkCore;

namespace MapDoodle.Api.Models
{
    public class MapContext : DbContext
    {
        public MapContext(DbContextOptions<MapContext> options)
            : base(options)
        {
        }

        public DbSet<Map> Maps { get; set; }
    }
}