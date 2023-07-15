using GenshinBuilds.Domain.Interfaces;

namespace GenshinBuilds.Domain.Models;

public sealed record Weapon : Identity, IUpdateble, IContainTypeOfWeapon, IRare
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }   
    public WeaponType WeaponType { get; set; }
    public Rarity Rarity { get; set; }
    public Modifire? Modifier { get; set; }
    public string? Story { get; set; }
    public WeaponCharacteristics? Characteristics { get; set; } 

}
