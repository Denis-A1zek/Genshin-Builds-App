namespace GenshinBuilds.Application;

public interface IParser<T>
{
    public Task<T> LoadAsync();
}
