using DSCC_9294_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace DSCC_9294_API.DataContext
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<Car> Car { get; set; }
        public DbSet<Owner> Owner { get; set; }
    }
}
