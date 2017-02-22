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
    public class View_NeedGenres_Should
    {
        [Test]
        public void NeedGenres_ShouldCallGetAllGenres()
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
            viewMock.Raise(v => v.NeedGenres += null, EventArgs.Empty);

            genreServiceMock.Verify(s => s.GetAllGenres(), Times.Once());
        }

        [Test]
        public void NeedGenres_ShouldReturnGenres()
        {
            var genres = this.GetGenres();
            //Arange
            var genreServiceMock = new Mock<IGenreService>();
            var countryServiceMock = new Mock<ICountryService>();
            var bandServiceMock = new Mock<IBandService>();
            var viewMock = new Mock<IAddBandView>();
            viewMock.Setup(x => x.Model).Returns(new AddBandModel());
            genreServiceMock.Setup(s => s.GetAllGenres()).Returns(genres);

            //Act
            var presenter = new AddBandPresenter(viewMock.Object, genreServiceMock.Object, countryServiceMock.Object, bandServiceMock.Object);

            // Assert
            viewMock.Raise(v => v.NeedGenres += null, EventArgs.Empty);

            CollectionAssert.AreEqual(genres, presenter.View.Model.Genres);

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
