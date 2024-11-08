using BookListManager.Models;

namespace BookListManager.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public Task<Category> CreateAsync(Category obj);
        public Task<Category> UpdateAsync(Category obj);   
        public Task<bool> DeleteAsync(int id);
        public Task<Category> GetByIdAsync(int id);
        public Task<Category> GetByNameAsync(string name);
        
        
        public Task<IEnumerable<Category>> GetAllAsync(); 
        
    }
}
