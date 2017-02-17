using MusicLibrary.MVP.EventArguments;
using MusicLibrary.MVP.Views;
using MusicLibrary.Services;
using System;
using WebFormsMvp;

namespace MusicLibrary.MVP.Presenters
{
    public class BandListPresenter : Presenter<IBandListView>
    {
        private readonly IBandService bandService;

        public BandListPresenter(IBandListView view, IBandService bandService)
            : base(view)
        {
            if (bandService == null)
                throw new ArgumentNullException(nameof(bandService));

            this.bandService = bandService;

            this.View.LoadBands += View_LoadBands;
            this.View.LoadAllBands += View_LoadAllBands;
        }

        private void View_LoadBands(object sender, BandListEventArgs e)
        {
            this.View.Model.Bands = this.bandService.GetBands(e.Letter);
        }

        private void View_LoadAllBands(object sender, EventArgs e)
        {
            this.View.Model.Bands = this.bandService.GetAllBands();
        }
    }
}
