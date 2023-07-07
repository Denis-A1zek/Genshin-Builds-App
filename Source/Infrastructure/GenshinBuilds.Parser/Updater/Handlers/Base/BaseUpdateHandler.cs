using GenshinBuilds.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Parser.Updater.Handlers.Base;

public abstract class BaseUpdateHandler
{
    protected internal IUnitOfWork UnitOfWork;

    public BaseUpdateHandler(IUnitOfWork unitOfWork)
        => (UnitOfWork) = (unitOfWork);
}
