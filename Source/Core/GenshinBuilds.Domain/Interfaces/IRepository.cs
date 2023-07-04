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
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    Task<bool> Commit();
    IQueryable<TEntity> GetQueryable();
    Task InsertAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
