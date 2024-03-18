using PetShop.BusinessObject.Models;
using PetShop.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Repositories.Implements
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PetShopContext _context;
        public CategoryRepository(PetShopContext context)
        {
            _context = context;
        }
        public Category Create(Category entity)
        {
            var category = _context.Categories.Add(entity);
            _context.SaveChanges();
            return category.Entity;
        }

        public async Task<Category> CreateAsync(Category entity)
        {
            var category = await _context.Categories.AddAsync(entity);
            _context.SaveChanges();
            return category.Entity;
        }

        public Category Delete(Category entity)
        {
            var category = _context.Categories.Remove(entity);
            _context.SaveChanges();
            return category.Entity;
        }

        public IQueryable<Category> Get()
        {
            return _context.Categories;
        }

        public IQueryable<Category> Get(Expression<Func<Category, bool>> predicate)
        {
            return _context.Categories.Where(predicate);
        }

        public Category Get<TKey>(TKey id)
        {
            return _context.Categories.Find(id);
        }

        public async Task<Category> GetAsync<TKey>(TKey id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public Category Update(Category entity)
        {
            var category = _context.Categories.Update(entity);
            _context.SaveChanges();
            return category.Entity;
        }
    }
}
        