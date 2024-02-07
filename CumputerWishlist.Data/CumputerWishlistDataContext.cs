using CumputerWishlist.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace CumputerWishlist.Data
{
    public class CumputerWishlistDataContext : DbContext
    {
        public CumputerWishlistDataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Component> Components { get; set; }
        public DbSet<ComponentType> ComponentTypes { get; set; }
        public DbSet<ComputerSpec> ComputerSpecs { get; set; }
        public DbSet<ComputerSpecComponent> ComputerSpecComponents { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
