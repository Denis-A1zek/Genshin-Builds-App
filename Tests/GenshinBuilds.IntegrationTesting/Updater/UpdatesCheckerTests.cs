using GenshinBuilds.Application;
using GenshinBuilds.Parser.Updater.Checkers;
using Moq;

namespace GenshinBuilds.IntegrationTesting.Updater;

public class UpdatesCheckerTests
{
    private HtmlWeb web;
    private IUpdateChecker _weaponChecker;
    private IUpdateChecker _characterChecker;
    private Mock<IUnitOfWork> _unitOfWork;

    [SetUp]
    public void Setup()
    {
        web = new HtmlWeb();
        _unitOfWork = new Mock<IUnitOfWork>();      
        _weaponChecker = new WeaponUpdateChecker(web, _unitOfWork.Object);
        _characterChecker = new CharacterUpdateChecker(web, _unitOfWork.Object);
    }

    [Test]
    public async Task WeaponUpdater_ShouldReturnFasle_WhenTheNumberInTheDatabaseIsGreaterThenTheNumberOnTheSite()
    {
        _unitOfWork.Setup(s => s.GetRepository<Weapon>().CountAsync()).ReturnsAsync(180);

        var result = await _weaponChecker.HasUpdateAsync();

        result.Should().NotBeNull();
        result.HasUpdates.Should().BeFalse();
    }

    [Test]
    public async Task WeaponUpdater_ShouldReturnTrue_WhenTheNumberInTheDatabaseIsLessThenTheNumberOnTheSite()
    {
        _unitOfWork.Setup(s => s.GetRepository<Weapon>().CountAsync()).ReturnsAsync(120);

        var result = await _weaponChecker.HasUpdateAsync();

        result.Should().NotBeNull();
        result.HasUpdates.Should().BeTrue();
    }

    [Test]
    public async Task CharacterUpdater_ShouldReturnFasle_WhenTheNumberInTheDatabaseIsGreaterThenTheNumberOnTheSite()
    {
        _unitOfWork.Setup(s => s.GetRepository<Character>().CountAsync()).ReturnsAsync(90);

        var result = await _characterChecker.HasUpdateAsync();

        result.Should().NotBeNull();
        result.HasUpdates.Should().BeFalse();
    }

    [Test]
    public async Task CharacterUpdater_ShouldReturnTrue_WhenTheNumberInTheDatabaseIsLessThenTheNumberOnTheSite()
    {
        _unitOfWork.Setup(s => s.GetRepository<Character>().CountAsync()).ReturnsAsync(40);

        var result = await _characterChecker.HasUpdateAsync();

        result.Should().NotBeNull();
        result.HasUpdates.Should().BeTrue();
    }

    ////_unitOfWork.SetupSequence(s =>
    //    ////    s.GetRepository(It.IsAny<Type>()).CountAsync())
    //    ////    .ReturnsAsync(61)
    //    ////    .ReturnsAsync(100);
}
