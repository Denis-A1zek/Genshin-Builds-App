using AutoFixture;
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
using FluentAssertions;

namespace GenshinBuilds.UnitTesting.Infrastructures.Updater;

public class CharacterUpdateHandlerTest
{
    private Mock<IUnitOfWork> _unitOfWork;
    private Mock<IParser<IEnumerable<Character>>> _characterParser;
    private Mock<IRepository<Character>> _characterRepository;
    private IUpdateHandler _characterUpdateHandler;

    [SetUp]
    public void Setup()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _characterParser = new Mock<IParser<IEnumerable<Character>>>();
        _characterRepository = new Mock<IRepository<Character>>();
        _characterUpdateHandler = new CharacterUpdateHandler(_unitOfWork.Object, _characterParser.Object);
    }

    [Test]
    public async Task UpdateAsync_ShouldReturnUpdateResult_WithDifEqu50()
    {
        //Arrange
        var countInDb = 150;
        var newCharacterSize = 50;
        var fixture = FixtureFactory.Fixture;

        List<Character> characterDb = new();
        for (int i = 0; i < countInDb; i++)
            characterDb.Add(fixture.Create<Character>());

        List<Character> characterInSity = new List<Character>(characterDb);
        for (int i = 0; i < newCharacterSize; i++)
            characterInSity.Add(fixture.Create<Character>());

        _characterRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(characterDb);
        _unitOfWork.Setup(s => s.GetRepository<Character>()).Returns(_characterRepository.Object);
        _characterParser.Setup(s => s.LoadAsync()).ReturnsAsync(characterInSity);

        //Act
        var result = await _characterUpdateHandler.UpdateAsync();

        //Assert
        result.Should().NotBeNull();
        result.Count.Should().Be((countInDb + newCharacterSize) - countInDb);

    }

    [Test]
    public async Task UpdateAsync_ShouldReturnUpdateResult_WithDifEqu0()
    {
        //Arrange
        var countInDb = 150;
        var newCharacterSize = 0;
        var fixture = FixtureFactory.Fixture;

        List<Character> characterDb = new();
        for (int i = 0; i < countInDb; i++)
            characterDb.Add(fixture.Create<Character>());

        _characterRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(characterDb);
        _unitOfWork.Setup(s => s.GetRepository<Character>()).Returns(_characterRepository.Object);
        _characterParser.Setup(s => s.LoadAsync()).ReturnsAsync(characterDb);

        //Act
        var result = await _characterUpdateHandler.UpdateAsync();

        //Assert
        result.Should().NotBeNull();
        result.Count.Should().Be((countInDb + newCharacterSize) - countInDb);

    }
}
