using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GenshinBuilds.GenshinDbApi.Common.Models
{
    internal record WeaponResponse(
     string Name,
     string Description,
     string Weapontype,
     string Rarity,
     string Story,
     int Baseatk,
     string Substat,
     string Subvalue,
     string Effectname,
     string Effect,
     string Weaponmaterialtype,
     WeaponImages Images,
     string Version
    );
}
