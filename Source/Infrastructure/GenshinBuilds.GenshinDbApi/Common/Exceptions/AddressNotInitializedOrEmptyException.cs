namespace GenshinBuilds.GenshinDbApi.Common.Exceptions;

internal class AddressNotInitializedOrEmptyException : Exception
{
    public AddressNotInitializedOrEmptyException(string? message) : base(message)
    {
        Message = message;
    }

    public string? Message { get; }
}
