using GenshinBuilds.Application.Common.Builders;
using GenshinBuilds.Application;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenshinBuilds.RelationalDb;
using GenshinBuilds.Domain.Models;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;

namespace GenshinBuilds.UnitTesting.Infrastructures.Repository;

public class UnitOfWorkTest
{
    DatabaseContext dbContextMock;
    IUnitOfWork unitOfWork;

    [SetUp]
    public void Setup()
    {
        dbContextMock = FixtureFactory.CreateContext();
        unitOfWork = new UnitOfWork(dbContextMock);
    }

    [Test]
    public void GetRepositoryGeneric_ShouldReturn_WeaponRepository()
    {
        var repository = unitOfWork.GetRepository<Weapon>();

        repository.Should().NotBeNull();
    }

}
