using carCRBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace carCRBackend.Contexts
{
    public class CarDataSQLiteDbContext : DbContext
    {
        public DbSet<CarDataModel> Cars { get; set; }

        public CarDataSQLiteDbContext(DbContextOptions<CarDataSQLiteDbContext> options) : base(options)
        {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuider)
        {
            base.OnModelCreating(modelBuider);
        }
    }
}
