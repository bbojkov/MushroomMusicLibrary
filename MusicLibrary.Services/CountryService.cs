namespace MusicLibrary.Services
{
    using Data;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CountryService : ICountryService
    {
        readonly IMusicLibraryContext musicLibraryContext;

        public CountryService(IMusicLibraryContext musicLibraryContext)
        {
            if (musicLibraryContext == null)
                throw new ArgumentNullException(nameof(musicLibraryContext));

            this.musicLibraryContext = musicLibraryContext;

        }

        public IEnumerable<Country> GetCountries()
        {
            return this.musicLibraryContext.Countries.OrderBy(x => x.CountryName).ToList();
        }

        public Country GetById(Guid countryId)
        {
            return this.musicLibraryContext.Countries.Find(countryId);
        }
    }
}
