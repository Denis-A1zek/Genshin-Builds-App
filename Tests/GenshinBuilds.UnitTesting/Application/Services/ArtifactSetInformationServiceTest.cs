using AutoFixture;
using GenshinBuilds.Application.Services.Implementation;
using GenshinBuilds.Application.Services.Interfaces;
using GenshinBuilds.Application;
using GenshinBuilds.Domain.Models;
using GenshinBuilds.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace GenshinBuilds.UnitTesting.Application.Services;

public class ArtifactSetInformationServiceTest
{
    private Mock<IRepository<ArtifactSet>> _artifactSetRepository;
    private Mock<IUnitOfWork> _unitOfWork;
    private IArtifactSetInformationService _artifactSetService;

    [SetUp]
    public void Setup()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _artifactSetRepository = new Mock<IRepository<ArtifactSet>>();
        _artifactSetService = new ArtifactSetInformationService(_unitOfWork.Object);
    }

    [Test]
    public async Task GetAllMinimalWeaponInfo_ShouldReturn10Bbjects_NotNull()
    {
        var fixture = FixtureFactory.Fixture;
        List<ArtifactSet> listWeapon = new();
        for (int i = 0; i < 10; i++)
            listWeapon.Add(fixture.Create<ArtifactSet>());


        _artifactSetRepository.Setup(r => r.Include(s => s.Artifacts)).ReturnsAsync(listWeapon);
        _unitOfWork.Setup(u => u.GetRepository<ArtifactSet>()).Returns(_artifactSetRepository.Object);

        var result = await _artifactSetService.GetAllMinimalArtifactSetInfo();

        result.Should().NotBeEmpty().And.NotBeNull().And.HaveCountGreaterThan(0);        
    }
}
