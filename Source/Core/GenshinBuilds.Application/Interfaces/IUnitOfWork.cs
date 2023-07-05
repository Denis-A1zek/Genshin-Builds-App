using GenshinBuilds.Domain;
using GenshinBuilds.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application;

public interface IUnitOfWork
{
    Task<bool> Commit();
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : Identity;
    IRepository<Identity> GetRepository(Type type);
}
