using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TvPlus.Core;
using TvPlus.Core.Models;

namespace TvPlus.DataAccess.Repositories
{
    public interface IBaseRepository<T> where T : class, IBaseEntity
    {
        IEnumerable<T> GetAll();
        int GetCount();
        IEnumerable<T> GetListPaged(int pageNumber,int itemsPerPage);
        T GetById(int id);
        T Add(T entity);
        T Update(T entity);
        T AddOrUpdate(T entity);
        T Delete(int id);
        T Delete(T entity);
        T Remove(int id);
        void Detach(T entity);
        IEnumerable<T> GetDefaultQuery();
        string GetCurrentUsersName();
    }
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class, IBaseEntity
    {
        private readonly MyDbContext _context;
        private readonly HttpContextAccessor _httpContext;
        public BaseRepository(MyDbContext context)
        {
            _context = context;
            _httpContext ??= new HttpContextAccessor();
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public int GetCount()
        {
            return  _context.Set<T>().Count();
        }

        public IEnumerable<T> GetListPaged(int pageNumber = 1 , int itemsPerPage = 10)
        {
            var entity = _context.Set<T>().Skip((pageNumber - 1) * itemsPerPage).Where(e=>e.IsDeleted == false)
                .Take(itemsPerPage);

            return entity;

        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        //public T Add(T entity)
        //{
        //    _context.Set<T>().Add(entity);
        //    _context.SaveChangesAsync();
        //    return entity;
        //}
        //public T Update(T entity)
        //{
        //    _context.Entry(entity).State = EntityState.Modified;
        //    _context.SaveChanges();
        //    return entity;
        //}
        public T Add(T entity)
        {
            entity.InsertDate = DateTime.Now;
            entity.InsertUser = GetCurrentUsersName();
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }
        public T Update(T entity)
        {
            var oldEntity = _context.Set<T>().Find(entity.Id);
            entity.InsertDate = oldEntity.InsertDate;
            entity.InsertUser = oldEntity.InsertUser;
            Detach(oldEntity);
            entity.UpdateDate = DateTime.Now;
            entity.UpdateUser = GetCurrentUsersName();
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
        public T AddOrUpdate(T entity)
        {
            var a = GetById(entity.Id);

            if (a != null)
                Update(entity);
            else
                Add(entity);

            return entity;
        }
        public T Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);
            entity.IsDeleted = true;
            Update(entity);
            return entity;
        }
        public T Delete(T entity)
        {
            entity.IsDeleted = true;
            Update(entity);
            return entity;
        }
        public T Remove(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity == null)
            {
                return entity;
            }

            _context.Set<T>().Remove(entity); 
            _context.SaveChanges();

            return entity;
        }
        public void Detach(T entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
            _context.SaveChanges();
        }

        public IEnumerable<T> GetDefaultQuery()
        {
            return _context.Set<T>().Where(m=>m.IsDeleted == false).AsQueryable();
        }


        public string GetCurrentUsersName()
        {
            var userName = "";
            if (_httpContext?.HttpContext?.User?.Identity?.Name != null)
            {
                userName = _httpContext.HttpContext.User.Identity.Name;
            }
            return userName;
        }
    }
}
