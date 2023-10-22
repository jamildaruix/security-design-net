using Microsoft.EntityFrameworkCore;
using Security.Design.Net.Api.Models;
using System.Reflection.Metadata;

namespace Security.Design.Net.Api.Context
{
    public class ExampleDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<PassagemModel> PassagemModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
