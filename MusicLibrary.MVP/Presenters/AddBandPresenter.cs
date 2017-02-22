namespace MusicLibrary.MVP.Presenters
{
    using Models;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Views;
    using WebFormsMvp;

    public class AddBandPresenter : Presenter<IAddBandView>
    {
        readonly IGenreService genreService;
        readonly ICountryService countryService;
        readonly IBandService bandService;

        public AddBandPresenter(IAddBandView view, IGenreService genreService, ICountryService countryService, IBandService bandService)
            : base(view)
        {
            if (bandService == null)
                throw new ArgumentNullException(nameof(bandService));

            if (countryService == null)
                throw new ArgumentNullException(nameof(countryService));

            if (genreService == null)
                throw new ArgumentNullException(nameof(genreService));

            this.genreService = genreService;
            this.countryService = countryService;
            this.bandService = bandService;

            this.View.NeedGenres += View_NeedGenres;
            this.View.NeedCountries += View_NeedCountries;
            this.View.RegisterBand += View_RegisterBand;
        }

        private void View_RegisterBand(object sender, EventArguments.AddBandEventArgs e)
        {
            string bandName = e.BandNameString;

            int formationYear;
            if (!int.TryParse(e.YearString, out formationYear))
            {
                throw new ArgumentException(nameof(formationYear));
            }

            Guid countryId;
            if (!Guid.TryParse(e.CountryIdString, out countryId))
            {
                throw new ArgumentException(nameof(countryId));
            }


            Guid genreId;
            if (!Guid.TryParse(e.GenreIdString, out genreId))
            {
                // Register genre
                genreId = this.genreService.CreateGenre(e.GenreNameString).Id;

            }

            bool isSuccessful = this.bandService.RegisterNewBand(bandName, formationYear, genreId, countryId);

            this.View.Model.IsSuccessful = isSuccessful;
        }

        private void View_NeedCountries(object sender, EventArgs e)
        {
            this.View.Model.Countries = this.countryService.GetCountries();
        }

        private void View_NeedGenres(object sender, EventArgs e)
        {
            this.View.Model.Genres = this.genreService.GetAllGenres();
        }
    }
}
