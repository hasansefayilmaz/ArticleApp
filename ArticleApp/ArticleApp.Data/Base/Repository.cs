using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArticleApp.Data.Base
{
    public class Repository<TEntity, TDbContext> : IRepository<TEntity>
        where TEntity : class, IEntity<int>
        where TDbContext : DbContext
    {
        private readonly TDbContext _context;
        public DbSet<TEntity> DbSet { get; }

        public Repository(TDbContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }

        public async Task<bool> CreateAsync(TEntity entity)
        {
            try
            {
                //entity.CreateDate = DateTime.UtcNow;
                DbSet.Add(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            try
            {
                _context.Attach(entity);
                var entry = _context.Entry(entity);
                entry.State = EntityState.Modified;
                if (entry.Property("CreatedDate") != null)
                {
                    entry.Property("CreatedDate").IsModified = false;
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> SoftDeleteAsync(TEntity entity)
        {
            try
            {
                var dbEntity = await GetByIdAsync(entity.Id);
                dbEntity.Status = 0;
                return await CreateAsync(dbEntity);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await DbSet.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(int pageIndex = 0, int pageSize = 0)
        {
            return await DbSet.AsNoTracking().OrderByDescending(c => c.Id).Skip(pageIndex * pageSize).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> predicate, int pageIndex = 0, int pageSize = 0)
        {
            return await DbSet.AsNoTracking().Where(predicate).OrderByDescending(c => c.Id).Skip(pageIndex * pageSize).ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
            return true;
        }

        protected virtual bool IsPersistent(IEntity<int> entity)
        {
            return !entity.Id.Equals(default);
        }
    }
}
