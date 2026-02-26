using BookList_RazorPages_SPA.Data;
using BookList_RazorPages_SPA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookList_RazorPages_SPA.Pages.BookList
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public UpsertModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public Book Book { get; set; }
        public async Task <ActionResult > OnGet( int? id)
        {
            Book = new Book();//create
            if (id == null) return Page();
            //edit
            Book = await _context.Books.FindAsync(id.GetValueOrDefault());
            if (Book == null) return NotFound();
            return Page();
        }
    }
}
