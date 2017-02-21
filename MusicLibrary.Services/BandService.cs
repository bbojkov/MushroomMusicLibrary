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

        public bool RegisterNewBand(string bandName, int year, string genreNameOrIdAsString, string countryIdAsString)
        {
            bool isSuucessful = false;
            if (string.IsNullOrEmpty(bandName))
            {
                return isSuucessful;
                throw new ArgumentNullException(nameof(bandName));
            }

            if (string.IsNullOrEmpty(genreNameOrIdAsString))
            {
                return isSuucessful;
                throw new ArgumentNullException(nameof(genreNameOrIdAsString));
            }

            if (string.IsNullOrEmpty(countryIdAsString))
            {
                return isSuucessful;
                throw new ArgumentNullException(nameof(countryIdAsString));
            }

            var newBand = this.bandFactory.CreateBandInstance();
            newBand.Id = Guid.NewGuid();
            newBand.BandName = bandName;

            var country = this.countryService.GetCountry(Guid.Parse(countryIdAsString));
            if (country == null)
            {
                return isSuucessful;
                throw new ArgumentNullException(nameof(country));
            }
            newBand.Country = country;

            Genre genre;
            Guid genreId;
            if (Guid.TryParse(genreNameOrIdAsString, out genreId))
            {
                genre = this.genreService.GetGenre(genreId);
            }
            else
            {
                genre = this.genreService.CreateGenre(genreNameOrIdAsString);
            }
            newBand.Genre = genre;

            this.libraryContext.Bands.Add(newBand);
            this.baseContext.SaveChanges();

            return isSuucessful = true;
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
