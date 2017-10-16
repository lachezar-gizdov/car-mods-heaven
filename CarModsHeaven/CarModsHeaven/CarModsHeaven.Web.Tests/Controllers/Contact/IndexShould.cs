using CarModsHeaven.Data.Models;
using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Web.Controllers;
using CarModsHeaven.Web.Models.Contact;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Telerik.JustMock;
using TestStack.FluentMVCTesting;

namespace CarModsHeaven.Web.Tests.Controllers.Contact
{
    [TestClass]
    public class IndexShould
    {
        [TestMethod]
        public void ReturnDefaultView()
        {
            // Arrange
            var ContactServiceMock = Mock.Create<IContactService>();
            var controller = new ContactController(ContactServiceMock);

            // Act & Arrange
            controller
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void ReturnSameViewIfModelIsNotValid()
        {
            // Arrange
            var ContactServiceMock = Mock.Create<IContactService>();
            var controller = new ContactController(ContactServiceMock);
            var model = new ContactViewModel();

            // Act
            controller.ModelState.AddModelError("key", "error");

            // Assert
            controller
                .WithCallTo(c => c.Index(model))
                .ShouldRenderDefaultView();
        }
    }
}
