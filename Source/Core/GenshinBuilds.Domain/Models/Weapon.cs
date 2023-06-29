namespace GenshinBuilds.Domain.Models;

public sealed record Weapon : Identity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }   
    public WeaponType Type { get; set; }
    public Rarity Rarity { get; set; }
    public Modifire Modifier { get; set; }

}
