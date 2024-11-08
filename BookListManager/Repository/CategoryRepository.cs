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
        public async Task<Category> CreateAsync(Category obj)
        {
            _db.Category.Add(obj);
            await _db.SaveChangesAsync();
            return obj;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = _db.Category.Find(id);
            if (category == null) return false;
            _db.Category.Remove(category);
            await _db.SaveChangesAsync();
            return true;
        
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var obj =await _db.Category.FindAsync(id);
            if (obj == null)
            {
                return new Category();
            }
            return obj;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return (await _db.Category.ToListAsync());
        }
        
        
        
        
        public async Task<Category> GetByNameAsync(string name)
        {
            return (await _db.Category.FirstOrDefaultAsync(c => c.CategoryName == name));
        }

        public async Task<Category> UpdateAsync(Category obj)
        {
            var category = await _db.Category.FirstOrDefaultAsync(c => c.CategoryId == obj.CategoryId);
            if (category != null)
            {
                category.CategoryName = obj.CategoryName;
                _db.Category.Update(category);
                await _db.SaveChangesAsync();
                return category;
            }
            return new Category();
        }
        

    }
}
