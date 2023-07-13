using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.GenshinDbApi.Common.Constants;

internal static class ApiUrlConstants
{
    internal static string WeaponApiUrl => "https://genshin-db-api.vercel.app/api/weapons?query=names&dumpResult=true&matchAliases=true&matchCategories=true&verboseCategories=true&queryLanguages=Russian&resultLanguage=Russian";
    internal static string CharacterApiUrl => "https://genshin-db-api.vercel.app/api/characters?query=names&dumpResult=true&matchAliases=true&matchCategories=true&verboseCategories=true&queryLanguages=Russian&resultLanguage=Russian";
    internal static string ArtifactApiUrl => "https://genshin-db-api.vercel.app/api/artifacts?query=names&dumpResult=true&matchAliases=true&matchCategories=true&verboseCategories=true&queryLanguages=Russian&resultLanguage=Russian";
}
