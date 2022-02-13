using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using VUTTR.Data.Context;
using VUTTR.Data.Repository.Interfaces;

namespace VUTTR.Data.Repository.Implementations
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        protected readonly VUTTRContext _context;
        public Repository(VUTTRContext ctx)
        {
            _context = ctx;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<T> GetOne(Expression<Func<T, bool>> predicate, params Expression<Func<T, Object>>[] includes)
        {
            return await Task.Run(() =>
            {
                var query = _context.Set<T>().AsQueryable();
                if (includes is not null && includes.Any())
                    foreach (var include in includes)
                        query = query.Include(include);

                return query.FirstOrDefault(predicate);
            });
        }
        public async Task<List<T>> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, Object>>[] includes)
        {
            return await Task.Run(() =>
            {
                var query = _context.Set<T>().AsQueryable();
                if (includes is not null && includes.Any())
                    foreach (var include in includes)
                        query = query.Include(include);

                return query.Where(predicate).ToListAsync();
            });
        }
        public async Task<T> Insert(T model)
        {
            await _context.Set<T>().AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<ICollection<T>> Insert(ICollection<T> models)
        {
            await _context.Set<T>().AddRangeAsync(models);
            await _context.SaveChangesAsync();
            return models;
        }
        public async Task<T> Update(T model)
        {
            // _context.Entry(model).State = EntityState.Modified;
            _context.Set<T>().Update(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<ICollection<T>> Update(ICollection<T> models)
        {
            // _context.Entry(model).State = EntityState.Modified;
            _context.Set<T>().UpdateRange(models);
            await _context.SaveChangesAsync();
            return models;
        }
        public async Task<T> Delete(T model)
        {
            _context.Set<T>().Remove(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<ICollection<T>> Delete(ICollection<T> models)
        {
            _context.Set<T>().RemoveRange(models);
            await _context.SaveChangesAsync();
            return models;
        }
    }
}