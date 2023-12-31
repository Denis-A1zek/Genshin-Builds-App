﻿using GenshinBuilds.Domain;
using GenshinBuilds.Domain.Interfaces;
using GenshinBuilds.Domain.Models;

namespace GenshinBuilds.Application.Common.Builders;

public class CharacterBuilder : ICharacterBuilder
{
    private Character _character;
    private readonly IValueConverter _converter;

    public CharacterBuilder(IValueConverter converter)
        => (_converter) = (converter);

    public ICharacterBuilder Create()
    {
        _character = new Character();
        return this;
    }

    public Character Build()
    {
        var buildedCharacter = _character;
        _character = null;
        return buildedCharacter;
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

    public ICharacterBuilder SetFullImage(string fullImageUrl)
    {
        _character.Image = fullImageUrl;
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

    public ICharacterBuilder SetTitle(string title)
    {
        _character.Title = title;
        return this;
    }

    public ICharacterBuilder SetFullName(string fullName)
    {
        _character.FullName = fullName;
        return this;
    }

    public ICharacterBuilder SetGender(string gender)
    {
        _character.Gender = gender;
        return this;
    }

    public ICharacterBuilder SetRegion(string region)
    {
        _character.Region = region;
        return this;
    }
}
