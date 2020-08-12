using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArticleApp.Data.Base
{
    public interface IRepository<TEntity>
        where TEntity : IEntity<int>
    {
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> SoftDeleteAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync(int pageIndex = 0, int pageSize = 0);
        Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> predicate, int pageIndex = 0, int pageSize = 0);
        Task<bool> SaveChangesAsync();
    }
}
