﻿using GenshinBuilds.Domain;
using GenshinBuilds.Domain.Models.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.RelationalDb;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Identity
{
    private readonly DatabaseContext _context;
    private readonly DbSet<TEntity> _dbSet;
    public Repository(DatabaseContext context)
        => (_context, _dbSet) = (context, context.Set<TEntity>());

    public async Task InsertAsync(TEntity entity)
        => await _dbSet.AddAsync(entity);
    
    public void Delete(TEntity entity)
        => _dbSet.Remove(entity);

    public void Update(TEntity entity)
        => _dbSet.Entry(entity).State = EntityState.Modified;

    public async Task<IEnumerable<TEntity>> GetAllAsync()
        => await _dbSet.ToListAsync();

    public async Task<TEntity?> GetByIdAsync(Identity id)
        => await _dbSet.FindAsync(id);

    public IQueryable<TEntity> GetQueryable()
        => _dbSet;

    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        => await _dbSet.Where(predicate).ToListAsync();

    public async Task<bool> Commit()
        => await _context.SaveChangesAsync() > 0;
}
