namespace MusicLibrary.Tests.Services.BandServiceTests
{
    using Data;
    using Mocks;
    using Moq;
    using MusicLibrary.Models;
    using MusicLibrary.Models.Factories;
    using MusicLibrary.Services;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class RegisterNewBand_Should
    {
        [Test]
        public void RegisterNewBand_ShouldCallTheAddMethod()
        {
            var genreData = new Genre() { Id = Guid.NewGuid(), GenreName = "Metal" };
            var countryData = new Country() { Id = Guid.NewGuid(), CountryName = "Bulgaria" };
            var band = new Band();

            var contextMock = new Mock<IMusicLibraryContext>();
            var contextBaseMock = new Mock<IMusicLibraryBaseContext>();
            var countryServiceMock = new Mock<ICountryService>();
            var genreServiceMock = new Mock<IGenreService>();
            var userServiceMock = new Mock<IUserService>();
            var bandFactoryMock = new Mock<IBandFactory>();

            countryServiceMock.Setup(x => x.GetById(It.Is<Guid>(g => g == countryData.Id))).Returns(countryData);
            genreServiceMock.Setup(x => x.GetGenre(It.Is<Guid>(g => g == genreData.Id))).Returns(genreData);
            bandFactoryMock.Setup(x => x.CreateBandInstance()).Returns(band);

            var bandDbList = new List<Band>();
            var bandDbSetMock = new Mock<IDbSet<Band>>();
            bandDbSetMock.Setup(set => set.Add(It.IsAny<Band>())).Callback((Band b) => bandDbList.Add(b));
            contextMock.Setup(x => x.Bands).Returns(bandDbSetMock.Object).Verifiable();

            string bandName = "SomeBandName";
            int formationYear = 2016;
            Guid countryId = countryData.Id;
            Guid genreId = genreData.Id;

            var bandService = new BandService(
                contextMock.Object,
                contextBaseMock.Object,
                countryServiceMock.Object,
                genreServiceMock.Object,
                userServiceMock.Object,
                bandFactoryMock.Object);

            bandService.RegisterNewBand(bandName, formationYear, genreId, countryId);

            bandDbSetMock.Verify(mock => mock.Add(It.IsAny<Band>()), Times.Once());
            //contextMock.Verify(mock => mock.Bands.Add(It.IsAny<Band>()), Times.Once());


        }

        [Test]
        public void RegisterNewBand_CanAddBand()
        {
            var genreData = new Genre() { Id = Guid.NewGuid(), GenreName = "Metal" };
            var countryData = new Country() { Id = Guid.NewGuid(), CountryName = "Bulgaria" };
            var band = new Band();

            var contextMock = new Mock<IMusicLibraryContext>();
            var contextBaseMock = new Mock<IMusicLibraryBaseContext>();
            var countryServiceMock = new Mock<ICountryService>();
            var genreServiceMock = new Mock<IGenreService>();
            var userServiceMock = new Mock<IUserService>();
            var bandFactoryMock = new Mock<IBandFactory>();

            countryServiceMock.Setup(x => x.GetById(It.Is<Guid>(g => g == countryData.Id))).Returns(countryData);
            genreServiceMock.Setup(x => x.GetGenre(It.Is<Guid>(g => g == genreData.Id))).Returns(genreData);
            bandFactoryMock.Setup(x => x.CreateBandInstance()).Returns(band);

            var bandDbList = new List<Band>();
            var bandDbSetMock = new Mock<IDbSet<Band>>();
            bandDbSetMock.Setup(set => set.Add(It.IsAny<Band>())).Callback((Band b) => bandDbList.Add(b));
            contextMock.Setup(x => x.Bands).Returns(bandDbSetMock.Object);

            string bandName = "SomeBandName";
            int formationYear = 2016;
            Guid countryId = countryData.Id;
            Guid genreId = genreData.Id;

            var bandService = new BandService(
                contextMock.Object,
                contextBaseMock.Object,
                countryServiceMock.Object,
                genreServiceMock.Object,
                userServiceMock.Object,
                bandFactoryMock.Object);

            bandService.RegisterNewBand(bandName, formationYear, genreId, countryId);

            Assert.That(bandDbList.Count(), Is.EqualTo(1));
            Assert.That(bandDbList[0].Genre, Is.SameAs(genreData));
            Assert.That(bandDbList[0].Country, Is.SameAs(countryData));
        }

        [TestCase("")]
        [TestCase(null)]
        public void RegisterNewBand_ThowsArgumentNullExceptionWhenBandNameIsEmptyOrNull(string bandName)
        {
            var genreData = new Genre() { Id = Guid.NewGuid(), GenreName = "Metal" };
            var countryData = new Country() { Id = Guid.NewGuid(), CountryName = "Bulgaria" };
            var band = new Band();

            var contextMock = new Mock<IMusicLibraryContext>();
            var contextBaseMock = new Mock<IMusicLibraryBaseContext>();
            var countryServiceMock = new Mock<ICountryService>();
            var genreServiceMock = new Mock<IGenreService>();
            var userServiceMock = new Mock<IUserService>();
            var bandFactoryMock = new Mock<IBandFactory>();

            countryServiceMock.Setup(x => x.GetById(It.Is<Guid>(g => g == countryData.Id))).Returns(countryData);
            genreServiceMock.Setup(x => x.GetGenre(It.Is<Guid>(g => g == genreData.Id))).Returns(genreData);
            bandFactoryMock.Setup(x => x.CreateBandInstance()).Returns(band);

            var bandDbList = new List<Band>();
            var bandDbSetMock = new Mock<IDbSet<Band>>();
            bandDbSetMock.Setup(set => set.Add(It.IsAny<Band>())).Callback((Band b) => bandDbList.Add(b));
            contextMock.Setup(x => x.Bands).Returns(bandDbSetMock.Object).Verifiable();

            int formationYear = 2016;
            Guid countryId = countryData.Id;
            Guid genreId = genreData.Id;

            var bandService = new BandService(
                contextMock.Object,
                contextBaseMock.Object,
                countryServiceMock.Object,
                genreServiceMock.Object,
                userServiceMock.Object,
                bandFactoryMock.Object);

            Assert.That(() => bandService.RegisterNewBand(bandName, formationYear, genreId, countryId), Throws.Exception.TypeOf<ArgumentNullException>());
            Assert.That(() => bandService.RegisterNewBand(bandName, formationYear, genreId, countryId), Throws.Exception.Message.Contains("Parameter name: bandName"));
        }

        [Test]
        public void RegisterNewBand_CreatesEmptyBandInstance()
        {
            var genreData = new Genre() { Id = Guid.NewGuid(), GenreName = "Metal" };
            var countryData = new Country() { Id = Guid.NewGuid(), CountryName = "Bulgaria" };
            var band = new Band();

            var contextMock = new Mock<IMusicLibraryContext>();
            var contextBaseMock = new Mock<IMusicLibraryBaseContext>();
            var countryServiceMock = new Mock<ICountryService>();
            var genreServiceMock = new Mock<IGenreService>();
            var userServiceMock = new Mock<IUserService>();
            var bandFactoryMock = new Mock<IBandFactory>();

            countryServiceMock.Setup(x => x.GetById(It.Is<Guid>(g => g == countryData.Id))).Returns(countryData);
            genreServiceMock.Setup(x => x.GetGenre(It.Is<Guid>(g => g == genreData.Id))).Returns(genreData);
            bandFactoryMock.Setup(x => x.CreateBandInstance()).Returns(band);

            var bandDbList = new List<Band>();
            var bandDbSetMock = new Mock<IDbSet<Band>>();
            bandDbSetMock.Setup(set => set.Add(It.IsAny<Band>())).Callback((Band b) => bandDbList.Add(b));
            contextMock.Setup(x => x.Bands).Returns(bandDbSetMock.Object);

            string bandName = "SomeBandName";
            int formationYear = 2016;
            Guid countryId = countryData.Id;
            Guid genreId = genreData.Id;

            var bandService = new BandService(
                contextMock.Object,
                contextBaseMock.Object,
                countryServiceMock.Object,
                genreServiceMock.Object,
                userServiceMock.Object,
                bandFactoryMock.Object);


            bandService.RegisterNewBand(bandName, formationYear, genreId, countryId);

            bandFactoryMock.Verify(mock => mock.CreateBandInstance(), Times.Once());
        }

        [Test]
        public void RegisterNewBand_ThrowsArgumentNullExceptionWhenNoCountryIsReturned()
        {
            var genreData = new Genre() { Id = Guid.NewGuid(), GenreName = "Metal" };
            var countryData = new Country() { Id = Guid.NewGuid(), CountryName = "Bulgaria" };
            var band = new Band();

            var contextMock = new Mock<IMusicLibraryContext>();
            var contextBaseMock = new Mock<IMusicLibraryBaseContext>();
            var countryServiceMock = new Mock<ICountryService>();
            var genreServiceMock = new Mock<IGenreService>();
            var userServiceMock = new Mock<IUserService>();
            var bandFactoryMock = new Mock<IBandFactory>();

            countryServiceMock.Setup(x => x.GetById(It.Is<Guid>(g => g == countryData.Id))).Returns(countryData);
            genreServiceMock.Setup(x => x.GetGenre(It.Is<Guid>(g => g == genreData.Id))).Returns(genreData);
            bandFactoryMock.Setup(x => x.CreateBandInstance()).Returns(band);

            var bandDbList = new List<Band>();
            var bandDbSetMock = new Mock<IDbSet<Band>>();
            bandDbSetMock.Setup(set => set.Add(It.IsAny<Band>())).Callback((Band b) => bandDbList.Add(b));
            contextMock.Setup(x => x.Bands).Returns(bandDbSetMock.Object);

            string bandName = "SomeBandName";
            int formationYear = 2016;
            Guid countryId = Guid.NewGuid();
            Guid genreId = genreData.Id;

            var bandService = new BandService(
                contextMock.Object,
                contextBaseMock.Object,
                countryServiceMock.Object,
                genreServiceMock.Object,
                userServiceMock.Object,
                bandFactoryMock.Object);

            Assert.That(() => bandService.RegisterNewBand(bandName, formationYear, genreId, countryId), Throws.Exception.TypeOf<ArgumentNullException>());
            Assert.That(() => bandService.RegisterNewBand(bandName, formationYear, genreId, countryId), Throws.Exception.Message.Contains("Parameter name: country"));
        }

        public void RegisterNewBand_ThrowsArgumentNullExceptionWhenNoGenreIsReturned()
        {
            var genreData = new Genre() { Id = Guid.NewGuid(), GenreName = "Metal" };
            var countryData = new Country() { Id = Guid.NewGuid(), CountryName = "Bulgaria" };
            var band = new Band();

            var contextMock = new Mock<IMusicLibraryContext>();
            var contextBaseMock = new Mock<IMusicLibraryBaseContext>();
            var countryServiceMock = new Mock<ICountryService>();
            var genreServiceMock = new Mock<IGenreService>();
            var userServiceMock = new Mock<IUserService>();
            var bandFactoryMock = new Mock<IBandFactory>();

            countryServiceMock.Setup(x => x.GetById(It.Is<Guid>(g => g == countryData.Id))).Returns(countryData);
            genreServiceMock.Setup(x => x.GetGenre(It.Is<Guid>(g => g == genreData.Id))).Returns(genreData);
            bandFactoryMock.Setup(x => x.CreateBandInstance()).Returns(band);

            var bandDbList = new List<Band>();
            var bandDbSetMock = new Mock<IDbSet<Band>>();
            bandDbSetMock.Setup(set => set.Add(It.IsAny<Band>())).Callback((Band b) => bandDbList.Add(b));
            contextMock.Setup(x => x.Bands).Returns(bandDbSetMock.Object);

            string bandName = "SomeBandName";
            int formationYear = 2016;
            Guid countryId = countryData.Id;
            Guid genreId = Guid.NewGuid();

            var bandService = new BandService(
                contextMock.Object,
                contextBaseMock.Object,
                countryServiceMock.Object,
                genreServiceMock.Object,
                userServiceMock.Object,
                bandFactoryMock.Object);

            Assert.That(() => bandService.RegisterNewBand(bandName, formationYear, genreId, countryId), Throws.Exception.TypeOf<ArgumentNullException>());
            Assert.That(() => bandService.RegisterNewBand(bandName, formationYear, genreId, countryId), Throws.Exception.Message.Contains("Parameter name: genre"));
        }

    }
}
