namespace MusicLibrary.Tests.MVP.SearchDisplayPresenterTests
{
    using Moq;
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
    public class Constructor_Should
    {
        [Test]
        public void Constructor_ShouldThowsArgumentNullExceptionWhenBandServiceIsNull()
        {
            //Arange
            IBandService bandService = null;
            var viewMock = new Mock<ISearchDisplayView>();

            //Act & Assert
            Assert.That(() => new SearchDisplayPresenter(viewMock.Object, bandService), Throws.Exception.TypeOf<ArgumentNullException>());
        }


        [Test]
        public void Constructor_ShouldNotThrowWhenServicesAreValid()
        {
            //Arange
            var bandServiceMock = new Mock<IBandService>();
            var viewMock = new Mock<ISearchDisplayView>();

            //Act & Assert
            Assert.That(() => new SearchDisplayPresenter(viewMock.Object, bandServiceMock.Object), Throws.Nothing);
        }

        [Test]
        public void Constructor_ShouldCreatePresenterWhenServicesAreValid()
        {
            //Arange
            var bandServiceMock = new Mock<IBandService>();
            var viewMock = new Mock<ISearchDisplayView>();

            //Act
            var presenter = new SearchDisplayPresenter(viewMock.Object, bandServiceMock.Object);

            // Assert
            Assert.That(presenter, Is.InstanceOf<Presenter<ISearchDisplayView>>());
        }
    }
}
