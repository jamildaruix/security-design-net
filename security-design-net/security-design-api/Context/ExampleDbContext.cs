using Microsoft.EntityFrameworkCore;
using Security.Design.Api.Models;

namespace Security.Design.Api.Context
{
    public class ExampleDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<AirfareModel> AirfareModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
