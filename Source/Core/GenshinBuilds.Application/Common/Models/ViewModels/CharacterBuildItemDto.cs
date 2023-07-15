using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application.Common.Models.ViewModels
{
    public class CharacterBuildItemDto
    {
        public Guid CharacterId { get; set; }
        public Guid EquippedWeaponId { get; set; }
        public List<ArtifactStatsDto> EquippedArtifacts { get; set; }
    }
}
