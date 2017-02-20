using System;
using System.Collections.Generic;
using System.Linq;

using Moq;
using MusicLibrary.Data;
using MusicLibrary.Models;
using MusicLibrary.Services;
using MusicLibrary.Tests.Mocks;
using NUnit.Framework;

namespace MusicLibrary.Tests.Services.BandServiceTests
{
    [TestFixture]
    public class GetBands_ByLetter_Should
    {
        [Test]
        public void ReturnTheCorrectCountOfBand_WithGivenLetter()
        {
            const string letter = "A";

            var context = new Mock<IMusicLibraryContext>();
            var bands = GetBands();

            var bandsSetMock = QueryableDbSetMock.GetQueryableMockDbSet(bands);
            var expectedResult = bands.Where(x => x.BandName.Substring(0, 1) == letter).ToList();
            int expectedCount = expectedResult.Count();
            context.Setup(x => x.Bands).Returns(bandsSetMock);

            var bandService = new BandService(context.Object);

            var actualResult = bandService.GetBands(letter);
            int actualCount = actualResult.ToList().Count();

            Assert.That(actualCount == expectedCount);
        }

        [Test]
        public void ReturnAllBand_WithTheGivenLetter()
        {
            const string letter = "A";

            var context = new Mock<IMusicLibraryContext>();
            var bands = GetBands();

            var bandsSetMock = QueryableDbSetMock.GetQueryableMockDbSet(bands);
            var expectedResult = bands.Where(x => x.BandName.Substring(0, 1) == letter).ToList();
            context.Setup(x => x.Bands).Returns(bandsSetMock);

            var bandService = new BandService(context.Object);

            var actualResult = bandService.GetBands(letter);

            CollectionAssert.AreEquivalent(actualResult.ToList(), expectedResult);
        }

        [Test]
        public void DoesNotReturnABand_WithDifferentStartingLetter()
        {
            const string letter = "A";

            var context = new Mock<IMusicLibraryContext>();
            var bands = GetBands();

            var expectedResult = bands.AsQueryable();
            var bandsSetMock = QueryableDbSetMock.GetQueryableMockDbSet(bands);
            context.Setup(x => x.Bands).Returns(bandsSetMock);

            var bandService = new BandService(context.Object);

            var actualResult = bandService.GetBands(letter);

            CollectionAssert.DoesNotContain(actualResult.ToList(), expectedResult.Where(x => x.BandName == "Behemoth"));
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
