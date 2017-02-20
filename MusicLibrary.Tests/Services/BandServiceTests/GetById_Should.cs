using NUnit.Framework;
using Moq;
using System;
using MusicLibrary.Data;
using MusicLibrary.Models;
using System.Data.Entity;
using MusicLibrary.Services;

namespace MusicLibrary.Tests.Services.BandServiceTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void ReturnBand_WhenIdIsValid()
        {
            var context = new Mock<IMusicLibraryContext>();
            var bandMock = new Mock<IDbSet<Band>>();

            context.Setup(x => x.Bands).Returns(bandMock.Object);

            Guid bandId = Guid.NewGuid();
            Band expectedBand = new Band() { Id = bandId };
            bandMock.Setup(x => x.Find(bandId)).Returns(expectedBand);

            var bandService = new BandService(context.Object);

            Band actualBand = bandService.GetById(bandId);

            Assert.AreSame(expectedBand, actualBand);
        }

        [Test]
        public void Returns_AnInstanceOf_Band()
        {
            var context = new Mock<IMusicLibraryContext>();
            var bandMock = new Mock<IDbSet<Band>>();

            context.Setup(x => x.Bands).Returns(bandMock.Object);

            Guid bandId = Guid.NewGuid();
            Band expectedBand = new Band() { Id = bandId };
            bandMock.Setup(x => x.Find(bandId)).Returns(expectedBand);

            var bandService = new BandService(context.Object);

            Band actualBand = bandService.GetById(bandId);

            Assert.IsInstanceOf<Band>(actualBand);
        }
    }
}
