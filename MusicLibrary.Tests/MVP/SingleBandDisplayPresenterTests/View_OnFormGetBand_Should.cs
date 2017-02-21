using Moq;
using MusicLibrary.Models;
using MusicLibrary.MVP.EventArguments;
using MusicLibrary.MVP.Models;
using MusicLibrary.MVP.Presenters;
using MusicLibrary.MVP.Views;
using MusicLibrary.Services;
using NUnit.Framework;
using System;

namespace MusicLibrary.Tests.MVP.SingleBandDisplayPresenterTests
{
    [TestFixture]
    public class View_OnFormGetBand_Should
    {
        [Test]
        public void ReturnBandWithGivenId_WhenEventIsRaised()
        {
            Guid bandId = Guid.NewGuid();
            var band = new Band() { Id = bandId };

            SingleBandEventArgs eventArg = new SingleBandEventArgs("user id", bandId);

            var viewMock = new Mock<ISingleBandDisplayView>();
            viewMock.Setup(x => x.Model).Returns(new SingleBandDisplayModel());

            var userServiceMock = new Mock<IUserService>();

            var bandServiceMock = new Mock<IBandService>();
            bandServiceMock.Setup(x => x.GetById(bandId)).Returns(band);

            SingleBandDisplayPresenter presenter = new SingleBandDisplayPresenter(
                viewMock.Object,
                userServiceMock.Object,
                bandServiceMock.Object);

            viewMock.Raise(x => x.OnFormGetBand += null, eventArg);

            Assert.AreEqual(band, viewMock.Object.Model.Band);
        }

        [Test]
        public void ReturnNull_WhenBandIdIsNull()
        {
            var bandId = Guid.Empty;
            var band = new Band();

            SingleBandEventArgs eventArg = new SingleBandEventArgs("user id", bandId);

            var viewMock = new Mock<ISingleBandDisplayView>();
            viewMock.Setup(x => x.Model).Returns(new SingleBandDisplayModel());

            var userServiceMock = new Mock<IUserService>();

            var bandServiceMock = new Mock<IBandService>();
            bandServiceMock.Setup(x => x.GetById(bandId)).Returns(band);

            SingleBandDisplayPresenter presenter = new SingleBandDisplayPresenter(
                viewMock.Object,
                userServiceMock.Object,
                bandServiceMock.Object);

            viewMock.Raise(x => x.OnFormGetBand += null, eventArg);

            Assert.That(viewMock.Object.Model.Band, Is.Null);
        }

        [Test]
        public void ReturnAnInstanceOfBand()
        {
            Guid bandId = Guid.NewGuid();
            var band = new Band() { Id = bandId };

            SingleBandEventArgs eventArg = new SingleBandEventArgs("user id", bandId);

            var viewMock = new Mock<ISingleBandDisplayView>();
            viewMock.Setup(x => x.Model).Returns(new SingleBandDisplayModel());

            var userServiceMock = new Mock<IUserService>();

            var bandServiceMock = new Mock<IBandService>();
            bandServiceMock.Setup(x => x.GetById(bandId)).Returns(band);

            SingleBandDisplayPresenter presenter = new SingleBandDisplayPresenter(
                viewMock.Object,
                userServiceMock.Object,
                bandServiceMock.Object);

            viewMock.Raise(x => x.OnFormGetBand += null, eventArg);

            Assert.IsInstanceOf<Band>(viewMock.Object.Model.Band);
        }
    }
}
