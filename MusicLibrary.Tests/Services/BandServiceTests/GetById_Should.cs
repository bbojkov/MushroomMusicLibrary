using NUnit.Framework;
using Moq;
using System;
using MusicLibrary.Data;
using MusicLibrary.Models;
using System.Data.Entity;
using MusicLibrary.Services;
using MusicLibrary.Models.Factories;

namespace MusicLibrary.Tests.Services.BandServiceTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void ReturnBand_WhenIdIsValid()
        {
            var contextMock = new Mock<IMusicLibraryContext>();
            var contextBaseMock = new Mock<IMusicLibraryBaseContext>();
            var countryServiceMock = new Mock<ICountryService>();
            var genreServiceMock = new Mock<IGenreService>();
            var userServiceMock = new Mock<IUserService>();
            var bandFactoryMock = new Mock<IBandFactory>();
            var bandMock = new Mock<IDbSet<Band>>();

            contextMock.Setup(x => x.Bands).Returns(bandMock.Object);

            Guid bandId = Guid.NewGuid();
            Band expectedBand = new Band() { Id = bandId };
            bandMock.Setup(x => x.Find(bandId)).Returns(expectedBand);

            var bandService = new BandService(
                contextMock.Object,
                contextBaseMock.Object,
                countryServiceMock.Object,
                genreServiceMock.Object,
                userServiceMock.Object,
                bandFactoryMock.Object);

            Band actualBand = bandService.GetById(bandId);

            Assert.AreSame(expectedBand, actualBand);
        }

        [Test]
        public void Returns_AnInstanceOf_Band()
        {
            var contextMock = new Mock<IMusicLibraryContext>();
            var contextBaseMock = new Mock<IMusicLibraryBaseContext>();
            var countryServiceMock = new Mock<ICountryService>();
            var genreServiceMock = new Mock<IGenreService>();
            var userServiceMock = new Mock<IUserService>();
            var bandFactoryMock = new Mock<IBandFactory>();
            var bandMock = new Mock<IDbSet<Band>>();

            contextMock.Setup(x => x.Bands).Returns(bandMock.Object);

            Guid bandId = Guid.NewGuid();
            Band expectedBand = new Band() { Id = bandId };
            bandMock.Setup(x => x.Find(bandId)).Returns(expectedBand);

            var bandService = new BandService(
                contextMock.Object,
                contextBaseMock.Object,
                countryServiceMock.Object,
                genreServiceMock.Object,
                userServiceMock.Object,
                bandFactoryMock.Object);

            Band actualBand = bandService.GetById(bandId);

            Assert.IsInstanceOf<Band>(actualBand);
        }
    }
}
