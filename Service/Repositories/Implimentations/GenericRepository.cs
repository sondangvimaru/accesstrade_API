using DLL.Entity;
using Microsoft.EntityFrameworkCore;
using Service.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repositories.Implimentations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly Accesstradecontext _context;
        public GenericRepository(Accesstradecontext context)
           => _context = context;

        public async Task<TEntity> Add(TEntity entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var obj = await _context.Set<TEntity>().FindAsync(id);
            if (obj is null) return obj;
            _context.Entry(obj).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<List<TEntity>> Getall()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Getbyid(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public  async Task<TEntity> Update(TEntity entity)
        {
            _context.Update(entity);
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                if (entry.Entity != entity)
                {
                    entry.State = EntityState.Unchanged;
                }
            }

            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
