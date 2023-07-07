
using GenshinBuilds.Application.Common.Builders;
using GenshinBuilds.Application.Common.Converters;
using GenshinBuilds.Application.Common.Resolvers;
using GenshinBuilds.Domain.Builders;
using GenshinBuilds.Domain.Interfaces;

namespace GenshinBuilds.IntegrationTesting.Parser;

public class CharacterListParserTests : ParserTests<CharactersParser>
{
    private ICharacterBuilder _characterBuilder;

    [SetUp]
    public void Setup()
    {
        var _converter = new ValueConverter(options =>
        {
            options.RegisterConverter(new StringToWeaponTypeConverter());
            options.RegisterConverter(new StringToRarityConverter());
            options.RegisterConverter(new StringToElementConverter());
        });

        _characterBuilder = new CharacterBuilder(_converter);
    }

    [Test]
    public async Task LoadAsync_WithValidHtmlPage_ShouldReturnCharacters()
    {
        //Arange
        var _parser = new CharactersParser(new HtmlWeb(), _characterBuilder);

        //Act
        var result = await _parser.LoadAsync();

        //Assert
        result.Should().NotBeNull().And.HaveCountGreaterThan(0);
        result.Should().AllBeOfType<Character>();
    }
}
