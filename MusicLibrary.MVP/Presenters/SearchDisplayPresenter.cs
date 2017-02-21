using MusicLibrary.MVP.Views;
using MusicLibrary.Services;
using WebFormsMvp;

namespace MusicLibrary.MVP.Presenters
{
    public class SearchDisplayPresenter : Presenter<ISearchDisplayView>
    {
        private readonly IBandService bandService;

        public SearchDisplayPresenter(ISearchDisplayView view, IBandService bandService)
            : base(view)
        {
            this.bandService = bandService;

            this.View.OnSearchDisplayBands += View_OnSearchDisplayBands;
        }

        private void View_OnSearchDisplayBands(object sender, EventArguments.SearchDisplayEventArgs e)
        {
            this.View.Model.Bands = this.bandService.SearchBandsByBandName(e.QueryParams);
        }
    }
}
