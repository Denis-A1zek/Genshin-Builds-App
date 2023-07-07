using GenshinBuilds.Domain;
using GenshinBuilds.Domain.Interfaces;
using GenshinBuilds.Domain.Models;

namespace GenshinBuilds.Application.Common.Builders;

public class CharacterBuilder : ICharacterBuilder
{
    private readonly Character _character;
    private readonly IValueConverter _converter;

    public CharacterBuilder(IValueConverter converter)
        => (_character, _converter) = (new(), converter);

    public Character Build()
    {
        throw new NotImplementedException();
    }

    public ICharacterBuilder SetAvatar(string avatarUrl)
    {
        _character.Avatar = avatarUrl;
        return this;
    }

    public ICharacterBuilder SetDescription(string description)
    {
        _character.Description = description;
        return this;
    }

    public ICharacterBuilder SetElement(string element)
    {
        SetElement(_converter.Convert<string, Element>(element));
        return this;
    }

    public ICharacterBuilder SetElement(Element element)
    {
        _character.Element = element;
        return this;
    }

    public ICharacterBuilder SetElementImage(string elementImage)
    {
        _character.ElementsImage = elementImage;
        return this;
    }

    public ICharacterBuilder SetFullImage(string fullImageUrl)
    {
        _character.FullImage = fullImageUrl;
        return this;
    }

    public ICharacterBuilder SetName(string name)
    {
        _character.Name = name;
        return this;
    }

    public ICharacterBuilder SetRarity(string rarity)
    {
        SetRarity(_converter.Convert<string,Rarity>(rarity));
        return this;
    }

    public ICharacterBuilder SetRarity(Rarity rarity)
    {
        _character.Rarity = rarity;
        return this;
    }

    public ICharacterBuilder SetWeaponType(string weapon)
    {
        SetWeaponType(_converter.Convert<string,WeaponType>(weapon)); 
        return this;
    }

    public ICharacterBuilder SetWeaponType(WeaponType weapon)
    {
        _character.WeaponType = weapon;
        return this;
    }
}
