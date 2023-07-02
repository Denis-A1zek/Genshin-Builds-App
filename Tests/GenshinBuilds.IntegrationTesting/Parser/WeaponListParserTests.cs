using GenshinBuilds.Application.Common.Builders;
using GenshinBuilds.Application.Common.Converters;
using GenshinBuilds.Application.Common.Resolvers;
using GenshinBuilds.Domain.Builders;
using Moq;

namespace GenshinBuilds.IntegrationTesting.Parser;

public class WeaponListParserTests : ParserTests<WeaponsParser>
{
    private IWeaponBuilder _weaponBuilder;

    [SetUp]
    public void Setup()
    {
        var _converter = new ValueConverter(options =>
        {
            options.RegisterConverter(new StringToWeaponTypeConverter());
            options.RegisterConverter(new StringToRarityConverter());
            options.RegisterConverter(new StringToElementConverter());
        });
        
        _weaponBuilder = new WeaponBuilder(_converter);
    }

    [Test]
    public async Task LoadAsync_WithValidHtmlPage_ShouldReturnWeapon()
    {
        //Arange        
        var _parser = new WeaponsParser(new HtmlWeb(), _weaponBuilder);

        //Act
        var result = await _parser.LoadAsync();

        //Assert
        result.Should().NotBeNull().And.HaveCountGreaterThan(0);
        result.Should().AllBeOfType<Weapon>();
    }

}
