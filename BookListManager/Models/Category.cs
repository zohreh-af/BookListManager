using System.ComponentModel.DataAnnotations;

namespace BookListManager.Models
{
    public class Category
    { 
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public string Slug
        {
            get
            {
                return CategoryName.ToLower();
            }
        }
        public ICollection<Book> Books { get; set; }
        public ICollection<Category> SubCategories { get; set; } = new List<Category>();
        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }


    }
}
