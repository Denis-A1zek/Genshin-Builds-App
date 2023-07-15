using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Domain.Models;

public record WeaponCharacteristics
{
    public double BaseAtk { get; set; }
    public string SubStat { get; set; }
    public string SubValue { get; set; }

}
