namespace MusicLibrary.Tests.Services.CountryServiceTests
{
    using Data;
    using Mocks;
    using Moq;
    using MusicLibrary.Models;
    using MusicLibrary.Services;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    class GetById_Should
    {
        [Test]
        public void GetCountry_ShouldReturnCorrectCountry()
        {
            // Arrange
            var country = new Country() { Id = Guid.NewGuid(), CountryName = "Bulgaria" };

            var contextMock = new Mock<IMusicLibraryContext>();
            var countriesDbSetMock = new Mock<IDbSet<Country>>();
            countriesDbSetMock.Setup(x => x.Find(It.Is<Guid>(g => g == country.Id))).Returns(country);
            contextMock.Setup(x => x.Countries).Returns(countriesDbSetMock.Object);

            var countryService = new CountryService(contextMock.Object);

            // Act
            var countryId = country.Id;
            var actualResult = countryService.GetById(countryId);

            // Assert
            Assert.That(actualResult, Is.SameAs(country));

        }

        [Test]
        public void GetCountry_ShouldReturnNullWhenCountryIsNotFound()
        {
            // Arrange
            var country = new Country() { Id = Guid.NewGuid(), CountryName = "Bulgaria" };
            var anotherCountry = new Country() { Id = Guid.NewGuid(), CountryName = "Absurdistan" };


            var contextMock = new Mock<IMusicLibraryContext>();
            var countriesDbSetMock = new Mock<IDbSet<Country>>();
            countriesDbSetMock.Setup(x => x.Find(It.Is<Guid>(g => g == country.Id))).Returns(country);
            contextMock.Setup(x => x.Countries).Returns(countriesDbSetMock.Object);

            var countryService = new CountryService(contextMock.Object);

            // Act
            var countryId = anotherCountry.Id;
            var actualResult = countryService.GetById(countryId);

            // Assert
            Assert.That(actualResult, Is.Null);

        }
    }
}
