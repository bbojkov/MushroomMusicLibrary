namespace MusicLibrary.Tests.MVP.AddBandPresenterTests
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
    using WebFormsMvp;

    [TestFixture]
    public class View_RegisterBand_Should
    {
        [Test]
        public void RegisterBand_ShouldCallRegisterBandWhenParametersAreValidAndGenreIdIsPrasable()
        {
            string bandName = "SomeBandName";
            string yearAsString = "2016";
            string countryIdAsString = Guid.NewGuid().ToString();
            string genreIdAsString = Guid.NewGuid().ToString();
            string genreName = "Metal";


            //Arange
            var genreServiceMock = new Mock<IGenreService>();
            var countryServiceMock = new Mock<ICountryService>();
            var bandServiceMock = new Mock<IBandService>();
            var viewMock = new Mock<IAddBandView>();
            viewMock.Setup(x => x.Model).Returns(new AddBandModel());

            AddBandEventArgs eventArgs = new AddBandEventArgs()
            {
                BandNameString = bandName,
                YearString = yearAsString,
                CountryIdString = countryIdAsString,
                GenreIdString = genreIdAsString,
                GenreNameString = genreName
            };


            //Act
            var presenter = new AddBandPresenter(viewMock.Object, genreServiceMock.Object, countryServiceMock.Object, bandServiceMock.Object);

            // Assert
            viewMock.Raise(v => v.RegisterBand += null, eventArgs);

            bandServiceMock.Verify(s => s.RegisterNewBand(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<Guid>(), It.IsAny<Guid>()), Times.Once());

        }

        [Test]
        public void RegisterBand_ShouldNotCallCreateGenreBandWhenParametersAreValidAndGenreIdIsPrasable()
        {
            string bandName = "SomeBandName";
            string yearAsString = "2016";
            string countryIdAsString = Guid.NewGuid().ToString();
            string genreIdAsString = Guid.NewGuid().ToString();
            string genreName = "Metal";


            //Arange
            var genreServiceMock = new Mock<IGenreService>();
            var countryServiceMock = new Mock<ICountryService>();
            var bandServiceMock = new Mock<IBandService>();
            var viewMock = new Mock<IAddBandView>();
            viewMock.Setup(x => x.Model).Returns(new AddBandModel());

            AddBandEventArgs eventArgs = new AddBandEventArgs()
            {
                BandNameString = bandName,
                YearString = yearAsString,
                CountryIdString = countryIdAsString,
                GenreIdString = genreIdAsString,
                GenreNameString = genreName
            };

            //Act
            var presenter = new AddBandPresenter(viewMock.Object, genreServiceMock.Object, countryServiceMock.Object, bandServiceMock.Object);

            // Assert
            viewMock.Raise(v => v.RegisterBand += null, eventArgs);

            genreServiceMock.Verify(s => s.CreateGenre(It.IsAny<string>()), Times.Never());

        }

        [Test]
        public void RegisterBand_ShouldCallRegisterBandWhenParametersAreValidAndGenreIdIsNotPrasableAndGenreNameIsProvided()
        {
            string bandName = "SomeBandName";
            string yearAsString = "2016";
            string countryIdAsString = Guid.NewGuid().ToString();
            string genreIdAsString = "24234-2134234-234";
            string genreName = "Ambient";
            var genre = new Genre() { Id = Guid.NewGuid(), GenreName = "Ambient" };

            //Arange
            var genreServiceMock = new Mock<IGenreService>();
            var countryServiceMock = new Mock<ICountryService>();
            var bandServiceMock = new Mock<IBandService>();
            var viewMock = new Mock<IAddBandView>();
            viewMock.Setup(x => x.Model).Returns(new AddBandModel());
            genreServiceMock.Setup(s => s.CreateGenre(It.Is<string>(name => name == genre.GenreName))).Returns(genre);

            AddBandEventArgs eventArgs = new AddBandEventArgs()
            {
                BandNameString = bandName,
                YearString = yearAsString,
                CountryIdString = countryIdAsString,
                GenreIdString = genreIdAsString,
                GenreNameString = genreName
            };

            //Act
            var presenter = new AddBandPresenter(viewMock.Object, genreServiceMock.Object, countryServiceMock.Object, bandServiceMock.Object);

            // Assert
            viewMock.Raise(v => v.RegisterBand += null, eventArgs);

            bandServiceMock.Verify(s => s.RegisterNewBand(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<Guid>(), It.IsAny<Guid>()), Times.Once());

        }

        [Test]
        public void RegisterBand_ShouldCallCreteGenreBandWhenParametersAreValidAndGenreIdIsNotPrasableAndGenreNameIsProvided()
        {
            string bandName = "SomeBandName";
            string yearAsString = "2016";
            string countryIdAsString = Guid.NewGuid().ToString();
            string genreIdAsString = "24234-2134234-234";
            string genreName = "Ambient";
            var genre = new Genre() { Id = Guid.NewGuid(), GenreName = "Ambient" };


            //Arange
            var genreServiceMock = new Mock<IGenreService>();
            var countryServiceMock = new Mock<ICountryService>();
            var bandServiceMock = new Mock<IBandService>();
            var viewMock = new Mock<IAddBandView>();
            viewMock.Setup(x => x.Model).Returns(new AddBandModel());

            genreServiceMock.Setup(s => s.CreateGenre(It.Is<string>(name => name == genre.GenreName))).Returns(genre);

            AddBandEventArgs eventArgs = new AddBandEventArgs()
            {
                BandNameString = bandName,
                YearString = yearAsString,
                CountryIdString = countryIdAsString,
                GenreIdString = genreIdAsString,
                GenreNameString = genreName
            };

            //Act
            var presenter = new AddBandPresenter(viewMock.Object, genreServiceMock.Object, countryServiceMock.Object, bandServiceMock.Object);

            // Assert
            viewMock.Raise(v => v.RegisterBand += null, eventArgs);

            genreServiceMock.Verify(s => s.CreateGenre(It.IsAny<string>()), Times.Once());

        }

        [Test]
        public void RegisterBand_ShouldThrowArgumentExceptionWhenYearParameterIsInvalid()
        {
            string bandName = "SomeBandName";
            string yearAsString = "2016/03/21";
            string countryIdAsString = Guid.NewGuid().ToString();
            string genreIdAsString = Guid.NewGuid().ToString();
            string genreName = "Metal";


            //Arange
            var genreServiceMock = new Mock<IGenreService>();
            var countryServiceMock = new Mock<ICountryService>();
            var bandServiceMock = new Mock<IBandService>();
            var viewMock = new Mock<IAddBandView>();
            viewMock.Setup(x => x.Model).Returns(new AddBandModel());

            AddBandEventArgs eventArgs = new AddBandEventArgs()
            {
                BandNameString = bandName,
                YearString = yearAsString,
                CountryIdString = countryIdAsString,
                GenreIdString = genreIdAsString,
                GenreNameString = genreName
            };


            //Act
            var presenter = new AddBandPresenter(viewMock.Object, genreServiceMock.Object, countryServiceMock.Object, bandServiceMock.Object);

            // Assert
            Assert.That(() => viewMock.Raise(v => v.RegisterBand += null, eventArgs),
                Throws.Exception.TypeOf<ArgumentException>().And.Message.Contain("formationYear"));

        }

        [Test]
        public void RegisterBand_ShouldThrowArgumentExceptionWhenCategoryIdParameterIsInvalid()
        {
            string bandName = "SomeBandName";
            string yearAsString = "2016";
            string countryIdAsString = "2342-sdfsr3-r4erfdsd3r-sfsd";
            string genreIdAsString = Guid.NewGuid().ToString();
            string genreName = "Metal";


            //Arange
            var genreServiceMock = new Mock<IGenreService>();
            var countryServiceMock = new Mock<ICountryService>();
            var bandServiceMock = new Mock<IBandService>();
            var viewMock = new Mock<IAddBandView>();
            viewMock.Setup(x => x.Model).Returns(new AddBandModel());

            AddBandEventArgs eventArgs = new AddBandEventArgs()
            {
                BandNameString = bandName,
                YearString = yearAsString,
                CountryIdString = countryIdAsString,
                GenreIdString = genreIdAsString,
                GenreNameString = genreName
            };


            //Act
            var presenter = new AddBandPresenter(viewMock.Object, genreServiceMock.Object, countryServiceMock.Object, bandServiceMock.Object);

            // Assert
            Assert.That(() => viewMock.Raise(v => v.RegisterBand += null, eventArgs),
                Throws.Exception.TypeOf<ArgumentException>().And.Message.Contain("countryId"));

        }

        [Test]
        public void RegisterBand_ShouldReturnTrueIfBandIsRegisterSuccessfully()
        {
            string bandName = "SomeBandName";
            string yearAsString = "2016";
            string countryIdAsString = Guid.NewGuid().ToString();
            string genreIdAsString = Guid.NewGuid().ToString();
            string genreName = "Ambient";
            var genre = new Genre() { Id = Guid.NewGuid(), GenreName = "Ambient" };

            //Arange
            var genreServiceMock = new Mock<IGenreService>();
            var countryServiceMock = new Mock<ICountryService>();
            var bandServiceMock = new Mock<IBandService>();
            var viewMock = new Mock<IAddBandView>();
            viewMock.Setup(x => x.Model).Returns(new AddBandModel());

            genreServiceMock.Setup(s => s.CreateGenre(It.Is<string>(name => name == genre.GenreName))).Returns(genre);
            bandServiceMock.Setup(s => s.RegisterNewBand(
                It.Is<string>(x => x == bandName),
                It.Is<int>(x => x == int.Parse(yearAsString)),
                It.Is<Guid>(x => x == Guid.Parse(genreIdAsString)), 
                It.Is<Guid>(x => x == Guid.Parse(countryIdAsString)))).Returns(true);

            AddBandEventArgs eventArgs = new AddBandEventArgs()
            {
                BandNameString = bandName,
                YearString = yearAsString,
                CountryIdString = countryIdAsString,
                GenreIdString = genreIdAsString,
                GenreNameString = genreName
            };

            //Act
            var presenter = new AddBandPresenter(viewMock.Object, genreServiceMock.Object, countryServiceMock.Object, bandServiceMock.Object);

            // Assert
            viewMock.Raise(v => v.RegisterBand += null, eventArgs);

            Assert.That(presenter.View.Model.IsSuccessful, Is.True);
        }

    }
}
