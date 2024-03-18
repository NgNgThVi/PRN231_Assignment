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
    public class OrderRepository : IOrderRepository
    {
        private readonly PetShopContext _context;

        public OrderRepository(PetShopContext context)
        {
            _context = context;
        }

        public Order Create(Order entity)
        {
            var order = _context.Orders.Add(entity);
            _context.SaveChanges();
            return order.Entity;
        }

        public async Task<Order> CreateAsync(Order entity)
        {
            var order = await _context.Orders.AddAsync(entity);
            _context.SaveChanges();
            return order.Entity;
        }

        public Order Delete(Order entity)
        {
            var order = _context.Orders.Remove(entity);
            _context.SaveChanges();
            return order.Entity;
        }

        public IQueryable<Order> Get()
        {
            return _context.Orders;
        }

        public IQueryable<Order> Get(Expression<Func<Order, bool>> predicate)
        {
            return _context.Orders.Where(predicate);
        }

        public Order Get<TKey>(TKey id)
        {
            return _context.Orders.Find(id);
        }

        public async Task<Order> GetAsync<TKey>(TKey id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public Order Update(Order entity)
        {
            var order = _context.Orders.Update(entity);
            _context.SaveChanges();
            return order.Entity;
        }
    }
}
