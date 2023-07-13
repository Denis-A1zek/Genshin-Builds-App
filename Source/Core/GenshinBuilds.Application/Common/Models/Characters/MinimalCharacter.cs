using GenshinBuilds.Application.Common.Interfaces;
using GenshinBuilds.Domain;
using GenshinBuilds.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application.Common.Models
{
    public class MinimalCharacter : IContainWeaponType, IRare
    {
        public Guid Id { get; set; }    
        public string Name { get; set; }    
        public string Avatar { get; set; }  
        public Element Element { get; set; }
        public WeaponType WeaponType { get; set; }
        public Rarity Rarity { get; set; }
    }
}
