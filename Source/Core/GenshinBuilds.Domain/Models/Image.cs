namespace GenshinBuilds.Domain.Models;

public sealed record Image : Identity
{
    public string FullImage { get; set; }
    public string Avatar { get; set; }
}
