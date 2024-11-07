using System.ComponentModel.DataAnnotations;

namespace BookListManager.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }

        public int CategoryId { get; set; }
        public  Category Category { get; set; }
        
    }
}
