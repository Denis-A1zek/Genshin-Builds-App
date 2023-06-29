namespace GenshinBuilds.Domain.Models;

public sealed record Modifire : Identity
{
    public string Title { get; set; }
    public string Description { get; set; }
}
