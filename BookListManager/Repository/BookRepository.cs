using BookListManager.Data;
using BookListManager.Models;
using BookListManager.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookListManager.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _db;
        public BookRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Book> CreateAsync(Book Obj)
        {
            _db.Book.Add(Obj);
            await _db.SaveChangesAsync();
            return Obj;
        }

        public async Task<bool> DeleteAsync(int id)
        { 
            var book = _db.Book.Find(id);
            if (book == null) return false;
            _db.Book.Remove(book);
            await _db.SaveChangesAsync();
            return true; 
        }
        public async Task<IEnumerable<Book>> GetLatestBooksAsync()
        {
            return await _db.Book
                .OrderByDescending(b => b.Created) // Assuming you have a CreatedDate property
                .Include(b => b.Category)
                .Take(10) // Optional: limit to the 5 most recent books
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByCategoryAsync(int categoryId)
        {
            // Asynchronously find the category by its ID
            var category = await _db.Category.FindAsync(categoryId);

            if (categoryId == 0)
            {
                // If category not found, return an empty list
                return new List<Book>();
            }

            // Asynchronously get books filtered by the category ID
            var books = await _db.Book
                .Where(book => book.CategoryId == categoryId)
                .ToListAsync();

            return books;
        }



        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return (await _db.Book.Include(b =>b.Category).ToListAsync());
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return (await _db.Book.FindAsync(id));
        }

        public async Task<Book> GetByNameAsync(string title)
        {
            return( await _db.Book.FirstOrDefaultAsync(c => c.Title == title));
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            var obj = await _db.Book.FirstOrDefaultAsync(u =>u.BookId == book.BookId);
            if (obj is not null)
            {
                obj.Title = book.Title;
                obj.Author = book.Author;
                obj.CategoryId = book.CategoryId; 
                _db.Book.Update(obj);
                await _db.SaveChangesAsync();
                return obj;
            }
            return new Book();
        }
    }
}
