using Moq;
using MusicLibrary.MVP.Presenters;
using MusicLibrary.MVP.Views;
using MusicLibrary.Services;
using NUnit.Framework;
using System;
using WebFormsMvp;

namespace MusicLibrary.Tests.MVP.SingleBandDisplayPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullExpection_WhenUserServiceIsNull()
        {
            var viewMock = new Mock<ISingleBandDisplayView>();
            IUserService userServiceMock = null;
            var bandServiceMock = new Mock<IBandService>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                SingleBandDisplayPresenter presenter = new SingleBandDisplayPresenter(
                    viewMock.Object,
                    userServiceMock,
                    bandServiceMock.Object);
            });
        }

        [Test]
        public void ThrowArgumentNullException_WhenBandServiceIsNull()
        {
            var viewMock = new Mock<ISingleBandDisplayView>();
            var userServiceMock = new Mock<IUserService>();
            IBandService bandServiceMock = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                SingleBandDisplayPresenter presenter = new SingleBandDisplayPresenter(
                    viewMock.Object,
                    userServiceMock.Object,
                    bandServiceMock);
            });
        }

        [Test]
        public void DoesNotThrow_WhenServicesAreValid()
        {
            var viewMock = new Mock<ISingleBandDisplayView>();
            var userServiceMock = new Mock<IUserService>();
            var bandServiceMock = new Mock<IBandService>();

            Assert.DoesNotThrow(() =>
            {
                SingleBandDisplayPresenter presenter = new SingleBandDisplayPresenter(
                    viewMock.Object,
                    userServiceMock.Object,
                    bandServiceMock.Object);
            });
        }

        [Test]
        public void CreatesAnInstance_WhenServices_AreValid()
        {
            var viewMock = new Mock<ISingleBandDisplayView>();
            var userServiceMock = new Mock<IUserService>();
            var bandServiceMock = new Mock<IBandService>();

            SingleBandDisplayPresenter presenter = new SingleBandDisplayPresenter(
                viewMock.Object,
                userServiceMock.Object,
                bandServiceMock.Object);

            Assert.That(presenter, Is.Not.Null);
        }

        [Test]
        public void CreatesAnInstaceOfPresenter()
        {
            var viewMock = new Mock<ISingleBandDisplayView>();
            var userServiceMock = new Mock<IUserService>();
            var bandServiceMock = new Mock<IBandService>();

            SingleBandDisplayPresenter presenter = new SingleBandDisplayPresenter(
                viewMock.Object,
                userServiceMock.Object,
                bandServiceMock.Object);

            Assert.That(presenter, Is.InstanceOf<Presenter<ISingleBandDisplayView>>());
        }
    }
}
