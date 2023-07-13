using GenshinBuilds.Application;
using GenshinBuilds.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Updater.Handlers.Base;

public abstract class BaseUpdateHandler<T>
{
    protected internal IUnitOfWork UnitOfWork;
    protected internal IDataProvider<T> DataProvider;
    public BaseUpdateHandler(IUnitOfWork unitOfWork, IDataProvider<T> provider)
        => (UnitOfWork, DataProvider) = (unitOfWork, provider);
}
