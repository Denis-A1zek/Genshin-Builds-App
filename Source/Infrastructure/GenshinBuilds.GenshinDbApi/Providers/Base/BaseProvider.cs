using GenshinBuilds.Application;
using GenshinBuilds.Application.Interfaces;
using GenshinBuilds.GenshinDbApi.Common.Models;
using System.Text.Json;

namespace GenshinBuilds.GenshinDbApi.Providers.Base;

public abstract class BaseProvider<T> : IDataProvider<T>
{
    public BaseProvider(HttpClient httpClient)
        => (Client) = (httpClient);

    protected internal abstract string Url { get; }

    protected internal HttpClient Client { get; set; }

    internal async Task<Response<TEntity>> GetResponseAsync<TEntity>()
    {
        if (string.IsNullOrEmpty(Url))
            throw new AddressNotInitializedOrEmptyException($"Failed to retrieve JSON for {nameof(T)}");
        var json = await Client.GetStringAsync(Url);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var responseDeserialized = JsonSerializer.Deserialize<Response<TEntity>>(json, options);
        return responseDeserialized;
    }

    public abstract Task<T> LoadAsync();
}
