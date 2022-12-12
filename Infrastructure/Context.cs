using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure
{
    public class Context: DbContext
    {
        public DbSet<User> Users { get; set; }
        public Context(DbContextOptions options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder); 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }
    }
}
