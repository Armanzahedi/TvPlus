using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TvPlus.Core.Models;

namespace TvPlus.DataAccess.Repositories
{
    public interface IUserRepository
    { 
        Task<User> GetById(string id);
        Task<User> Add(User entity);
        Task<User> Update(User entity);
    }
    class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;
        public readonly UserManager<User> UserManager;
        public UserRepository(MyDbContext context, UserManager<User> userManager) 
        {
            _context = context;
            UserManager = userManager;
        }
        public async Task<User> GetById(string id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<User> Add(User entity)
        {
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<User> Update(User entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
