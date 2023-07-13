using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GenshinBuilds.GenshinDbApi.Common.Models
{
    internal record class CharacterResponse(
     string Name,
     string Fullname,
     string Title,
     string Description,
     string Rarity,
     string Element,
     string Weapontype,
     string Substat,
     string Gender,
     string Body,
     string Association,
     string Region,
     string Affiliation,
     string Birthdaymmdd,
     string Birthday,
     string Constellation,
     CharacterImages Images,
     string Version
    );
}
