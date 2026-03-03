using System.Linq;
using BookList_RazorPages_SPA.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookList_RazorPages_SPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var bookList = _context.Books.ToList();
            return Json(new { data = bookList });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var bookInDb = _context.Books.Find(id);
            if (bookInDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _context.Books.Remove(bookInDb);
            _context.SaveChanges();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}