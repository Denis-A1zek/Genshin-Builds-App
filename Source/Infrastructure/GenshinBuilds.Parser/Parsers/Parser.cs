
using GenshinBuilds.Application;
using GenshinBuilds.Application.Interfaces;

namespace GenshinBuilds.Parser.Common;

public abstract class Parser<T> : IParser<T>
{
    public Parser(HtmlWeb web)
        => Web = web;

    protected const string BaseUrl = "https://paimon.moe";
    protected HtmlWeb Web { get; init; }

    public abstract Task<T> LoadAsync();
}
