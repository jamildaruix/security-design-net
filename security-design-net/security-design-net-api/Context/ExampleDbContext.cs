using Microsoft.EntityFrameworkCore;
using Security.Design.Net.Api.Models;

namespace Security.Design.Net.Api.Context
{
    public class ExampleDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<AirfareModel> AirfareModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
