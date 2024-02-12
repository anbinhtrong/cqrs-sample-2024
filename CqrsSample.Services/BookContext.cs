using CqrsSample.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace CqrsSample.Services;

public class BookContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public BookContext(DbContextOptions<BookContext> options) : base(options)
    {

    }

}
