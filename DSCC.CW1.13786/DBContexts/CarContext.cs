using DSCC.CW1._13786.Model;
using Microsoft.EntityFrameworkCore;

namespace DSCC.CW1._13786.DBContexts
{
    public class CarContext: DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options) { }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
