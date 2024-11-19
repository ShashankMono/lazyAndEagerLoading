using LazyAndEagerLoading.Models;
using Microsoft.EntityFrameworkCore;

namespace LazyAndEagerLoading.Data
{
    public class AuthorContext:DbContext
    {
        public DbSet<Author> authors { get; set; }
        public DbSet<Book> books { get; set; }

        public AuthorContext(DbContextOptions option):base(option)
        {
        }
    }
}
