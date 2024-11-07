using BookListManager.Data;
using BookListManager.Models;
using BookListManager.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookListManager.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) 
        {
            _db = db;
        }
        public Category Create(Category obj)
        {
            _db.Category.Add(obj);
            _db.SaveChanges();
            return obj;

        }

        public bool Delete(int id)
        {
            var category = _db.Category.Find(id);
            if (category == null) return false;
            _db.Category.Remove(category);
            _db.SaveChanges();
            return true;
        
        }

        public Category Get(int id)
        {
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return new Category();
            }
            return obj;
        }

        public IEnumerable<Category> GetAll()
        {
            return _db.Category.ToList();
        }
        public Category GetById(int id)
        {
            return _db.Category.Find(id);
        }

        public Category GetByName(string name)
        {
            return _db.Category.FirstOrDefault(c => c.CategoryName == name);
        }

        public Category Update(Category obj)
        {
            var category = _db.Category.Find(obj);
            if (category is not null)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                return obj;
            }
            return new Category();
        }

    }
}
