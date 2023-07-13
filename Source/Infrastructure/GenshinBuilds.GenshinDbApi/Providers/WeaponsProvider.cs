using GenshinBuilds.Application;
using GenshinBuilds.Application.Interfaces;
using GenshinBuilds.Domain;
using GenshinBuilds.Domain.Builders;
using GenshinBuilds.Domain.Models;
using GenshinBuilds.GenshinDbApi.Common.Models;
using GenshinBuilds.GenshinDbApi.Providers.Base;
using System.Text.Json;

namespace GenshinBuilds.GenshinDbApi.Providers;

public class WeaponsProvider : BaseProvider<IEnumerable<Weapon>>
{
    private readonly IWeaponBuilder _weaponBuilder;

    public WeaponsProvider
        (HttpClient httpClient, 
        IWeaponBuilder weaponBuilder) : base(httpClient) 
        => _weaponBuilder = weaponBuilder;  

    protected internal override string Url => ApiUrlConstants.WeaponApiUrl;

    public override async Task<IEnumerable<Weapon>> LoadAsync()
    {
        var weaponResult = await GetResponseAsync<WeaponResponse>();

        var weapons = weaponResult.Result
            .Select(w =>
            _weaponBuilder.Create()
            .SetTile(w.Name)
            .SetDescription(w.Description)
            .SetType(w.Weapontype)
            .SetRarity((Rarity)int.Parse(w.Rarity))
            .SetModifire(new Modifire() { Title = w.Effectname, Description = w.Effect})
            .SetImage(w.Images.Icon)
            .SetStory(w.Story)
            .SetWeaponCharacteristics(new WeaponCharacteristics()
            {
                BaseAtk = w.Baseatk,
                SubStat = w.Substat,
                SubValue = w.Subvalue
            })
            .Build());

        return weapons;
    }
}
