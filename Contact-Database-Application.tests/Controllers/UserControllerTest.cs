using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRUD_application_2.Controllers;
using CRUD_application_2.Models;
using System.Web.Mvc;

namespace CRUD_application_2.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        UserController controller = new UserController();
        User testUser = new User { Id = 1, Name = "Test User", Email = "test@example.com" };

        [TestMethod]
        public void Index()
        {
			// Arrange
			UserController.userlist.Add(testUser);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void Details()
        {
            // Arrange
            UserController.userlist.Add(testUser);
        
            // Act
            ViewResult result = controller.Details(1) as ViewResult;
            User resultUser = result.Model as User;
        
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testUser.Id, resultUser.Id);
            Assert.AreEqual(testUser.Name, resultUser.Name);
            Assert.AreEqual(testUser.Email, resultUser.Email);
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            User newUser = new User { Id = 2, Name = "New User", Email = "new@example.com" };

            // Act
            RedirectToRouteResult result = controller.Create(newUser) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Edit()
        {
			// Arrange
			UserController.userlist.Add(testUser);
            User updatedUser = new User { Id = 1, Name = "Updated User", Email = "updated@example.com" };

            // Act
            RedirectToRouteResult result = controller.Edit(1, updatedUser) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Delete()
        {
			// Arrange
			UserController.userlist.Add(testUser);

            // Act
            RedirectToRouteResult result = controller.Delete(1, new FormCollection()) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Search()
        {
			// Arrange
			UserController.userlist.Add(testUser);

            // Act
            ViewResult result = controller.Search("Test") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
        }
    }
}