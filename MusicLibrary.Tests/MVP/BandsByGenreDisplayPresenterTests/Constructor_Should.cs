using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicLibrary.MVP.Views;
using MusicLibrary.Services;
using MusicLibrary.MVP.Presenters;
using WebFormsMvp;

namespace MusicLibrary.Tests.MVP.BandsByGenreDisplayPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenGenreService_IsNull()
        {
            var viewMock = new Mock<IBandsByGenreDisplayView>();
            IGenreService genreServiceMock = null;
            var bandServiceMock = new Mock<IBandService>();



            Assert.Throws<ArgumentNullException>(() =>
            {
                var bandsByGenrePresenter = new BandsByGenreDisplayPresenter(
                    viewMock.Object,
                    genreServiceMock,
                    bandServiceMock.Object);
            });
        }

        [Test]
        public void ThrowArgumentNullException_WhenBandService_IsNull()
        {
            var viewMock = new Mock<IBandsByGenreDisplayView>();
            var genreService = new Mock<IGenreService>();
            IBandService bandServiceMock = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                var bandsByGenrePresenter = new BandsByGenreDisplayPresenter(
                    viewMock.Object,
                    genreService.Object,
                    bandServiceMock);
            });
        }

        [Test]
        public void NotThrow_WhenServicesAreValid()
        {
            var viewMock = new Mock<IBandsByGenreDisplayView>();
            var genreServiceMock = new Mock<IGenreService>();
            var bandServiceMock = new Mock<IBandService>();

            Assert.DoesNotThrow(() =>
            {
                var bandsByGenrePresenter = new BandsByGenreDisplayPresenter(
                    viewMock.Object,
                    genreServiceMock.Object,
                    bandServiceMock.Object);
            });
        }

        [Test]
        public void CreatesAnInstance_WhenServicesAreValud()
        {
            var viewMock = new Mock<IBandsByGenreDisplayView>();
            var genreServiceMock = new Mock<IGenreService>();
            var bandServiceMock = new Mock<IBandService>();

            var bandsByGenrePresenter = new BandsByGenreDisplayPresenter(
                viewMock.Object,
                genreServiceMock.Object,
                bandServiceMock.Object);

            Assert.That(bandsByGenrePresenter, Is.Not.Null);
        }

        [Test]
        public void CreatesAnInstace_InheritingPresenter()
        {
            var viewMock = new Mock<IBandsByGenreDisplayView>();
            var genreServiceMock = new Mock<IGenreService>();
            var bandServiceMock = new Mock<IBandService>();

            var bandsByGenrePresenter = new BandsByGenreDisplayPresenter(
                viewMock.Object,
                genreServiceMock.Object,
                bandServiceMock.Object);

            Assert.That(bandsByGenrePresenter, Is.InstanceOf<Presenter<IBandsByGenreDisplayView>>());
        }
    }
}
