using MusicLibrary.MVP.EventArguments;
using MusicLibrary.MVP.Views;
using MusicLibrary.Services;
using System;
using WebFormsMvp;

namespace MusicLibrary.MVP.Presenters
{
    public class SearchDisplayPresenter : Presenter<ISearchDisplayView>
    {
        private readonly IBandService bandService;

        public SearchDisplayPresenter(ISearchDisplayView view, IBandService bandService)
            : base(view)
        {
            if (bandService == null)
            {
                throw new ArgumentNullException(nameof(bandService));
            }
            this.bandService = bandService;

            this.View.OnSearchDisplayBands += View_OnSearchDisplayBands;
        }

        private void View_OnSearchDisplayBands(object sender, SearchDisplayEventArgs e)
        {
            this.View.Model.Bands = this.bandService.SearchBandsByBandName(e.QueryParams);
        }
    }
}
