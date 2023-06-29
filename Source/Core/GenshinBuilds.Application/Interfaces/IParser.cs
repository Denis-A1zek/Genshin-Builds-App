namespace GenshinBuilds.Application.Interfaces;

public interface IParser<T>
{
    public Task<T> LoadAsync();
}
