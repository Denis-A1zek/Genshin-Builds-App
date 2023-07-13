using GenshinBuilds.Application;
using GenshinBuilds.Domain.Models;
using GenshinBuilds.Domain;
using GenshinBuilds.Parser.Updater.Handlers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenshinBuilds.Application.Interfaces;
using GenshinBuilds.Application.Common.Models;
using AutoFixture;
using FluentAssertions;
using GenshinBuilds.Updater;

namespace GenshinBuilds.UnitTesting.Infrastructures.Updater
{
    public class DataUpdateManagerTest
    {
        private Mock<IUpdateChecker> _weaponChecker;
        private Mock<IUpdateChecker> _characterChecker;

        private Mock<IUpdateHandler> _weaponUpdateHandler;

        private IDataUpdateManager _dataUpdateManager;

        [SetUp]
        public void Setup()
        {
            _weaponChecker = new Mock<IUpdateChecker>();
            _characterChecker = new Mock<IUpdateChecker>();

            _weaponUpdateHandler = new Mock<IUpdateHandler>();

            _dataUpdateManager = new GenshinBuilds.Updater.DataUpdateManager(new List<IUpdateHandler>()
            {
                _weaponUpdateHandler.Object
            });
        }

        [Test]
        public async Task Test2()
        {
            var fixture = FixtureFactory.Fixture;
            _weaponUpdateHandler.Setup(s => s.UpdateAsync(false)).ReturnsAsync(fixture.Create<UpdateResult>());

            var result = await _dataUpdateManager.Update();

            result.Should().NotBeNull();
        }
    }
}
