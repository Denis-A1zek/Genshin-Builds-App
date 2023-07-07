using FluentAssertions;
using GenshinBuilds.Application;
using GenshinBuilds.Application.Common.Builders;
using GenshinBuilds.Domain;
using GenshinBuilds.Domain.Builders;

using GenshinBuilds.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.UnitTesting.Application.Builders;

public class WeaponBuilderTest
{
    private IWeaponBuilder _weaponBuilder;
    private Mock<IValueConverter> _valueConverter;
    
    [SetUp]
    public void Setup()
    {
        _valueConverter = new Mock<IValueConverter>();
        _weaponBuilder = new WeaponBuilder(_valueConverter.Object);
    }

    [Test]
    public void Builer_ShouldReturn_ValidWeaponObject()
    {
        _valueConverter.Setup(s 
            => s.Convert<string, WeaponType>(It.IsAny<string>()))
            .Returns(WeaponType.Bow);

        _valueConverter.Setup(s
            => s.Convert<string, Rarity>(It.IsAny<string>()))
            .Returns(Rarity.Legendary);

        var weapon = _weaponBuilder
            .SetTile("Some title")
            .SetDescription("Some desc")
            .SetType("Bow")
            .SetImage("Some image")
            .SetModifire(new Modifire() { Title = "SomeTitle", Description = " SomeDesc"})
            .SetRarity("legendary")
            .Build();

        weapon.Should().BeOfType<Weapon>()
            .And.NotBeNull();
    }
}
