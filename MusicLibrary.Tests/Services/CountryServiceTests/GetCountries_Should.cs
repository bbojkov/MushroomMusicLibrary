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
    class GetCountries_Should
    {
        [Test]
        public void GetCountries_ShouldReturnAllCountries()
        {
            // Arrange
            var countries = this.GetCountries();

            var contextMock = new Mock<IMusicLibraryContext>();
            var countriesDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(countries);
            contextMock.Setup(x => x.Countries).Returns(countriesDbSetMock);

            var countryService = new CountryService(contextMock.Object);

            // Act
            var actualResult = countryService.GetCountries();

            // Assert
            CollectionAssert.AreEquivalent(countries, actualResult);
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
