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
    public class AddShould
    {
        [TestMethod]
        public void ThrowWhenNullIsPassedAsEmail()
        {
            // Arrange
            var contactRepo = Mock.Create<IEfRepository<ContactEmail>>();
            var contextMock = Mock.Create<IUnitOfWork>();
            var service = new ContactService(contactRepo, contextMock);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => service.Add(null));
        }

        [TestMethod]
        public void CallRepositoryAddMethod()
        {
            // Arrange
            var contactRepo = Mock.Create<IEfRepository<ContactEmail>>();
            var contextMock = Mock.Create<IUnitOfWork>();
            var service = new ContactService(contactRepo, contextMock);
            var email = new ContactEmail();

            // Act
            service.Add(email);

            // Assert
            Mock.Assert(() => contactRepo.Add(email), Occurs.Once());
        }

        [TestMethod]
        public void CallDbContextSaveChangesMethod()
        {
            // Arrange
            var contactRepo = Mock.Create<IEfRepository<ContactEmail>>();
            var contextMock = Mock.Create<IUnitOfWork>();
            var service = new ContactService(contactRepo, contextMock);
            var email = new ContactEmail();

            // Act
            service.Add(email);

            // Assert
            Mock.Assert(() => contextMock.SaveChanges(), Occurs.Once());
        }
    }
}
