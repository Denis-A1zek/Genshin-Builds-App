using GenshinBuilds.Application;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.IntegrationTesting;

public class UpdatesCheckerServiceTests
{
    private IUpdatesCheckerService _updatesCheckerService;
    private Mock<IUnitOfWork> _unitOfWork;

    [SetUp]
    public void Setup()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _updatesCheckerService = new UpdatesChackerService(new HtmlWeb(), _unitOfWork.Object);
    }

    [Test]
    public async Task HasUpdate_ShouldReturnTrue_WhenHaveUpdates()
    {
        var counts = new Dictionary<Type, int>()
        {
            {typeof(Character), 71 },
            {typeof(Weapon), 150 }
        };


        _unitOfWork.SetupSequence(s =>
            s.GetRepository(It.IsAny<Type>()).CountAsync())
            .ReturnsAsync(61)
            .ReturnsAsync(100);

        var result = await _updatesCheckerService.HasUpdateAsync();

        result.AvailableUpdates.Should().NotBeNullOrEmpty().And
            .HaveCountGreaterThan(1);
    }
}
