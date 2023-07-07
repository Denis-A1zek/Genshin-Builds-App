using GenshinBuilds.Application;
using GenshinBuilds.Domain;
using GenshinBuilds.Domain.Models.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
        Type repositoryType = typeof(Repository<>).MakeGenericType(typeof(TEntity));

        ConstructorInfo constructor = repositoryType.GetConstructor(new[] { typeof(DatabaseContext) });

        _repositories.Add(type, constructor.Invoke(new object[] {_context}));

        return (IRepository<TEntity>)_repositories[type];
    }

    public object GetRepository(Type type)
    {
        if (_repositories == null)
            _repositories = new Dictionary<string, object>();

        if (_repositories.ContainsKey(type.Name))
            return (IRepository<Identity>)_repositories[type.Name];
        Type repositoryType = typeof(Repository<>).MakeGenericType(type);

        ConstructorInfo constructor = repositoryType.GetConstructor(new[] { typeof(DatabaseContext) });

        _repositories.Add(type.Name, constructor.Invoke(new object[] { _context }));

        return _repositories[type.Name];
    }

}
