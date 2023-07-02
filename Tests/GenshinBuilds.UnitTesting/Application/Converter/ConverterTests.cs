using FluentAssertions;
using GenshinBuilds.Application;
using GenshinBuilds.Application.Common.Converters;
using GenshinBuilds.Application.Common.Resolvers;
using GenshinBuilds.Application.Interfaces;
using GenshinBuilds.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.UnitTesting.Application.Converter;

public class ConverterTests
{
    private IValueConverter _converter;

    [SetUp]
    public void Setup()
    {
        _converter = new ValueConverter(options =>
        {
            options.RegisterConverter(new StringToWeaponTypeConverter());
            options.RegisterConverter(new StringToRarityConverter());   
            options.RegisterConverter(new StringToElementConverter());
        });
    }

    [Test]
    public void Convert_ShouldThrowException_BecauseConverterWasntFound()
    {
        Action action = () => _converter.Convert<object, object>("fdfd");
        action.Should().Throw<ConverterNotFoundException>();
    }

    [TestCase("Polearm", WeaponType.Polearm)]
    [TestCase("polearm", WeaponType.Polearm)]
    [TestCase("sword", WeaponType.Sword)]
    [TestCase("bow", WeaponType.Bow)]
    [TestCase("claymore", WeaponType.Claymore)]
    [TestCase("catalyst", WeaponType.Catalyst)]
    [TestCase("....", WeaponType.None)]
    [TestCase("", WeaponType.None)]
    public void WeaponTypeConverter_ShouldReturn_ValidValue(string from, WeaponType weaponType)
    {
        //Arrange
        var input = from;
        var expected = weaponType;

        //Act
        var result = _converter.Convert<string, WeaponType>(input);

        //Assert
        result.Should().Be(expected);
    }

    [TestCase("Legendary", Rarity.Legendary)]
    [TestCase("legendary", Rarity.Legendary)]
    [TestCase("primary", Rarity.Primary)]
    [TestCase("green", Rarity.Green)]
    [TestCase("rare", Rarity.Rare)]
    [TestCase("legendary rarity", Rarity.Legendary)]
    [TestCase("....", Rarity.Undefined)]
    [TestCase("", Rarity.Undefined)]
    public void RarityConverter_ShouldReturn_ValidValue(string from, Rarity rarity)
    {
        //Arrange
        var input = from;
        var expected = rarity;

        //Act
        var result = _converter.Convert<string, Rarity>(input);

        //Assert
        result.Should().Be(expected);
    }

    [TestCase("Geo", Element.Geo)]
    [TestCase("Anemo", Element.Anemo)]
    [TestCase("electro", Element.Electro)]
    [TestCase("dendro", Element.Dendro)]
    [TestCase("Cryo", Element.Cryo)]
    [TestCase("hydro element", Element.Hydro)]
    [TestCase("pyro", Element.Pyro)]
    [TestCase("....", Element.None)]
    [TestCase("", Element.None)]
    public void StringToElementConverter_ShouldReturn_ValidValue(string from, Element rarity)
    {
        //Arrange
        var input = from;
        var expected = rarity;

        //Act
        var result = _converter.Convert<string, Element>(input);

        //Assert
        result.Should().Be(expected);
    }
}
