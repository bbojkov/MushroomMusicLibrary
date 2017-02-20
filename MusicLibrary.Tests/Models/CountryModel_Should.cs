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
    public class CountryModel_Should
    {
        [Test]
        public void HaveParametlessConstructor()
        {
            var country = new Country();
            Assert.IsInstanceOf<Country>(country);
        }

        [Test]
        public void SetIdCorrectly()
        {
            Guid countryId = Guid.NewGuid();
            var country = new Country() { Id = countryId };

            Assert.AreEqual(country.Id, countryId);
        }

        [TestCase("USA")]
        [TestCase("Bulgaria")]
        public void SetCountryNameCorrectly(string countryName)
        {
            var country = new Country() { CountryName = countryName };

            Assert.AreEqual(country.CountryName, countryName);
        }

        [Test]
        public void InitializeCollectionOfBandsCorrectly()
        {
            var country = new Country();
            var bands = country.Bands;

            Assert.That(bands, Is.Not.Null.And.InstanceOf<HashSet<Band>>());
        }

        [Test]
        public void GetAndSetDataCorrectly()
        {
            Guid bandId = Guid.NewGuid();
            var band = new Band() { Id = bandId };

            var set = new HashSet<Band> { band };

            var country = new Country() { Bands = set };

            Assert.AreEqual(country.Bands.First().Id, bandId);
        }
    }
}
