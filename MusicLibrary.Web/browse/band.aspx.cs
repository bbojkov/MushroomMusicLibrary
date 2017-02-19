using MusicLibrary.Models;
using MusicLibrary.MVP.Models;
using MusicLibrary.MVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp.Web;
using MusicLibrary.MVP.EventArguments;
using MusicLibrary.MVP.Presenters;
using WebFormsMvp;
using Microsoft.AspNet.Identity;

namespace MusicLibrary.Web.browse
{
    [PresenterBinding(typeof(SingleBandDisplayPresenter))]
    public partial class band : MvpPage<SingleBandDisplayModel>, ISingleBandDisplayView
    {
        public event EventHandler<SingleBandEventArgs> OnFormGetBand;
        public event EventHandler<SingleBandEventArgs> AddToFavorites;

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Band FormViewBandDetails_GetItem([QueryString] Guid id)
        {
            this.OnFormGetBand?.Invoke(this, new SingleBandEventArgs(null, id));
            return this.Model.Band;
        }

        public void AddToFavorites_Click(object sender, EventArgs e)
        {
            var userId = this.Page.User.Identity.GetUserId();
            var id = this.ClientQueryString.Substring(3);
            Guid bandId;
            Guid.TryParse(id, out bandId);

            this.AddToFavorites?.Invoke(this, new SingleBandEventArgs(userId, bandId));
        }
    }
}