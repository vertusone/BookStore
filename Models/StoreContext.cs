using Microsoft.EntityFrameworkCore;

namespace BookStore.Models
{
    public class  StoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}