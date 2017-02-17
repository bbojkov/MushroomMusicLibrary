using MusicLibrary.MVP.EventArguments;
using MusicLibrary.MVP.Models;
using MusicLibrary.MVP.Presenters;
using MusicLibrary.MVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace MusicLibrary.Web.browse
{
    [PresenterBinding(typeof(BandsByGenreDisplayPresenter))]
    public partial class genres : MvpPage<BandsByGenreDisplayModel>, IBandsByGenreDisplayView
    {
        public event EventHandler LoadGenres;
        public event EventHandler<BandByGenreEventArgs> LoadBandsByGenre;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (LoadGenres != null)
                {
                    this.LoadGenres(null, null);
                }

                this.ListGenre.DataSource = this.Model.Genres;
                this.ListGenre.DataBind();
            }
           
        }

        protected void ListGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            var genre = this.ListGenre.SelectedValue;

            this.LoadBandsByGenre(sender, new BandByGenreEventArgs { Genre = genre });

            this.BandGridView.DataSource = this.Model.BandsByGenre;
            this.BandGridView.DataBind();
        }
    }
}