using AutoFixture;
using FluentAssertions;
using GenshinBuilds.Application;
using GenshinBuilds.Application.Interfaces;
using GenshinBuilds.Domain;
using GenshinBuilds.Domain.Models;
using GenshinBuilds.Parser.Updater.Handlers;
using GenshinBuilds.Updater.Handlers;
using Moq;

namespace GenshinBuilds.UnitTesting.Infrastructures.Updater;

public class WeaponUpdateFromApiHandlerTest
{
    private Mock<IUnitOfWork> _unitOfWork;
    private Mock<IDataProvider<IEnumerable<Weapon>>> _weaponParser; 
    private Mock<IRepository<Weapon>> _weaponRepository;
    private IUpdateHandler _weaponUpdateHandler;

    [SetUp]
    public void Setup()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _weaponParser = new Mock<IDataProvider<IEnumerable<Weapon>>>();
        _weaponRepository = new Mock<IRepository<Weapon>>();
        _weaponUpdateHandler = new WeaponUpdateFromApiHandler(_unitOfWork.Object, _weaponParser.Object);
    }

    [Test]
    public async Task UpdateAsync_ShouldReturnUpdateResult_WithDifEqu50()
    {
        //Arrange
        var countInDb = 150;
        var newWeaponSize = 50;
        var fixture = FixtureFactory.Fixture;
       
        List<Weapon> weaponsDb = new();
        for (int i = 0; i < countInDb; i++)
            weaponsDb.Add(fixture.Create<Weapon>());

        List<Weapon> siteWepons = new List<Weapon>(weaponsDb);
        for (int i = 0; i < newWeaponSize; i++)
            siteWepons.Add(fixture.Create<Weapon>());

        _weaponRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(weaponsDb);
        _unitOfWork.Setup(s => s.GetRepository<Weapon>()).Returns(_weaponRepository.Object);
        _weaponParser.Setup(s => s.LoadAsync()).ReturnsAsync(siteWepons);

        //Act
        var result = await _weaponUpdateHandler.UpdateAsync();

        //Assert
        result.Should().NotBeNull();
        result.Count.Should().Be((countInDb + newWeaponSize) - countInDb);

    }

    [Test]
    public async Task UpdateAsync_ShouldReturnUpdateResult_WithDifEqu0()
    {
        //Arrange
        var countInDb = 150;
        var newWeaponSize = 0;
        var fixture = FixtureFactory.Fixture;

        List<Weapon> weaponsDb = new();
        for (int i = 0; i < countInDb; i++)
            weaponsDb.Add(fixture.Create<Weapon>());

        _weaponRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(weaponsDb);
        _unitOfWork.Setup(s => s.GetRepository<Weapon>()).Returns(_weaponRepository.Object);
        _weaponParser.Setup(s => s.LoadAsync()).ReturnsAsync(weaponsDb);

        //Act
        var result = await _weaponUpdateHandler.UpdateAsync();

        //Assert
        result.Should().NotBeNull();
        result.Count.Should().Be((countInDb + newWeaponSize) - countInDb);

    }
}
