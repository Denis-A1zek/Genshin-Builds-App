using GenshinBuilds.Application.Common.Converters.Interfaces;

using GenshinBuilds.Domain;
using GenshinBuilds.Domain.Builders;
using GenshinBuilds.Domain.Models;

namespace GenshinBuilds.Application.Common.Builders;

public class WeaponBuilder : IWeaponBuilder
{
    private  Weapon _weapon;
    private readonly IValueConverter _converter;

    public WeaponBuilder(IValueConverter converter)
        => (_converter) = (converter);

    public IWeaponBuilder Create()
    {
        _weapon = new Weapon();
        return this;
    }

    public Weapon Build()
    {
        var buildedWeapon = _weapon;
        _weapon = null;
        return buildedWeapon;
    }

    public IWeaponBuilder SetDescription(string description)
    {
        _weapon.Description = description; 
        return this;
    }

    public IWeaponBuilder SetImage(string imageUrl)
    {
        _weapon.Image = imageUrl;
        return this;
    }

    public IWeaponBuilder SetModifireDescription(string modifireDescription)
    {
        _weapon.Modifier ??= new();
        _weapon.Modifier.Description = modifireDescription;
        return this;
    }

    public IWeaponBuilder SetModifire(Modifire modifire)
    {
        _weapon.Modifier = modifire;
        return this;
    }

    public IWeaponBuilder SetRarity(string rarity)
    {
        _weapon.Rarity = _converter.Convert<string, Rarity>(rarity);    
        return this;
    }

    public IWeaponBuilder SetRarity(Rarity rarity)
    {
        _weapon.Rarity = rarity;
        return this;
    }

    public IWeaponBuilder SetTile(string title)
    {
        _weapon.Title = title;
        return this;
    }

    public IWeaponBuilder SetType(string type)
    {
        _weapon.WeaponType = _converter.Convert<string, WeaponType>(type);
        return this;
    }

    public IWeaponBuilder SetType(WeaponType type)
    {
        _weapon.WeaponType = type;
        return this;
    }

    public IWeaponBuilder SetWeaponCharacteristics(WeaponCharacteristics characteristics)
    {
        _weapon.Characteristics = characteristics;
        return this;
    }

    public IWeaponBuilder SetStory(string story)
    {
        _weapon.Story = story;
        return this;
    }
}
