﻿using BookListManager.Models;

namespace BookListManager.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public Category Create(Category obj);
        public Category Update(Category obj);   
        public bool Delete(int id);
        public Category GetById(int id);
        public Category GetByName(string name);
        public Category Get (int id);
        public IEnumerable<Category> GetAll(); 
        
    }
}
