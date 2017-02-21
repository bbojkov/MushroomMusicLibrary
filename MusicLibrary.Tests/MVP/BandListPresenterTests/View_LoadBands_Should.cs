using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicLibrary.Models;
using MusicLibrary.MVP.Views;
using MusicLibrary.MVP.Models;
using MusicLibrary.Services;
using MusicLibrary.MVP.Presenters;
using MusicLibrary.MVP.EventArguments;

namespace MusicLibrary.Tests.MVP.BandListPresenterTests
{
    [TestFixture]
    public class View_LoadBands_Should
    {
        [Test]
        public void should()
        {
            string letter = "A";
            var eventArg = new BandListEventArgs() { Letter = letter };
            
            var viewMock = new Mock<IBandListView>();
            viewMock.Setup(x => x.Model).Returns(new BandListModel());
            
            var bands = this.GetBands();
            var expectedResult = bands.Where(x => x.BandName.Substring(0, 1) == letter).ToList();

            var bandServiceMock = new Mock<IBandService>();
            bandServiceMock.Setup(x => x.GetBands(letter)).Returns(expectedResult);

            BandListPresenter bandListPresenter = new BandListPresenter(viewMock.Object, bandServiceMock.Object);

            viewMock.Raise(x => x.LoadBands += null, eventArg);

            CollectionAssert.AreEquivalent(expectedResult, viewMock.Object.Model.Bands);
            bandServiceMock.Verify(x => x.GetBands(letter), Times.Once);
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
