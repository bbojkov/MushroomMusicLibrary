using MusicLibrary.MVP.EventArguments;
using MusicLibrary.MVP.Views;
using MusicLibrary.Services;
using System;
using WebFormsMvp;

namespace MusicLibrary.MVP.Presenters
{
    public class BandsByGenreDisplayPresenter : Presenter<IBandsByGenreDisplayView>
    {
        private readonly IGenreService genreService;
        private readonly IBandService bandService;


        public BandsByGenreDisplayPresenter(IBandsByGenreDisplayView view, IGenreService genreService, IBandService bandService) 
            : base(view)
        {
            this.genreService = genreService;
            this.bandService = bandService;

            this.View.LoadGenres += View_LoadGenres;
            this.View.LoadBandsByGenre += View_LoadBandsByGenre;

        }

        private void View_LoadBandsByGenre(object sender, BandByGenreEventArgs e)
        {
            var genre = e.Genre;
            var bandsByGenre = this.bandService.GetBandsByGenre(genre);

            this.View.Model.BandsByGenre = bandsByGenre;
        }

        private void View_LoadGenres(object sender, EventArgs e)
        {
            this.View.Model.Genres = this.genreService.GetAllGenres();
        }
    }
}
