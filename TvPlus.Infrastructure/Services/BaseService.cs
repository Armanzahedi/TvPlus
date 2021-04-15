using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using TvPlus.Core.Models;
using TvPlus.DataAccess;
using TvPlus.DataAccess.Repositories;
using TvPlus.Infrastructure.Helpers;

namespace TvPlus.Infrastructure.Services
{
    //public interface IBaseService<T> : IBaseRepository<T>
    //{
    //    T Save(T entity);
    //    new T Add(T entity);
    //    new T Update(T entity);

    //}
    //public class BaseService<T> where T : class, IBaseEntity
    //{
    //    private readonly IHttpContextAccessor _httpContext;
    //    private readonly IBaseRepository<T> _repo;
    //    public BaseService(IHttpContextAccessor httpContext, IBaseRepository<T> repo)
    //    {
    //        _httpContext = httpContext;
    //        _repo = repo;
    //    }
    //    public async ValueTask<T> Save(T entity)
    //    {
    //        if (entity.Id == 0)
    //        {
    //            entity.InsertDate = DateTime.Now;
    //            entity.InsertUser = _httpContext.HttpContext.User.Identity.IsAuthenticated ? _httpContext.HttpContext.User.Identity.Name : "";
    //            return await _repo.Add(entity);
    //        }
    //        else
    //        {
    //            var oldEntity = await _repo.GetById(entity.Id);
    //            if (oldEntity != null)
    //            {
    //                entity.InsertDate = oldEntity.InsertDate;
    //                entity.InsertUser = oldEntity.InsertUser;
    //                // Detaching previous entity so we can attach the new one as updated version
    //                _repo.Detach(oldEntity);
    //                entity.UpdateDate = DateTime.Now;
    //                entity.UpdateUser = _httpContext.HttpContext.User.Identity.IsAuthenticated ? _httpContext.HttpContext.User.Identity.Name : "";
    //                var a = await _repo.Update(entity);
    //                return a;
    //            }
    //            else
    //            {
    //                return default;
    //            }
    //        }
    //    }
    //    public new async Task Remove(int id)
    //    {
    //        var entity = await _repo.GetById(id);
    //        entity.UpdateDate = DateTime.Now;
    //        entity.UpdateUser = _httpContext.HttpContext.User.Identity.IsAuthenticated ? _httpContext.HttpContext.User.Identity.Name : "";
    //        entity.IsDeleted = true;
    //        await _repo.Update(entity);
    //    }
    //}
    //public class BaseService<T> : BaseRepository<T> where T : class, IBaseEntity
    //{
    //    private readonly IHttpContextAccessor _httpContext;
    //    public BaseService(IHttpContextAccessor httpContext, MyDbContext context) : base(context)
    //    {
    //        _httpContext = httpContext;
    //    }
    //    public T Save(T entity)
    //    {
    //        if (entity.Id == 0)
    //        {
    //            entity.InsertDate = DateTime.Now;
    //            entity.InsertUser = _httpContext.HttpContext.User.Identity.IsAuthenticated ? _httpContext.HttpContext.User.Identity.Name : "";
    //            var a = base.Add(entity);
    //            return a;
    //        }
    //        else
    //        {
    //            var oldEntity = base.GetById(entity.Id);
    //            if (oldEntity != null)
    //            {
    //                entity.InsertDate = oldEntity.InsertDate;
    //                entity.InsertUser = oldEntity.InsertUser;
    //                // Detaching previous entity so we can attach the new one as updated version
    //                base.Detach(oldEntity);
    //                entity.UpdateDate = DateTime.Now;
    //                entity.UpdateUser = _httpContext.HttpContext.User.Identity.IsAuthenticated ? _httpContext.HttpContext.User.Identity.Name : "";
    //                var a = base.Update(entity);
    //                return a;
    //            }
    //            else
    //            {
    //                return default;
    //            }
    //        }
    //    }
    //    public new T Add(T entity)
    //    {
    //        entity.InsertDate = DateTime.Now;
    //        entity.InsertUser = _httpContext.HttpContext.User.Identity.IsAuthenticated ? _httpContext.HttpContext.User.Identity.Name : "";
    //        return base.Add(entity);
    //    }
    //    public new T Update(T entity)
    //    {
    //        var oldEntity = base.GetById(entity.Id);
    //        entity.InsertDate = oldEntity.InsertDate;
    //        entity.InsertUser = oldEntity.InsertUser;
    //        // Detaching previous entity so we can attach the new one as updated version
    //        base.Detach(oldEntity);
    //        entity.UpdateDate = DateTime.Now;
    //        entity.UpdateUser = _httpContext.HttpContext.User.Identity.IsAuthenticated ? _httpContext.HttpContext.User.Identity.Name : "";
    //        return base.Update(entity);
    //    }
    //    public new void Remove(int id)
    //    {
    //        var entity = base.GetById(id);
    //        entity.UpdateDate = DateTime.Now;
    //        entity.UpdateUser = _httpContext.HttpContext.User.Identity.IsAuthenticated ? _httpContext.HttpContext.User.Identity.Name : "";
    //        entity.IsDeleted = true;
    //        base.Update(entity);
    //    }
    //}
}
