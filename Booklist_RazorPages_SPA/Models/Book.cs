using System.ComponentModel.DataAnnotations;

namespace BookList_RazorPages_SPA.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string Author { get; set; }  

    }
}
