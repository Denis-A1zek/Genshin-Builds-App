using GenshinBuilds.Application;
using GenshinBuilds.Application.Common.Builders;
using GenshinBuilds.Application.Common.Converters;
using GenshinBuilds.Application.Common.Resolvers;
using GenshinBuilds.Domain.Builders;
using Moq;

namespace GenshinBuilds.IntegrationTesting.Parser;

public class WeaponListParserTests : ParserTests<WeaponsParser>
{
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
        
    }

    [Test]
    public async Task LoadAsync_WithValidHtmlPage_ShouldReturnWeapon()
    {
        //Arange        
        var _parser = new WeaponsParser(new HtmlWeb(), _valueConverter);

        //Act
        var result = await _parser.LoadAsync();

        //Assert
        result.Should().NotBeNull().And.HaveCountGreaterThan(0);
        result.Should().AllBeOfType<Weapon>();
    }

}
