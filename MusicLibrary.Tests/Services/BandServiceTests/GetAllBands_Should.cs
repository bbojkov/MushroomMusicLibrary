using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using MusicLibrary.Models;
using System;
using MusicLibrary.Data;
using System.Linq;
using MusicLibrary.Tests.Mocks;
using MusicLibrary.Services;
using System.Data.Entity;
using MusicLibrary.Models.Factories;

namespace MusicLibrary.Tests.Services.BandServiceTests
{
    [TestFixture]
    public class GetAllBands_Should
    {
        [Test]
        public void ReturnAllBands_WithIncludedCountryAndGenre()
        {
            var contextMock = new Mock<IMusicLibraryContext>();
            var contextBaseMock = new Mock<IMusicLibraryBaseContext>();
            var countryServiceMock = new Mock<ICountryService>();
            var genreServiceMock = new Mock<IGenreService>();
            var userServiceMock = new Mock<IUserService>();
            var bandFactoryMock = new Mock<IBandFactory>();
            var bands = GetBands();

            var expectedResult = bands.AsQueryable();
            var bandsSetMock = QueryableDbSetMock.GetQueryableMockDbSet(bands);
            bandsSetMock.Include("Country");
            bandsSetMock.Include("Genre");

            contextMock.Setup(x => x.Bands).Returns(bandsSetMock);

            var bandService = new BandService(
                contextMock.Object, 
                contextBaseMock.Object, 
                countryServiceMock.Object,
                genreServiceMock.Object, 
                userServiceMock.Object, 
                bandFactoryMock.Object);

            var bandResultSet = bandService.GetAllBands();

            CollectionAssert.AreEquivalent(expectedResult, bandResultSet.ToList());
        }

        [Test]
        public void DoesNotReturnsBands_WithoutIncludingCountry()
        {
            var contextMock = new Mock<IMusicLibraryContext>();
            var contextBaseMock = new Mock<IMusicLibraryBaseContext>();
            var countryServiceMock = new Mock<ICountryService>();
            var genreServiceMock = new Mock<IGenreService>();
            var userServiceMock = new Mock<IUserService>();
            var bandFactoryMock = new Mock<IBandFactory>();
            var bands = GetBands();

            var expectedResult = bands.Where(x => x.Country.CountryName.Contains("Finland")).AsQueryable();
            var bandsSetMock = QueryableDbSetMock.GetQueryableMockDbSet(bands);

            contextMock.Setup(x => x.Bands).Returns(bandsSetMock);

            var bandService = new BandService(
                       contextMock.Object,
                       contextBaseMock.Object,
                       countryServiceMock.Object,
                       genreServiceMock.Object,
                       userServiceMock.Object,
                       bandFactoryMock.Object);

            var bandResultSet = bandService.GetAllBands();

            CollectionAssert.AreNotEquivalent(expectedResult, bandResultSet.ToList());
        }

        [Test]
        public void DoesNotReturnsBands_WithoutIncludingGenre()
        {
            var contextMock = new Mock<IMusicLibraryContext>();
            var contextBaseMock = new Mock<IMusicLibraryBaseContext>();
            var countryServiceMock = new Mock<ICountryService>();
            var genreServiceMock = new Mock<IGenreService>();
            var userServiceMock = new Mock<IUserService>();
            var bandFactoryMock = new Mock<IBandFactory>();
            var bands = GetBands();

            var expectedResult = bands.Where(x => x.Genre.GenreName.Contains("Metal")).AsQueryable();
            var bandsSetMock = QueryableDbSetMock.GetQueryableMockDbSet(bands);

            contextMock.Setup(x => x.Bands).Returns(bandsSetMock);

            var bandService = new BandService(
                       contextMock.Object,
                       contextBaseMock.Object,
                       countryServiceMock.Object,
                       genreServiceMock.Object,
                       userServiceMock.Object,
                       bandFactoryMock.Object);

            var bandResultSet = bandService.GetAllBands();

            CollectionAssert.AreNotEquivalent(expectedResult, bandResultSet.ToList());
        }

        [Test]
        public void ReturnedBands_AreAllInstancesOfBand()
        {
            var contextMock = new Mock<IMusicLibraryContext>();
            var contextBaseMock = new Mock<IMusicLibraryBaseContext>();
            var countryServiceMock = new Mock<ICountryService>();
            var genreServiceMock = new Mock<IGenreService>();
            var userServiceMock = new Mock<IUserService>();
            var bandFactoryMock = new Mock<IBandFactory>();
            var bands = GetBands();

            var expectedResult = bands.AsQueryable();
            var bandsSetMock = QueryableDbSetMock.GetQueryableMockDbSet(bands);
            bandsSetMock.Include("Country");
            bandsSetMock.Include("Genre");

            contextMock.Setup(x => x.Bands).Returns(bandsSetMock);

            var bandService = new BandService(
                       contextMock.Object,
                       contextBaseMock.Object,
                       countryServiceMock.Object,
                       genreServiceMock.Object,
                       userServiceMock.Object,
                       bandFactoryMock.Object);

            var bandResultSet = bandService.GetAllBands().ToList();

            CollectionAssert.AllItemsAreInstancesOfType(bandResultSet, typeof(Band));
        }

        public IEnumerable<Band> GetBands()
        {
            IList<Band> bands = new List<Band>()
            {
                new Band()
                {
                    Id = Guid.NewGuid(),
                    BandName = "A day to remember",
                    Country = new Country() { Id = Guid.NewGuid(), CountryName = "USA" },
                    Genre = new Genre() { Id = Guid.NewGuid(), GenreName = "Metal" }
                },
                new Band()
                {
                    Id = Guid.NewGuid(),
                    BandName = "Killswith Engage",
                    Country = new Country() { Id = Guid.NewGuid(), CountryName = "USA" },
                    Genre = new Genre() { Id = Guid.NewGuid(), GenreName = "Metal" }
                },
                new Band()
                {
                    Id = Guid.NewGuid(),
                    BandName = "Aerosmith",
                    Country = new Country() {Id = Guid.NewGuid(), CountryName = "USA" },
                    Genre =new Genre() { Id = Guid.NewGuid(), GenreName = "Grindcore" }
                },
                new Band()
                {
                    Id = Guid.NewGuid(),
                    BandName = "Behemoth",
                    Country = new Country() { Id = Guid.NewGuid(), CountryName = "Finland" },
                    Genre = new Genre() { Id = Guid.NewGuid(), GenreName = "Pop" }
                }
            };

            return bands;
        }
    }

}
