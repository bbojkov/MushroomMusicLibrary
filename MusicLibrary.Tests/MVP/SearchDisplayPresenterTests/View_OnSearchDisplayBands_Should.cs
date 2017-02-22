namespace MusicLibrary.Tests.MVP.SearchDisplayPresenterTests
{
    using Moq;
    using MusicLibrary.Models;
    using MusicLibrary.MVP.EventArguments;
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
    public class View_OnSearchDisplayBands_Should
    {
        [Test]
        public void OnSearchDisplayBands_ShouldCallSearchBandsByBandName()
        {
            string queryParam = "Killswith";

            //Arange
            var bandServiceMock = new Mock<IBandService>();
            var viewMock = new Mock<ISearchDisplayView>();
            viewMock.Setup(x => x.Model).Returns(new SearchDisplayModel());

            var eventArgs = new SearchDisplayEventArgs(queryParam);

            //Act
            var presenter = new SearchDisplayPresenter(viewMock.Object, bandServiceMock.Object);

            // Assert
            viewMock.Raise(v => v.OnSearchDisplayBands += null, eventArgs);

            bandServiceMock.Verify(s => s.SearchBandsByBandName(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void OnSearchDisplayBands_ShouldReturnBand()
        {
            string queryParam = "Killswith";
            var bands = this.GetBands();
            var expectedResult = bands.Where(b => b.BandName.Contains(queryParam));

            //Arange
            var bandServiceMock = new Mock<IBandService>();
            var viewMock = new Mock<ISearchDisplayView>();
            viewMock.Setup(x => x.Model).Returns(new SearchDisplayModel());

            var eventArgs = new SearchDisplayEventArgs(queryParam);
            bandServiceMock.Setup(s => s.SearchBandsByBandName(It.IsAny<string>())).Returns(bands.Where(b => b.BandName.Contains(queryParam)));

            //Act
            var presenter = new SearchDisplayPresenter(viewMock.Object, bandServiceMock.Object);

            // Assert
            viewMock.Raise(v => v.OnSearchDisplayBands += null, eventArgs);

            CollectionAssert.AreEqual(expectedResult, presenter.View.Model.Bands);

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
