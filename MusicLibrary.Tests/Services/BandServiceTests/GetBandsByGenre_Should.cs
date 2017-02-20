using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicLibrary.Models;
using MusicLibrary.Data;
using MusicLibrary.Tests.Mocks;
using System.Data.Entity;
using MusicLibrary.Services;

namespace MusicLibrary.Tests.Services.BandServiceTests
{
    [TestFixture]
    public class GetBandsByGenre_Should
    {
        [Test]
        public void ReturnAllBands_WithGivenGenre()
        {
            var context = new Mock<IMusicLibraryContext>();
            var bands = GetBands();
            string expectedGenre = "Metal";

            var expectedResult = bands.Where(x => x.Genre.GenreName == expectedGenre);

            var bandsSetMock = QueryableDbSetMock.GetQueryableMockDbSet(bands);
            bandsSetMock.Include("Country");
            bandsSetMock.Include("Genre");

            context.Setup(x => x.Bands).Returns(bandsSetMock);

            var bandService = new BandService(context.Object);

            var actualResult = bandService.GetBandsByGenre(expectedGenre);

            CollectionAssert.AreEquivalent(expectedResult, actualResult);
        }

        [Test]
        public void DoesNotReturnBands_WithNonExistingGenre()
        {
            var context = new Mock<IMusicLibraryContext>();
            var bands = GetBands();
            string expectedGenre = "Hop";

            var expectedResult = bands.Where(x => x.Genre.GenreName == expectedGenre);

            var bandsSetMock = QueryableDbSetMock.GetQueryableMockDbSet(bands);
            bandsSetMock.Include("Country");
            bandsSetMock.Include("Genre");

            context.Setup(x => x.Bands).Returns(bandsSetMock);

            var bandService = new BandService(context.Object);

            var actualResult = bandService.GetBandsByGenre(expectedGenre);

            CollectionAssert.IsEmpty(actualResult);
        }

        [Test]
        public void ReturnTheRightCount_OfFoundBands_WithGivenGenre()
        {
            var context = new Mock<IMusicLibraryContext>();
            var bands = GetBands();
            string expectedGenre = "Metal";

            var expectedResult = bands.Where(x => x.Genre.GenreName == expectedGenre).ToList();

            var bandsSetMock = QueryableDbSetMock.GetQueryableMockDbSet(bands);
            bandsSetMock.Include("Country");
            bandsSetMock.Include("Genre");

            context.Setup(x => x.Bands).Returns(bandsSetMock);

            var bandService = new BandService(context.Object);

            var actualResult = bandService.GetBandsByGenre(expectedGenre).ToList();

            Assert.That(expectedResult.Count == actualResult.Count);
        }

        [Test]
        public void ReturnBands_WithInstanceOfBand()
        {
            var context = new Mock<IMusicLibraryContext>();
            var bands = GetBands();
            string expectedGenre = "Metal";

            var expectedResult = bands.Where(x => x.Genre.GenreName == expectedGenre);

            var bandsSetMock = QueryableDbSetMock.GetQueryableMockDbSet(bands);
            bandsSetMock.Include("Country");
            bandsSetMock.Include("Genre");

            context.Setup(x => x.Bands).Returns(bandsSetMock);

            var bandService = new BandService(context.Object);

            var actualResult = bandService.GetBandsByGenre(expectedGenre);

            CollectionAssert.AllItemsAreInstancesOfType(actualResult, typeof(Band));
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
