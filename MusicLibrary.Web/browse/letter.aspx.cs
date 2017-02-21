using MusicLibrary.MVP.Models;
using MusicLibrary.MVP.Presenters;
using MusicLibrary.MVP.Views;
using System;
using WebFormsMvp;
using WebFormsMvp.Web;
using MusicLibrary.MVP.EventArguments;
using System.Web.UI.WebControls;

namespace MusicLibrary.Web.browse
{
    [PresenterBinding(typeof(BandListPresenter))]
    public partial class letter : MvpPage<BandListModel>, IBandListView
    {
        public event EventHandler LoadAllBands;
        public event EventHandler<BandListEventArgs> LoadBands;

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.RepeaterAlphabet.DataSource = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            this.RepeaterAlphabet.DataBind();
        }

        protected void LinkLetterButton_Command(object sender, CommandEventArgs e)
        {
            var letter = e.CommandName;

            Response.Redirect("~/browse/bandlist?letter=" + letter);
        }
    }
}