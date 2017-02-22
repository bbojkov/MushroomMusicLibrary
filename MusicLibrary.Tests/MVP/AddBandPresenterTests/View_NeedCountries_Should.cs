namespace MusicLibrary.Tests.MVP.AddBandPresenterTests
{
    using Moq;
    using MusicLibrary.Models;
    using MusicLibrary.MVP.Models;
    using MusicLibrary.MVP.Presenters;
    using MusicLibrary.MVP.Views;
    using MusicLibrary.Services;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class View_NeedCountries_Should
    {
        [Test]
        public void NeedCountries_ShouldCallGetCountries()
        {
            //Arange
            var genreServiceMock = new Mock<IGenreService>();
            var countryServiceMock = new Mock<ICountryService>();
            var bandServiceMock = new Mock<IBandService>();
            var viewMock = new Mock<IAddBandView>();
            viewMock.Setup(x => x.Model).Returns(new AddBandModel());

            //Act
            var presenter = new AddBandPresenter(viewMock.Object, genreServiceMock.Object, countryServiceMock.Object, bandServiceMock.Object);

            // Assert
            viewMock.Raise(v => v.NeedCountries += null, EventArgs.Empty);

            countryServiceMock.Verify(s => s.GetCountries(), Times.Once());
        }

        [Test]
        public void NeedCountries_ShouldReturnCountries()
        {
            var countries = this.GetCountries();
            //Arange
            var genreServiceMock = new Mock<IGenreService>();
            var countryServiceMock = new Mock<ICountryService>();
            var bandServiceMock = new Mock<IBandService>();
            var viewMock = new Mock<IAddBandView>();
            viewMock.Setup(x => x.Model).Returns(new AddBandModel());
            countryServiceMock.Setup(s => s.GetCountries()).Returns(countries);

            //Act
            var presenter = new AddBandPresenter(viewMock.Object, genreServiceMock.Object, countryServiceMock.Object, bandServiceMock.Object);

            // Assert
            viewMock.Raise(v => v.NeedCountries += null, EventArgs.Empty);

            CollectionAssert.AreEqual(countries, presenter.View.Model.Countries);

        }

        private IEnumerable<Country> GetCountries()
        {
            return new List<Country>()
            {
                new Country() { Id = Guid.NewGuid(), CountryName = "Bulgaria" },
                new Country() { Id = Guid.NewGuid(), CountryName = "Germany" },
                new Country() { Id = Guid.NewGuid(), CountryName = "United Kingdom" },
                new Country() { Id = Guid.NewGuid(), CountryName = "India" }

            };
        }
    }
}
