using BookSalesAPI.Models;
using KitapSatisAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KitapSatisAPI.Data
{
    public class KitapDbContext : DbContext
    {
        public KitapDbContext(DbContextOptions<KitapDbContext> options) : base(options) { }

        public DbSet<Book> Books => Set<Book>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Feedback> Feedbacks => Set<Feedback>();
    }
}
