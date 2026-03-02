using System.Linq;
using BookList_RazorPages_SPA.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookList_RazorPages_SPA.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var booklist = _context.Books.ToList();
            return new JsonResult(new { booklist }); // or: return Ok(new { booklist });
        }
    }
}
