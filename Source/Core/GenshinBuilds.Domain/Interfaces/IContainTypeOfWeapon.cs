using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Domain.Interfaces;

public interface IContainTypeOfWeapon
{
    WeaponType WeaponType { get; set; }
}
