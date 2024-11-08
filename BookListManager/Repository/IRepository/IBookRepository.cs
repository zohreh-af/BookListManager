using BookListManager.Models;

namespace BookListManager.Repository.IRepository
{
    public interface IBookRepository
    {
        public Task<Book> GetByIdAsync(int id);    
        public Task<Book> CreateAsync(Book Obj);
        public Task<Book> UpdateAsync(Book book);
        public Task<bool> DeleteAsync(int id);
        public Task<Book> GetByNameAsync(string title);
        public Task<IEnumerable<Book>> GetBooksByCategoryAsync(int CategoryId);
        public Task<IEnumerable<Book>> GetLatestBooksAsync();
        public Task<IEnumerable<Book>> GetAllAsync();
    }
}
