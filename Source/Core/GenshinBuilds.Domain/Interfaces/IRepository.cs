using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Domain;

public interface IRepository<TEntity> where TEntity : Identity
{
    Task<TEntity> GetByIdAsync(Identity id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<List<TEntity>> Include(params Expression<Func<TEntity, object>>[] includes);
    //IQueryable<TEntity> Includes(params Expression<Func<TEntity, object>>[] includes);
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    Task<int> CountAsync();
    IQueryable<TEntity> GetQueryable();
    Task InsertAsync(TEntity entity);
    Task InsertRangeAsync(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
