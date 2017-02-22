namespace MusicLibrary.Tests.MVP.AddBandPresenterTests
{
    using Moq;
    using MusicLibrary.MVP.Presenters;
    using MusicLibrary.MVP.Views;
    using MusicLibrary.Services;
    using NUnit.Framework;
    using System;
    using WebFormsMvp;

    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Constructor_ShouldThowsArgumentNullExceptionWhenGenreServiceIsNull()
        {
            //Arange
            IGenreService genreService = null;
            var countryServiceMock = new Mock<ICountryService>();
            var bandServiceMock = new Mock<IBandService>();
            var viewMock = new Mock<IAddBandView>();

            //Act & Assert
            Assert.That(() => new AddBandPresenter(viewMock.Object, genreService, countryServiceMock.Object, bandServiceMock.Object), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Constructor_ShouldThowsArgumentNullExceptionWhenCountryServiceIsNull()
        {
            //Arange
            var genreServiceMock = new Mock<IGenreService>();
            ICountryService countryService = null;
            var bandServiceMock = new Mock<IBandService>();
            var viewMock = new Mock<IAddBandView>();

            //Act & Assert
            Assert.That(() => new AddBandPresenter(viewMock.Object, genreServiceMock.Object, countryService, bandServiceMock.Object), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Constructor_ShouldThowsArgumentNullExceptionWhenBandServiceIsNull()
        {
            //Arange
            var genreServiceMock = new Mock<IGenreService>();
            var countryServiceMock = new Mock<ICountryService>();
            IBandService bandService = null;
            var viewMock = new Mock<IAddBandView>();

            //Act & Assert
            Assert.That(() => new AddBandPresenter(viewMock.Object, genreServiceMock.Object, countryServiceMock.Object, bandService), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Constructor_ShouldNotThrowWhenServicesAreValid()
        {
            //Arange
            var genreServiceMock = new Mock<IGenreService>();
            var countryServiceMock = new Mock<ICountryService>();
            var bandServiceMock = new Mock<IBandService>();
            var viewMock = new Mock<IAddBandView>();

            //Act & Assert
            Assert.That(() => new AddBandPresenter(viewMock.Object, genreServiceMock.Object, countryServiceMock.Object, bandServiceMock.Object), Throws.Nothing);
        }

        [Test]
        public void Constructor_ShouldCreatePresenterWhenServicesAreValid()
        {
            //Arange
            var genreServiceMock = new Mock<IGenreService>();
            var countryServiceMock = new Mock<ICountryService>();
            var bandServiceMock = new Mock<IBandService>();
            var viewMock = new Mock<IAddBandView>();

            //Act
            var presenter = new AddBandPresenter(viewMock.Object, genreServiceMock.Object, countryServiceMock.Object, bandServiceMock.Object);

            // Assert
            Assert.That(presenter, Is.InstanceOf<Presenter<IAddBandView>>());
        }
    }
}
