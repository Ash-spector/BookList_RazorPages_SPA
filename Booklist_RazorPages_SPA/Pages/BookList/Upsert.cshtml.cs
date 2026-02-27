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

        [BindProperty] // moved here; use [BindProperty(SupportsGet = true)] if you want binding on GET
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
        
        public async Task<ActionResult> OnPost()
        {
            if (Book == null) return NotFound();
            if (Book.Id == 0)
                await _context.Books.AddAsync(Book);
            else 
                _context.Books.Update(Book);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
        public async Task <ActionResult>OnPostDelete(int id)
        {
            var BookInDb = await _context.Books.FindAsync(id);
            if (BookInDb == null) return NotFound();
            _context.Books.Remove(BookInDb);
           await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
