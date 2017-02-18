using NUnit.Framework;
using Moq;
using MusicLibrary.Data;
using MusicLibrary.Services;
using MusicLibrary.Models;
using System;
using System.Data.Entity;

namespace MusicLibrary.Tests.UserServiceTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void ReturnsNull_IfProvidedId_IsNull()
        {
            // Arrange
            var contextMock = new Mock<IMusicLibraryContext>();
            var userMock = new Mock<IDbSet<User>>();

            contextMock.Setup(x => x.Users).Returns(userMock.Object);

            string userId = null;
            User expectedUser = new User() { Id = userId };
            userMock.Setup(x => x.Find(userId)).Returns(expectedUser);

            var userService = new UserService(contextMock.Object);

            // Act
            User actualUser = userService.GetUserById(userId);

            // Assert
            Assert.IsNull(actualUser);
        }

        [Test]
        public void NotReturnNull_IfProvidedId_IsValid()
        {
            // Arrange
            var contextMock = new Mock<IMusicLibraryContext>();
            var userMock = new Mock<IDbSet<User>>();

            contextMock.Setup(x => x.Users).Returns(userMock.Object);

            var userId = Guid.NewGuid().ToString();
            User expectedUser = new User() { Id = userId };
            userMock.Setup(x => x.Find(userId)).Returns(expectedUser);

            var userService = new UserService(contextMock.Object);

            // Act
            User actualUser = userService.GetUserById(userId);

            // Assert
            Assert.IsNotNull(actualUser);
        }

        [Test]
        public void ReturnsUser_WhenIdIsValid()
        {
            // Arrange
            var contextMock = new Mock<IMusicLibraryContext>();
            var userMock = new Mock<IDbSet<User>>();

            contextMock.Setup(x => x.Users).Returns(userMock.Object);

            var userId = Guid.NewGuid().ToString();
            User expectedUser = new User() { Id = userId };
            userMock.Setup(x => x.Find(userId)).Returns(expectedUser);

            var userService = new UserService(contextMock.Object);

            // Act
            User actualUser = userService.GetUserById(userId);

            // Assert
            Assert.AreSame(expectedUser, actualUser);
        }

        [Test]
        public void Return_AnInstanceOf_User()
        {
            // Arrange
            var contextMock = new Mock<IMusicLibraryContext>();
            var userMock = new Mock<IDbSet<User>>();

            contextMock.Setup(x => x.Users).Returns(userMock.Object);

            var userId = Guid.NewGuid().ToString();
            User expectedUser = new User() { Id = userId };
            userMock.Setup(x => x.Find(userId)).Returns(expectedUser);

            var userService = new UserService(contextMock.Object);

            // Act
            User actualUser = userService.GetUserById(userId);

            // Assert
            Assert.IsInstanceOf<User>(actualUser);
        }
    }
}
