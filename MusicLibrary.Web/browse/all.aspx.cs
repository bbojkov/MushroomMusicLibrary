using MusicLibrary.Models;
using MusicLibrary.MVP.EventArguments;
using MusicLibrary.MVP.Models;
using MusicLibrary.MVP.Presenters;
using MusicLibrary.MVP.Views;
using System;
using System.Collections.Generic;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace MusicLibrary.Web.browse
{
    [PresenterBinding(typeof(BandListPresenter))]
    public partial class all : MvpPage<BandListModel>, IBandListView
    {
        public event EventHandler LoadAllBands;
        public event EventHandler<BandListEventArgs> LoadBands;

        public IEnumerable<Band> ListViewCategories_GetData()
        {
            this.LoadAllBands?.Invoke(this, null);

            return this.Model.Bands;
        }
    }
}