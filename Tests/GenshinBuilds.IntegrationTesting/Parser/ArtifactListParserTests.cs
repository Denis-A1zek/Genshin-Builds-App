using GenshinBuilds.Application.Common.Resolvers;
using GenshinBuilds.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenshinBuilds.Application.Common.Converters;
using GenshinBuilds.Parser.Parsers.Artifacts;

namespace GenshinBuilds.IntegrationTesting.Parser
{
    public class ArtifactListParserTests : ParserTests<CharactersParser>
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
        public async Task LoadAsync_WithValidHtmlPage_ShouldReturnCharacters()
        {
            //Arange
            var _parser = new ArtifactsParser(new HtmlWeb(), _valueConverter);

            //Act
            var result = await _parser.LoadAsync();

            //Assert
            result.Should().NotBeNull().And.HaveCountGreaterThan(0);
            result.Should().AllBeOfType<ArtifactSet>();
        }
    }
}
