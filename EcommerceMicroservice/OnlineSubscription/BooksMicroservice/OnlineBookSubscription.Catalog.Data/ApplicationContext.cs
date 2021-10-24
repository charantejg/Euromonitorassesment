using Microsoft.EntityFrameworkCore;
using OnlineBookSubscription.Catalog.Domain.Entities;

namespace OnlineBookSubscription.Catalog.Data
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasData(
                new {Id=1, Isbn = "10001", Title = "Azure", Author = "Microsoft", Price = 150.00, Thumbnail = "Ad.png"},
                new {Id=2, Isbn = "10002", Title = "Computer Graphics", Author = "Bob Jane", Price = 250.00, Thumbnail = "cg.png" },
                new {Id=3, Isbn = "10003", Title = "C Sharp", Author = "Martin", Price = 150.00, Thumbnail = "csharp.png" },
                new {Id=4, Isbn = "10004", Title = "Java", Author = "Peter", Price = 120.00, Thumbnail = "java.png" },
                new {Id=5, Isbn = "10005", Title = "Machine learning", Author = "Microsoft", Price = 180.00, Thumbnail = "ml.png" },
                new {Id=6, Isbn = "10006", Title = "Python", Author = "Carlos", Price = 220.00, Thumbnail = "python.png" }
                );
        }
    }
}

