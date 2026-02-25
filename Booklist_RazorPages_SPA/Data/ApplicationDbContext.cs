using BookList_RazorPages_SPA.Models;
using Microsoft.EntityFrameworkCore;

namespace BookList_RazorPages_SPA.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) :base(options) { }
        public DbSet<Book> Books { get; set; }
    }
}
