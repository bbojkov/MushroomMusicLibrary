using Moq;
using MusicLibrary.Models;
using MusicLibrary.MVP.EventArguments;
using MusicLibrary.MVP.Models;
using MusicLibrary.MVP.Presenters;
using MusicLibrary.MVP.Views;
using MusicLibrary.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MusicLibrary.Tests.MVP.SingleBandDisplayPresenterTests
{
    [TestFixture]
    public class View_AddToFavorites_Should
    {
        [Test]
        public void should()
        {
            Guid bandId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();

            User user = new User() { Id = userId.ToString(), LikedBands = new List<Band>() };
            Band band = new Band() { Id = bandId };

            SingleBandEventArgs eventArg = new SingleBandEventArgs(userId.ToString(), bandId);

            var viewMock = new Mock<ISingleBandDisplayView>();
            viewMock.Setup(x => x.Model).Returns(new SingleBandDisplayModel());

            var bandServiceMock = new Mock<IBandService>();
            bandServiceMock.Setup(x => x.GetById(bandId)).Returns(band);

            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(x => x.AddBandToFavorites(userId.ToString(), band));
            userServiceMock.Setup(x => x.GetUserById(userId.ToString())).Returns(user); 

            SingleBandDisplayPresenter presenter = new SingleBandDisplayPresenter(
                viewMock.Object,
                userServiceMock.Object,
                bandServiceMock.Object);

            viewMock.Raise(x => x.AddToFavorites += null, eventArg);


        }
    }
}
