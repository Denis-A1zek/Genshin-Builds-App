using GenshinBuilds.Application.Common.Resolvers;
using GenshinBuilds.Application.Interfaces;
using GenshinBuilds.Application;
using GenshinBuilds.GenshinDbApi.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenshinBuilds.Application.Common.Builders;
using GenshinBuilds.Application.Common.Converters;

namespace GenshinBuilds.IntegrationTesting.GenshinDbApi
{
    public class CharacterProviderTest
    {
        IDataProvider<IEnumerable<Character>> _characterProvider;
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
            _characterProvider = new CharactersProvider(new HttpClient(), new CharacterBuilder(_valueConverter));

        }

        [Test]
        public async Task Test1()
        {
            var result = await _characterProvider.LoadAsync();

            Assert.IsNotNull(result);
        }
    }
}
