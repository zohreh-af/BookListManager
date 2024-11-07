using BookListManager.Models;

namespace BookListManager.Repository.IRepository
{
    public interface IBookRepository
    {
        public Book GetById (int id);    
        public Book Create (Book Obj);
        public Book Update (Book book);
        public bool Delete (int id);
        public Book GetByName(string title);
        public Book Get(int id);
        public IEnumerable<Book> GetAll();
    }
}
