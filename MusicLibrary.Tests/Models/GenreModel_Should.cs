using MusicLibrary.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Tests.Models
{
    [TestFixture]
    public class GenreModel_Should
    {
        [Test]
        public void HaveParametlessConstructor()
        {
            var genre = new Genre();
            Assert.IsInstanceOf<Genre>(genre);
        }

        [Test]
        public void SetIdCorrectly()
        {
            Guid genreId = Guid.NewGuid();
            var genre = new Genre() { Id = genreId };

            Assert.AreEqual(genre.Id, genreId);
        }

        [TestCase("Metal")]
        [TestCase("Metalcore")]
        public void SetGenreNameCorrectly(string genreName)
        {
            var genre = new Genre() { GenreName = genreName };

            Assert.AreEqual(genre.GenreName, genreName);
        }

        [Test]
        public void InitializeCollectionOfBandsCorrectly()
        {
            var genre = new Genre();
            var bands = genre.Bands;

            Assert.That(bands, Is.Not.Null.And.InstanceOf<HashSet<Band>>());
        }

        [Test]
        public void GetAndSetDataCorrectly()
        {
            Guid bandId = Guid.NewGuid();
            var band = new Band() { Id = bandId };

            var set = new HashSet<Band> { band };

            var genre = new Genre() { Bands = set };

            Assert.AreEqual(genre.Bands.First().Id, bandId);
        }
    }
}
