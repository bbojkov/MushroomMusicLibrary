using System.Collections.Generic;
using MusicLibrary.Models;
using MusicLibrary.Data;
using System.Data.Entity;
using System.Linq;
using System;
using MusicLibrary.Models.Factories;

namespace MusicLibrary.Services
{
    public class BandService : IBandService
    {
        private readonly IMusicLibraryContext libraryContext;
        private readonly IMusicLibraryBaseContext baseContext;
        private readonly ICountryService countryService;
        private readonly IGenreService genreService;
        private readonly IUserService userService;
        private readonly IBandFactory bandFactory;

        public BandService(
            IMusicLibraryContext libraryContext,
            IMusicLibraryBaseContext baseContext,
            ICountryService countryService,
            IGenreService genreService,
            IUserService userService,
            IBandFactory bandFactory)
        {
            this.bandFactory = bandFactory;
            if (bandFactory == null)
                throw new ArgumentNullException(nameof(bandFactory));
            if (userService == null)
                throw new ArgumentNullException(nameof(userService));
            if (genreService == null)
                throw new ArgumentNullException(nameof(genreService));
            if (countryService == null)
                throw new ArgumentNullException(nameof(countryService));
            if (baseContext == null)
                throw new ArgumentNullException(nameof(baseContext));
            if (libraryContext == null)
                throw new ArgumentNullException(nameof(libraryContext));

            this.libraryContext = libraryContext;
            this.baseContext = baseContext;
            this.userService = userService;
            this.genreService = genreService;
            this.countryService = countryService;
        }


        public IEnumerable<Band> GetAllBands()
        {
            return this.libraryContext.Bands.Include(c => c.Country).Include(g => g.Genre);
        }

        public IEnumerable<Band> GetBands(string letter)
        {
            return this.libraryContext.Bands.Where(x => x.BandName.Substring(0, 1) == letter).ToList();

        }

        public IEnumerable<Band> GetBandsByGenre(string genre)
        {
            return this.libraryContext.Bands.Where(x => x.Genre.GenreName == genre).ToList();
        }

        public Band GetById(Guid id)
        {
            return this.libraryContext.Bands.Find(id);
        }

        public bool RegisterNewBand(string bandName, int formationYear, Guid genreId, Guid countryId)
        {
            bool isSuccessful = false;
            if (string.IsNullOrEmpty(bandName))
            {
                //return isSuucessful;
                throw new ArgumentNullException(nameof(bandName));
            }

            var newBand = this.bandFactory.CreateBandInstance();

            newBand.Id = Guid.NewGuid();
            newBand.BandName = bandName;

            var country = this.countryService.GetById(countryId);
            if (country == null)
            {
                //return isSuccessful;
                throw new ArgumentNullException(nameof(country));
            }
            newBand.Country = country;

            var genre = this.genreService.GetGenre(genreId);
            if (genre == null)
            {
                //return isSuccessful;
                throw new ArgumentNullException(nameof(genre));
            }
            newBand.Genre = genre;

            this.libraryContext.Bands.Add(newBand);
            this.baseContext.SaveChanges();

            isSuccessful = true;
            return isSuccessful;
        }

        public IEnumerable<Band> SearchBandsByBandName(string searchTerm)
        {
            return
                string.IsNullOrEmpty(searchTerm)
                ? null
                : this.libraryContext.Bands.Where(x => x.BandName.Contains(searchTerm));
        }
    }
}
