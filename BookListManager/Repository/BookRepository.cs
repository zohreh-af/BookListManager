using BookListManager.Data;
using BookListManager.Models;
using BookListManager.Repository.IRepository;

namespace BookListManager.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _db;
        public BookRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public Book Create(Book Obj)
        {
            _db.Book.Add(Obj);
            _db.SaveChanges();
            return Obj;
        }

        public bool Delete(int id)
        { 
            var book = _db.Book.Find(id);
            if (book == null) return false;
            _db.Book.Remove(book);
            _db.SaveChanges();
            return true; }

        public Book Get(int id)
        {
            var obj = _db.Book.Find(id);
            if (obj == null)
            {
                return new Book();
            }
            return obj;
        }

       
        public IEnumerable<Book> GetAll()
        {
            return _db.Book.ToList();
        }

        public Book GetById(int id)
        {
            return _db.Book.Find(id);
        }

        public Book GetByName(string title)
        {
            return _db.Book.FirstOrDefault(c => c.Title == title);
        }

        public Book Update(Book book)
        {
            var obj = _db.Book.Find(book);
            if (obj is not null)
            {
                _db.Book.Update(obj);
                _db.SaveChanges();
                return obj;
            }
            return new Book();
        }
    }
}
