using PetShop.BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PetShop.Repositories.Interfaces;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Repositories.Implements
{
    public class ProductRepository : IProductRepository
    {
        private readonly PetShopContext _context;
        public ProductRepository(PetShopContext context)
        {
            _context = context;
        }
        public Product Create(Product entity)
        {
            var product = _context.Products.Add(entity);
            _context.SaveChanges();
            return product.Entity;
        }
        public async Task<Product> CreateAsync(Product entity)
        {
            var product = await _context.Products.AddAsync(entity);
            _context.SaveChanges();
            return product.Entity;
        }
        public Product Delete(Product entity)
        {
            var product = _context.Products.Remove(entity);
            _context.SaveChanges();
            return product.Entity;
        }
        public IQueryable<Product> Get()
        {
            return _context.Products;
        }
        public IQueryable<Product> Get(Expression<Func<Product, bool>> predicate)
        {
            return _context.Products.Where(predicate);
        }
        public Product Get<TKey>(TKey id)
        {
            return _context.Products.Find(id);
        }
        public async Task<Product> GetAsync<TKey>(TKey id)
        {
            return await _context.Products.FindAsync(id);
        }
        public Product Update(Product entity)
        {
            var product = _context.Products.Update(entity);
            _context.SaveChanges();
            return product.Entity;
        }
    }
}
