
using GenshinBuilds.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Domain.Builders;

public interface IWeaponBuilder
{
    public IWeaponBuilder Create();
    public IWeaponBuilder SetTile(string title);
    public IWeaponBuilder SetDescription(string description);
    public IWeaponBuilder SetImage(string imageUrl);
    public IWeaponBuilder SetType(string type);
    public IWeaponBuilder SetType(WeaponType type);
    public IWeaponBuilder SetRarity(string rarity);
    public IWeaponBuilder SetRarity(Rarity rarity);
    public IWeaponBuilder SetModifire(Modifire modifire);
    public IWeaponBuilder SetWeaponCharacteristics(WeaponCharacteristics characteristics);
    public IWeaponBuilder SetStory(string story);
    public Weapon Build();
}
 