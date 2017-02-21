using MusicLibrary.MVP.EventArguments;
using MusicLibrary.MVP.Views;
using MusicLibrary.Services;
using System;
using WebFormsMvp;

namespace MusicLibrary.MVP.Presenters
{
    public class SingleBandDisplayPresenter : Presenter<ISingleBandDisplayView>
    {
        private readonly IUserService userService;

        private readonly IBandService bandService;

        public SingleBandDisplayPresenter(ISingleBandDisplayView view, IUserService userService, IBandService bandService)
            : base(view)
        {
            if (userService == null)
            {
                throw new ArgumentNullException(nameof(userService));
            }

            if (bandService == null)
            {
                throw new ArgumentNullException(nameof(bandService));
            }

            this.userService = userService;
            this.bandService = bandService;

            this.View.OnFormGetBand += this.View_OnFormGetBand;
            this.View.AddToFavorites += this.View_AddToFavorites;
        }

        private void View_AddToFavorites(object sender, SingleBandEventArgs e)
        {
            var band = this.bandService.GetById(e.BandId);
            this.userService.AddBandToFavorites(e.UserId, band);
        }

        private void View_OnFormGetBand(object sender, SingleBandEventArgs e)
        {
            var bandId = e.BandId;

            if (bandId != Guid.Empty)
            {
                this.View.Model.Band = this.bandService.GetById(bandId);
            }
            else
            {
                this.View.Model.Band = null;
            }
        }
    }
}
