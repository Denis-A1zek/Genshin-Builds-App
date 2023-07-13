using GenshinBuilds.Application;
using GenshinBuilds.Application.Common.Builders;
using GenshinBuilds.Application.Interfaces;
using GenshinBuilds.Domain;
using GenshinBuilds.Domain.Interfaces;
using GenshinBuilds.Domain.Models;
using GenshinBuilds.GenshinDbApi.Common.Models;
using GenshinBuilds.GenshinDbApi.Providers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.GenshinDbApi.Providers;

public class CharactersProvider : BaseProvider<IEnumerable<Character>>
{
    private readonly ICharacterBuilder _characterBuilder;

    public CharactersProvider
        (HttpClient httpClient, 
        ICharacterBuilder characterBuilder) : base(httpClient) 
        => (_characterBuilder) = characterBuilder;

    protected internal override string Url => ApiUrlConstants.CharacterApiUrl;

    public override async Task<IEnumerable<Character>> LoadAsync()
    {
        var characterResult = await GetResponseAsync<CharacterResponse>();

        var characters = characterResult.Result.Select(c =>
            _characterBuilder.Create()
            .SetFullName(c.Fullname)
            .SetName(c.Name)
            .SetDescription(c.Description)
            .SetRegion(c.Region)
            .SetElement(c.Element)
            .SetAvatar(c.Images.Icon)
            .SetFullImage(c.Images.Cover1)
            .SetTitle(c.Title)
            .SetRarity((Rarity)int.Parse(c.Rarity))
            .SetWeaponType(c.Weapontype)
            .SetGender(c.Gender)
            .Build());

        return characters;
    }
}
