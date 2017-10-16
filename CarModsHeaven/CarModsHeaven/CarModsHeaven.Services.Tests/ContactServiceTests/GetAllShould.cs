using CarModsHeaven.Data.Contracts;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Data.Repositories.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.JustMock;

namespace CarModsHeaven.Services.Tests.ContactServiceTests
{
    [TestClass]
    public class GetAllShould
    {
        [TestMethod]
        public void CallProjectsRepoGetAllVisibleMethod()
        {
            // Arrange
            var contactRepo = Mock.Create<IEfRepository<ContactEmail>>();
            var contextMock = Mock.Create<IUnitOfWork>();
            var service = new ContactService(contactRepo, contextMock);

            // Act
            service.GetAll();

            // Assert
            Mock.Assert(() => contactRepo.AllVisible, Occurs.Once());
        }
    }
}
