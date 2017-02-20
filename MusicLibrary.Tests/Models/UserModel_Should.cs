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
    public class UserModel_Should
    {
        [Test]
        public void HaveParametlessConstructor()
        {
            var user = new User();
            Assert.IsInstanceOf<User>(user);
        }

        [Test]
        public void InitializeLikedBandsCollectionCorrectly()
        {
            var user = new User();

            var likedBands = user.LikedBands;

            Assert.That(likedBands, Is.Not.Null.And.InstanceOf<HashSet<Band>>());
        }

        [Test]
        public void SetIdCorrectly()
        {
            Guid userId = Guid.NewGuid();
            var user = new User() { Id = userId.ToString() };

            Assert.AreEqual(user.Id, userId.ToString());
        }

        [TestCase("username123")]
        [TestCase("peshoepich")]
        public void SetUserNameCorrectly(string username)
        {
            var user = new User() { UserName = username };

            Assert.AreEqual(user.UserName, username);
        }

        [TestCase("Pesho", "Goshov")]
        [TestCase("Gosho", "Peshev")]
        public void SetFirstNameCorrectly(string firstName, string lastName)
        {
            var user = new User() { FirstName = firstName, LastName = lastName };

            Assert.AreEqual(user.FirstName, firstName);
            Assert.AreEqual(user.LastName, lastName);
        }

        [Test]
        public void GetAndSetDataCorrectly()
        {
            Guid bandId = Guid.NewGuid();
            var band = new Band() { Id = bandId };
            var set = new HashSet<Band> { band };

            var user = new User() { LikedBands = set };

            Assert.AreEqual(user.LikedBands.First().Id, bandId);
        }

    }
}
