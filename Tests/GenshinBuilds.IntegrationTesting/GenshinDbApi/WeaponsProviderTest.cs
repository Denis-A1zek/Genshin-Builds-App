using GenshinBuilds.Application.Common.Converters;
using GenshinBuilds.Application;
using GenshinBuilds.Application.Common.Resolvers;
using GenshinBuilds.Application.Interfaces;
using GenshinBuilds.GenshinDbApi.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenshinBuilds.Application.Common.Builders;

namespace GenshinBuilds.IntegrationTesting.GenshinDbApi;

public class WeaponsProviderTest
{
    IDataProvider<IEnumerable<Weapon>> _weaponProvider;
    private IValueConverter _valueConverter;

    [SetUp]
    public void Setup()
    {
        _valueConverter = new ValueConverter(options =>
        {
            options.RegisterConverter(new StringToWeaponTypeConverter());
            options.RegisterConverter(new StringToRarityConverter());
            options.RegisterConverter(new StringToElementConverter());
        });
        _weaponProvider = new WeaponsProvider(new HttpClient(), new WeaponBuilder(_valueConverter));
        
    }

    [Test]
    public async Task Test1()
    { 
        var result = await _weaponProvider.LoadAsync();

        Assert.IsNotNull(result);
    }
}
