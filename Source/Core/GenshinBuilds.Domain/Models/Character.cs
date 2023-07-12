using GenshinBuilds.Domain.Interfaces;

namespace GenshinBuilds.Domain.Models;

public sealed record Character : Identity, IUpdateble, IContainTypeOfWeapon, IRare
{
    public string Name { get; set; }   
    public string Description { get; set; }
    public string FullImage { get; set; }
    public string Avatar { get; set; }
    public WeaponType WeaponType { get; set; }
    public Rarity Rarity { get; set; }
    public Element Element { get; set; }
    public string ElementsImage { get; set; }
    
}
