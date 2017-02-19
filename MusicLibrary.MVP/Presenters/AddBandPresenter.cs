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

        public AddBandPresenter(IAddBandView view, IGenreService genreService) : base(view)
        {
            if (genreService == null)
                throw new ArgumentNullException(nameof(genreService));

            this.genreService = genreService;

            this.View.NeedGenres += View_LoadGenres;
            this.View.NeedCountries += View_NeedCountries;
        }

        private void View_NeedCountries(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void View_LoadGenres(object sender, EventArgs e)
        {
            this.View.Model.Genres = this.genreService.GetAllGenres();
        }
    }
}
