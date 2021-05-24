using CarDealershipAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipAPI.Data
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options)
            : base(options)
        {

        }

        public DbSet<Cars> Cars { get; set; }
    }


}
