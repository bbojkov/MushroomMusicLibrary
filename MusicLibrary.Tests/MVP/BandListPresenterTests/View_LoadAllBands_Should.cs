using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicLibrary.MVP.Views;
using MusicLibrary.Services;
using MusicLibrary.MVP.Models;
using MusicLibrary.Models;
using MusicLibrary.MVP.Presenters;

namespace MusicLibrary.Tests.MVP.BandListPresenterTests
{
    [TestFixture]
    public class View_LoadAllBands_Should
    {
        [Test]
        public void ReturnAllBands_WhenEventIsRaised()
        {
            var viewMock = new Mock<IBandListView>();
            viewMock.Setup(v => v.Model).Returns(new BandListModel());

            var bands = GetBands();

            var bandServiceMock = new Mock<IBandService>();
            bandServiceMock.Setup(x => x.GetAllBands()).Returns(bands);

            BandListPresenter bandListPresenter = new BandListPresenter(viewMock.Object, bandServiceMock.Object);

            viewMock.Raise(v => v.LoadAllBands += null, EventArgs.Empty);

            CollectionAssert.AreEquivalent(bands, viewMock.Object.Model.Bands);
        }

        [Test]
        public void ReturnInstancesOfBand_WhenEventIsRaised()
        {
            var viewMock = new Mock<IBandListView>();
            viewMock.Setup(v => v.Model).Returns(new BandListModel());

            var bands = GetBands();

            var bandServiceMock = new Mock<IBandService>();
            bandServiceMock.Setup(x => x.GetAllBands()).Returns(bands);

            BandListPresenter bandListPresenter = new BandListPresenter(viewMock.Object, bandServiceMock.Object);

            viewMock.Raise(v => v.LoadAllBands += null, EventArgs.Empty);
            
            CollectionAssert.AllItemsAreInstancesOfType(viewMock.Object.Model.Bands, typeof(Band));
        }

        [Test]
        public void InvokeBandService_GetAllBands_Once()
        {
            var viewMock = new Mock<IBandListView>();
            viewMock.Setup(v => v.Model).Returns(new BandListModel());

            var bands = GetBands();

            var bandServiceMock = new Mock<IBandService>();
            bandServiceMock.Setup(x => x.GetAllBands()).Returns(bands);

            BandListPresenter bandListPresenter = new BandListPresenter(viewMock.Object, bandServiceMock.Object);
            viewMock.Raise(v => v.LoadAllBands += null, EventArgs.Empty);

            bandServiceMock.Verify(x => x.GetAllBands(), Times.Once());
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
