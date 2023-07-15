using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application.Common.Models.ViewModels
{
    public class CharacterBuildItemViewModel
    {
        public MinimalCharacter Character { get; set; }
        public MinimalWeapon EquippedWeapon { get; set; }
        public List<ArtifactStatsDto> EquippedArtifacts { get; set; }
    }
}
