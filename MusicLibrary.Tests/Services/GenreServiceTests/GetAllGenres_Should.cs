using Moq;
using MusicLibrary.Data;
using MusicLibrary.Models;
using MusicLibrary.Services;
using MusicLibrary.Tests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicLibrary.Tests.GenreServiceTests
{
    [TestFixture]
    public class GetAllGenres_Should
    {
        [Test]
        public void Returns_AllGenres()
        {
            // Arrange
            var context = new Mock<IMusicLibraryContext>();
            var genres = GetGenres();

            var expectedResult = genres.OrderBy(x => x.GenreName).AsQueryable();

            var genresSetMock = QueryableDbSetMock.GetQueryableMockDbSet(genres);

            context.Setup(x => x.Genres).Returns(genresSetMock);

            GenreService genreService = new GenreService(context.Object);

            // Act
            var actualResult = genreService.GetAllGenres();

            // Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);

        }

        [Test]
        public void ReturnTheRightCount_OfGenres()
        {
            // Arrange
            var context = new Mock<IMusicLibraryContext>();
            var genres = GetGenres();

            var expectedResult = genres.OrderBy(x => x.GenreName).AsQueryable();

            var genresSetMock = QueryableDbSetMock.GetQueryableMockDbSet(genres);

            context.Setup(x => x.Genres).Returns(genresSetMock);

            GenreService genreService = new GenreService(context.Object);

            // Act
            var actualResult = genreService.GetAllGenres();

            // Assert
            Assert.That(expectedResult.ToList().Count() == actualResult.Count());
        }

        [Test]
        public void ReturnsACollection_WithInstancesOfGenre()
        {
            // Arrange
            var context = new Mock<IMusicLibraryContext>();
            var genres = GetGenres();

            var expectedResult = genres.OrderBy(x => x.GenreName).AsQueryable();

            var genresSetMock = QueryableDbSetMock.GetQueryableMockDbSet(genres);

            context.Setup(x => x.Genres).Returns(genresSetMock);

            GenreService genreService = new GenreService(context.Object);

            // Act
            var actualResult = genreService.GetAllGenres();

            // Assert
            CollectionAssert.AllItemsAreInstancesOfType(actualResult, typeof(Genre));
        }

        private IEnumerable<Genre> GetGenres()
        {
            return new List<Genre>()
            {
                new Genre() { Id = Guid.NewGuid(), GenreName = "Techno" },
                new Genre() { Id = Guid.NewGuid(), GenreName = "Metal" },
                new Genre() { Id = Guid.NewGuid(), GenreName = "Pop" }
            };
        }
    }
}
