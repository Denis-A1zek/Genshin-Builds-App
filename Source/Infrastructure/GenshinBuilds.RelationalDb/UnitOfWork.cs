using GenshinBuilds.Application;
using GenshinBuilds.Domain;
using GenshinBuilds.Domain.Models.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.RelationalDb;

public class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext _context;

    private Dictionary<string, object> _repositories;

    public UnitOfWork(DatabaseContext context)
        => (_context) = (context);
    
    public async Task<bool> Commit()
        => await _context.SaveChangesAsync() > 0;

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : Identity
    {
        if (_repositories == null)
            _repositories = new Dictionary<string, object>();
        
        var type = typeof(TEntity).Name;
        
        if (_repositories.ContainsKey(type))
            return (IRepository<TEntity>)_repositories[type];
        var repositoryType = typeof(Repository<>);
        
        _repositories.Add(type, Activator.CreateInstance(
            repositoryType.MakeGenericType(typeof(TEntity)), this)
        );

        return (IRepository<TEntity>)_repositories[type];
    }

    public IRepository<Identity> GetRepository(Type type)
    {
        if (_repositories == null)
            _repositories = new Dictionary<string, object>();

        if (_repositories.ContainsKey(type.Name))
            return (IRepository<Identity>)_repositories[type.Name];
        var repositoryType = typeof(Repository<>);

        _repositories.Add(type.Name, Activator.CreateInstance(
            repositoryType.MakeGenericType(type), this)
        );

        return (IRepository<Identity>)_repositories[type.Name];
    }

}
