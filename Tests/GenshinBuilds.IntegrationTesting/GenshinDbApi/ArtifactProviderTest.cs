using GenshinBuilds.Application.Common.Builders;
using GenshinBuilds.Application.Common.Resolvers;
using GenshinBuilds.Application.Interfaces;
using GenshinBuilds.Application;
using GenshinBuilds.GenshinDbApi.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenshinBuilds.Application.Common.Converters;
using GenshinBuilds.Domain.Models;

namespace GenshinBuilds.IntegrationTesting.GenshinDbApi;

public class ArtifactProviderTest
{
    IDataProvider<IEnumerable<ArtifactSet>> _artifactProvider;
    private IValueConverter _valueConverter;

    [SetUp]
    public void Setup()
    {
        _valueConverter = new ValueConverter(options =>
        {
            options.RegisterConverter(new StringToWeaponTypeConverter());
            options.RegisterConverter(new StringToRarityConverter());
            options.RegisterConverter(new StringToElementConverter());
            options.RegisterConverter(new StringToRelicTypeConverter());
        });
        _artifactProvider = new ArtifactsSetProvider(new HttpClient(), new ArtifactSetBuilder(_valueConverter), _valueConverter);

    }

    [Test]
    public async Task Test1()
    {
        var result = await _artifactProvider.LoadAsync();

        Assert.IsNotNull(result);
    }
}
