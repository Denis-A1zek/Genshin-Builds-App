using GenshinBuilds.Application.Common.Interfaces;
using GenshinBuilds.Domain;
using GenshinBuilds.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application.Common.Models;

public class MinimalWeapon : IRare, IContainWeaponType
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Rarity Rarity { get; set;}
    public string Image { get; set; }
    public WeaponType WeaponType { get; set; }
}
