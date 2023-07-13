using AutoFixture;
using FluentAssertions;
using GenshinBuilds.Application;
using GenshinBuilds.Application.Services.Implementation;
using GenshinBuilds.Application.Services.Interfaces;
using GenshinBuilds.Domain;
using GenshinBuilds.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.UnitTesting.Application.Services;

public class WeaponInformationServiceTest
{
    private Mock<IRepository<Weapon>> _weaponRepository;
    private Mock<IUnitOfWork> _unitOfWork;
    private IWeaponInformationService _weaponInformationService;

    [SetUp]
    public void Setup()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _weaponRepository = new Mock<IRepository<Weapon>>();
        _weaponInformationService = new WeaponInformationService(_unitOfWork.Object);
    }

    [Test]
    public async Task GetAllMinimalWeaponInfo_ShouldReturn10Bbjects_NotNull()
    {
        var fixture = FixtureFactory.Fixture;
        List<Weapon> listWeapon = new();
        for (int i = 0; i < 10; i++)
            listWeapon.Add(fixture.Create<Weapon>());


        _weaponRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(listWeapon);
        _unitOfWork.Setup(u => u.GetRepository<Weapon>()).Returns(_weaponRepository.Object);

        var result = await _weaponInformationService.GetAllMinimalWeaponInfo();

        result.Should().NotBeEmpty().And.NotBeNull().And.HaveCountGreaterThan(0);
        result.First()
            .Name.Should().NotBeNull()
            .And
            .NotContain(result.Last().Name);      
    }
}
