using CarModsHeaven.Data.Contracts;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Data.Repositories.Contracts;
using CarModsHeaven.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.JustMock;

namespace CarModsHeaven.Services.Tests.ProjectsServiceTests
{
    [TestClass]
    public class GetAllSortedShould
    {
        [TestMethod]
        public void CallProjectsRepoGetAllMethod()
        {
            // Arrange
            var projectsRepoMock = Mock.Create<IEfRepository<Project>>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var contextMock = Mock.Create<IUnitOfWork>();
            var sut = new ProjectsService(projectsRepoMock, usersServiceMock, contextMock);

            // Act
            sut.GetAll();

            // Assert
            Mock.Assert(() => projectsRepoMock.AllVisible, Occurs.Once());
        }

        [TestMethod]
        public void ReturnSortedProjectsByTitle()
        {
            // Arrange
            var projectsRepoMock = Mock.Create<IEfRepository<Project>>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var contextMock = Mock.Create<IUnitOfWork>();
            var sut = new ProjectsService(projectsRepoMock, usersServiceMock, contextMock);
            var projectA = new Project() { Title = "a" };
            var projectB = new Project() { Title = "b" };
            var list = new List<Project>() { projectB, projectA };
            string orderBy = "title";
            Mock.Arrange(() => projectsRepoMock.AllVisible).Returns(list.AsQueryable);

            var result = sut.GetAllSorted(orderBy);

            Assert.AreEqual("a", result.First().Title);

        }

        [TestMethod]
        public void ReturnSortedProjectsByBrand()
        {
            // Arrange
            var projectsRepoMock = Mock.Create<IEfRepository<Project>>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var contextMock = Mock.Create<IUnitOfWork>();
            var sut = new ProjectsService(projectsRepoMock, usersServiceMock, contextMock);
            var projectA = new Project() { CarBrand = "a" };
            var projectB = new Project() { CarBrand = "b" };
            var list = new List<Project>() { projectB, projectA };
            string orderBy = "brand";
            Mock.Arrange(() => projectsRepoMock.AllVisible).Returns(list.AsQueryable);

            var result = sut.GetAllSorted(orderBy);

            Assert.AreEqual("a", result.First().CarBrand);

        }

        [TestMethod]
        public void ReturnSortedProjectsByDate()
        {
            // Arrange
            var projectsRepoMock = Mock.Create<IEfRepository<Project>>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var contextMock = Mock.Create<IUnitOfWork>();
            var sut = new ProjectsService(projectsRepoMock, usersServiceMock, contextMock);
            var projectSecond = new Project() { Title = "laterAdded" , CreatedOn = new DateTime(2017, 10, 14) };
            var projectFirst = new Project() { Title = "firstAdded", CreatedOn = new DateTime(2017, 9, 10) };
            var list = new List<Project>() { projectSecond, projectFirst };
            string orderBy = "date";
            Mock.Arrange(() => projectsRepoMock.AllVisible).Returns(list.AsQueryable);

            var result = sut.GetAllSorted(orderBy);

            Assert.AreEqual("firstAdded", result.First().Title);
        }

        [TestMethod]
        public void ReturnSortedProjectsByDateWhenPassedSortStringIsNotFound()
        {
            // Arrange
            var projectsRepoMock = Mock.Create<IEfRepository<Project>>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var contextMock = Mock.Create<IUnitOfWork>();
            var sut = new ProjectsService(projectsRepoMock, usersServiceMock, contextMock);
            var projectSecond = new Project() { Title = "laterAdded", CreatedOn = new DateTime(2017, 10, 14) };
            var projectFirst = new Project() { Title = "firstAdded", CreatedOn = new DateTime(2017, 9, 10) };
            var list = new List<Project>() { projectSecond, projectFirst };
            string orderBy = "custom";
            Mock.Arrange(() => projectsRepoMock.AllVisible).Returns(list.AsQueryable);

            var result = sut.GetAllSorted(orderBy);

            Assert.AreEqual("firstAdded", result.First().Title);
        }
    }
}
