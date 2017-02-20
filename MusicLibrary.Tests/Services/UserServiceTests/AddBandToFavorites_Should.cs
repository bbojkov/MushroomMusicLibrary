using NUnit.Framework;
using Moq;
using System;
using MusicLibrary.Data;
using MusicLibrary.Models;
using System.Data.Entity;
using MusicLibrary.Services;

namespace MusicLibrary.Tests.Services.UserServiceTests
{
    [TestFixture]
    public class AddBandToFavorites_Should
    {
        [Test]
        public void CallSaveChanges_Once()
        {
            var contextMock = new Mock<IMusicLibraryContext>();
            var userMock = new Mock<IDbSet<User>>();
            var bandMock = new Mock<Band>();

            contextMock.Setup(x => x.Users).Returns(userMock.Object);

            var userId = Guid.NewGuid().ToString();
            User expectedUser = new User() { Id = userId };
            userMock.Setup(x => x.Find(userId)).Returns(expectedUser);

            var userService = new UserService(contextMock.Object);

            userService.AddBandToFavorites(userId, bandMock.Object);

            contextMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public void AddTheBand_ToTheUserLikesCollection()
        {
            var contextMock = new Mock<IMusicLibraryContext>();
            var userMock = new Mock<IDbSet<User>>();
            var bandMock = new Mock<Band>();

            contextMock.Setup(x => x.Users).Returns(userMock.Object);

            var userId = Guid.NewGuid().ToString();
            User expectedUser = new User() { Id = userId };
            userMock.Setup(x => x.Find(userId)).Returns(expectedUser);

            var userService = new UserService(contextMock.Object);

            userService.AddBandToFavorites(userId, bandMock.Object);
            
            CollectionAssert.Contains(expectedUser.LikedBands, bandMock.Object);
        }

        [Test]
        public void AddTheBandToUserLikesCollection_AndHaveTheRightCount()
        {
            var contextMock = new Mock<IMusicLibraryContext>();
            var userMock = new Mock<IDbSet<User>>();
            var bandMock = new Mock<Band>();

            contextMock.Setup(x => x.Users).Returns(userMock.Object);

            var userId = Guid.NewGuid().ToString();
            User expectedUser = new User() { Id = userId };
            userMock.Setup(x => x.Find(userId)).Returns(expectedUser);

            var userService = new UserService(contextMock.Object);

            userService.AddBandToFavorites(userId, bandMock.Object);

            Assert.That(expectedUser.LikedBands.Count == 1);
        }
        
        //[Test]
        //public void ThrowException_IfBandIsNull()
        //{
        //    var contextMock = new Mock<IMusicLibraryContext>();
        //    var userMock = new Mock<IDbSet<User>>();
        //    Band bandMock = null;

        //    contextMock.Setup(x => x.Users).Returns(userMock.Object);

        //    var userId = Guid.NewGuid().ToString();
        //    User expectedUser = new User() { Id = userId };
        //    userMock.Setup(x => x.Find(userId)).Returns(expectedUser);

        //    var userService = new UserService(contextMock.Object);

        //    Assert.Throws<NullReferenceException>(() =>
        //    {
        //        userService.AddBandToFavorites(userId, bandMock);
        //    });
        //}
    }
}