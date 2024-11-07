using System.ComponentModel.DataAnnotations;

namespace BookListManager.Models
{
    public class Category
    { 
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        
        //public ICollection<Book> Books { get; set; }



    }
}
