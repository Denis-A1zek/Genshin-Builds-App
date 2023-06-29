
namespace GenshinBuilds.IntegrationTesting.Parser;

public class CharacterListParserTests : ParserTests<CharactersParser>
{
    [Test]
    public async Task LoadAsync_WithValidHtmlPage_ShouldReturnCharacters()
    {
        //Arange
        var _parser = new CharactersParser(new HtmlWeb());

        //Act
        var result = await Parser.LoadAsync();

        //Assert
        result.Should().NotBeNull().And.HaveCountGreaterThan(0);
        result.Should().AllBeOfType<Character>();
    }
}
