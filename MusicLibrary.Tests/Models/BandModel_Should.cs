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
    public class BandModel_Should
    {
        [Test]
        public void HaveParametlessConstructor()
        {
            var band = new Band();
            Assert.IsInstanceOf<Band>(band);
        }

        [Test]
        public void SetIdCorrectly()
        {
            Guid bandId = Guid.NewGuid();
            var band = new Band() { Id = bandId };

            Assert.AreEqual(band.Id, bandId);
        }

        [TestCase("AHAT")]
        [TestCase("Analgin")]
        public void SetBandNameCorrectly(string bandName)
        {
            var band = new Band() { BandName = bandName };

            Assert.AreEqual(band.BandName, bandName);
        }

        [Test]
        public void InitializeCollectionOfUserLikesCorrectly()
        {
            var band = new Band();

            var userLikes = band.UserLikes;

            Assert.That(userLikes, Is.Not.Null.And.InstanceOf<HashSet<User>>());
        }

        [Test]
        public void GetAndSetDataCorrectly()
        {
            Guid userId = Guid.NewGuid();
            var user = new User() { Id = userId.ToString() };

            var set = new HashSet<User> { user };

            var band = new Band() { UserLikes = set };

            Assert.AreEqual(band.UserLikes.First().Id, userId.ToString());
        }
    }
}
