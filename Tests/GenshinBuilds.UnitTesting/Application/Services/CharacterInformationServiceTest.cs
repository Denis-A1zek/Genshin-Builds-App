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

namespace GenshinBuilds.UnitTesting.Application.Services
{
    public class CharacterSetInformationServiceTest
    {
        private Mock<IRepository<Character>> _characterRepository;
        private Mock<IUnitOfWork> _unitOfWork;
        private ICharacterInformationService _weaponInformationService;

        [SetUp]
        public void Setup()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _characterRepository = new Mock<IRepository<Character>>();
            _weaponInformationService = new CharacterInformationService(_unitOfWork.Object);
        }

        [Test]
        public async Task GetAllMinimalWeaponInfo_ShouldReturn10Bbjects_NotNull()
        {
            var fixture = FixtureFactory.Fixture;
            List<Character> listWeapon = new();
            for (int i = 0; i < 10; i++)
                listWeapon.Add(fixture.Create<Character>());


            _characterRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(listWeapon);
            _unitOfWork.Setup(u => u.GetRepository<Character>()).Returns(_characterRepository.Object);

            var result = await _weaponInformationService.GetAllMinimalCharacterInfo();

            result.Should().NotBeEmpty().And.NotBeNull().And.HaveCountGreaterThan(0);
            result.First()
                .Name.Should().NotBeNull()
                .And
                .NotContain(result.Last().Name);
        }
    }
}
