using BookList_RazorPages_SPA.Data;
using BookList_RazorPages_SPA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookList_RazorPages_SPA.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable < Book> Books { get; set; }
        
        public async Task OnGet()
        {
            Books = await _context.Books.ToListAsync();
        }
    }
}
