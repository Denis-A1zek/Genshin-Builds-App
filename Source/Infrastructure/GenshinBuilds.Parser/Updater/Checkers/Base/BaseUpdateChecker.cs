using GenshinBuilds.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Parser.Updater.Checkers.Base;

public class BaseUpdateChecker
{
    protected readonly HtmlWeb HtmlWeb;
    protected readonly IUnitOfWork UnitOfWork;
    public BaseUpdateChecker(HtmlWeb htmlWeb, IUnitOfWork unitOfWork)
        => (HtmlWeb, UnitOfWork) = (htmlWeb, unitOfWork);

    protected internal async Task<int> EntityQuantityParserAsync(string url, string parsePattern)
    {
        var htmlDocument = await HtmlWeb.LoadFromWebAsync(url);
        var block = htmlDocument.DocumentNode.SelectSingleNode(parsePattern);
        var count = block.ChildNodes.Count;
        return count;
    }
}
