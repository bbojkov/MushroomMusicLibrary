using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicLibrary.MVP.Views;
using MusicLibrary.Services;
using MusicLibrary.MVP.Presenters;
using MusicLibrary.MVP.Models;
using MusicLibrary.MVP.EventArguments;
using MusicLibrary.Models;

namespace MusicLibrary.Tests.MVP.BandsByGenreDisplayPresenterTests
{
    [TestFixture]
    public class View_LoadBandsByGenre_Should
    {
        [Test]
        public void ReturnAllBands_WithTheGivenGenre()
        {
            string genre = "Metal";
            var eventArg = new BandByGenreEventArgs() { Genre = genre };

            var viewMock = new Mock<IBandsByGenreDisplayView>();
            viewMock.Setup(x => x.Model).Returns(new BandsByGenreDisplayModel());

            Guid genreId = Guid.NewGuid();
            var genreServiceMock = new Mock<IGenreService>();
            genreServiceMock.Setup(x => x.GetGenre(genreId));

            var bands = this.GetBands();
            bands.Where(x => x.Genre.GenreName == genre).ToList();

            var bandServiceMock = new Mock<IBandService>();
            bandServiceMock.Setup(x => x.GetBandsByGenre(genre)).Returns(bands);

            var bandsByGenrePresenter = new BandsByGenreDisplayPresenter(
                viewMock.Object,
                genreServiceMock.Object,
                bandServiceMock.Object);

            viewMock.Raise(x => x.LoadBandsByGenre += null, eventArg);

            CollectionAssert.AreEquivalent(bands, viewMock.Object.Model.BandsByGenre);
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
