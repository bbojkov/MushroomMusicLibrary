using MusicLibrary.MVP.Models;
using MusicLibrary.MVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp.Web;
using MusicLibrary.MVP.EventArguments;
using WebFormsMvp;
using MusicLibrary.MVP.Presenters;
using MusicLibrary.Models;
using System.Web.ModelBinding;

namespace MusicLibrary.Web
{
    [PresenterBinding(typeof(SearchDisplayPresenter))]
    public partial class search : MvpPage<SearchDisplayModel>, ISearchDisplayView
    {
        public event EventHandler<SearchDisplayEventArgs> OnSearchDisplayBands;

        public IEnumerable<Band> Repeater_GetData(object sender, EventArgs e)
        {
            var queryString = this.ClientQueryString.Substring(3);
            this.OnSearchDisplayBands?.Invoke(this, new SearchDisplayEventArgs(queryString));

            return this.Model.Bands;
        }
    }
}