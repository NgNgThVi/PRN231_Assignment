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
    public class UserRepository : IUserRepository
    {
        private readonly PetShopContext _context;
        public UserRepository(PetShopContext context)
        {
            _context = context;
        }

        public User Create(User entity)
        {
            var user = _context.Users.Add(entity);
            _context.SaveChanges();
            return user.Entity;
        }

        public async Task<User> CreateAsync(User entity)
        {
            var user = await _context.Users.AddAsync(entity);
            _context.SaveChanges();
            return user.Entity;
        }

        public User Delete(User entity)
        {
            var user = _context.Users.Remove(entity);
            _context.SaveChanges();
            return user.Entity;
        }

        public IQueryable<User> Get()
        {
            return _context.Users;
        }

        public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
        {
            return _context.Users.Where(predicate);
        }

        public User Get<TKey>(TKey id)
        {
            return _context.Users.Find(id);
        }

        public async Task<User> GetAsync<TKey>(TKey id)
        {
            return await _context.Users.FindAsync(id);
        }

        public User Update(User entity)
        {
            var user = _context.Users.Update(entity);
            _context.SaveChanges();
            return user.Entity;
        }
    }
}
