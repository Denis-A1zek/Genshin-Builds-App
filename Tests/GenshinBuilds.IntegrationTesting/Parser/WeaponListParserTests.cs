namespace GenshinBuilds.IntegrationTesting.Parser;

public class WeaponListParserTests : ParserTests<WeaponsParser>
{
    [Test]
    public async Task LoadAsync_WithValidHtmlPage_ShouldReturnWeapon()
    {
        //Arange
        var _parser = new WeaponsParser(new HtmlWeb());

        //Act
        var result = await Parser.LoadAsync();

        //Assert
        result.Should().NotBeNull().And.HaveCountGreaterThan(0);
        result.Should().AllBeOfType<Weapon>();
    }

}
