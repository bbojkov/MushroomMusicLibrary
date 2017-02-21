using Moq;
using MusicLibrary.MVP.Presenters;
using MusicLibrary.MVP.Views;
using MusicLibrary.Services;
using NUnit.Framework;
using System;
using WebFormsMvp;

namespace MusicLibrary.Tests.MVP.BandListPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_IfBandServiceIsNull()
        {
            var viewMock = new Mock<IBandListView>();
            IBandService serviceMock = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                BandListPresenter bandPresenter = new BandListPresenter(viewMock.Object, serviceMock);
            });
        }

        [Test]
        public void NotThrow_IfBandServiceIsValid()
        {
            var viewMock = new Mock<IBandListView>();
            var serviceMock = new Mock<IBandService>();

            Assert.DoesNotThrow(() =>
            {
                BandListPresenter bandPresenter = new BandListPresenter(viewMock.Object, serviceMock.Object);
            });
        }

        [Test]
        public void CreatesAnInstance_WhenParameters_AreCorret()
        {
            var viewMock = new Mock<IBandListView>();
            var serviceMock = new Mock<IBandService>();

            BandListPresenter bandPresenter = new BandListPresenter(viewMock.Object, serviceMock.Object);

            Assert.That(bandPresenter, Is.Not.Null);
        }

        [Test]
        public void CreatesAnInstace_InheritingPresenter()
        {
            var viewMock = new Mock<IBandListView>();
            var serviceMock = new Mock<IBandService>();

            BandListPresenter bandPresenter = new BandListPresenter(viewMock.Object, serviceMock.Object);

            Assert.That(bandPresenter, Is.InstanceOf<Presenter<IBandListView>>());
        }
    }
}
