using Moq;
using MusicLibrary.Models;
using MusicLibrary.MVP.Models;
using MusicLibrary.MVP.Presenters;
using MusicLibrary.MVP.Views;
using MusicLibrary.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MusicLibrary.Tests.MVP.BandsByGenreDisplayPresenterTests
{
    [TestFixture]
    public class View_LoadGenres_Should
    {
        [Test]
        public void LoadAllGenres_WhenEventIsRaised()
        {
            var viewMock = new Mock<IBandsByGenreDisplayView>();
            viewMock.Setup(x => x.Model).Returns(new BandsByGenreDisplayModel());

            var genres = this.GetGenres();

            var genreServiceMock = new Mock<IGenreService>();
            genreServiceMock.Setup(x => x.GetAllGenres()).Returns(genres);

            var bandServiceMock = new Mock<IBandService>();

            var bandsByGenrePresenter = new BandsByGenreDisplayPresenter(
                viewMock.Object,
                genreServiceMock.Object,
                bandServiceMock.Object);

            viewMock.Raise(v => v.LoadGenres += null, EventArgs.Empty);

            CollectionAssert.AreEquivalent(genres, viewMock.Object.Model.Genres);
        }

        [Test]
        public void ReturnInstancesOfGenre_WhenEventIsRaised()
        {
            var viewMock = new Mock<IBandsByGenreDisplayView>();
            viewMock.Setup(x => x.Model).Returns(new BandsByGenreDisplayModel());

            var genres = this.GetGenres();

            var genreServiceMock = new Mock<IGenreService>();
            genreServiceMock.Setup(x => x.GetAllGenres()).Returns(genres);

            var bandServiceMock = new Mock<IBandService>();

            var bandsByGenrePresenter = new BandsByGenreDisplayPresenter(
                viewMock.Object,
                genreServiceMock.Object,
                bandServiceMock.Object);

            viewMock.Raise(v => v.LoadGenres += null, EventArgs.Empty);
            CollectionAssert.AllItemsAreInstancesOfType(viewMock.Object.Model.Genres, typeof(Genre));
        }

        public IEnumerable<Genre> GetGenres()
        {
            IList<Genre> genres = new List<Genre>()
            {
                new Genre()
                {
                    Id = Guid.NewGuid(),
                    GenreName = "Genre 1"
                },
                new Genre()
                {
                    Id = Guid.NewGuid(),
                    GenreName = "Genre 2"
                },
                new Genre()
                {
                    Id = Guid.NewGuid(),
                    GenreName = "Genre 3"
                }
            };

            return genres;
        }
    }
}
