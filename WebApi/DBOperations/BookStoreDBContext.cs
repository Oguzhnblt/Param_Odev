using Microsoft.EntityFrameworkCore;
using WebApi_Param_Odev.Entities;

namespace WebApi_Param_Odev.DBOperations
{
    public class BookStoreDBContext : DbContext, IBookStoreDbContext
    {
        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Author> Authors { get; set; }
        public DbSet<User> Users { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }

}