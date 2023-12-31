﻿using GenshinBuilds.Domain.Builders;
using GenshinBuilds.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Domain.Interfaces;

public interface ICharacterBuilder
{
    public ICharacterBuilder Create();
    public ICharacterBuilder SetName(string name);
    public ICharacterBuilder SetTitle(string title);
    public ICharacterBuilder SetFullName(string fullName);
    public ICharacterBuilder SetGender(string gender);
    public ICharacterBuilder SetRegion(string region);
    public ICharacterBuilder SetDescription(string description);
    public ICharacterBuilder SetFullImage(string fullImageUrl);
    public ICharacterBuilder SetAvatar(string avatarUrl);
    public ICharacterBuilder SetRarity(string rarity);
    public ICharacterBuilder SetRarity(Rarity rarity);
    public ICharacterBuilder SetWeaponType(string weapon);
    public ICharacterBuilder SetWeaponType(WeaponType weapon);
    public ICharacterBuilder SetElement(string element);
    public ICharacterBuilder SetElement(Element element);
    public Character Build();
}
