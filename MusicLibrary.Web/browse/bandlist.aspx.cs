using MusicLibrary.MVP.Models;
using MusicLibrary.MVP.Views;
using System;
using System.Linq;
using System.Web.ModelBinding;
using WebFormsMvp.Web;
using MusicLibrary.MVP.EventArguments;
using System.Collections;
using WebFormsMvp;
using MusicLibrary.MVP.Presenters;

namespace MusicLibrary.Web.browse
{
    [PresenterBinding(typeof(BandListPresenter))]
    public partial class bandlist : MvpPage<BandListModel>, IBandListView
    {
        public event EventHandler<BandListEventArgs> LoadBands;
        public event EventHandler LoadAllBands;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable BandGridView_GetData([QueryString] string letter)
        {
            if (LoadBands != null)
            {
                this.LoadBands(this, new BandListEventArgs { Letter = letter });
            }


            return this.Model.Bands;
        }
    }
}