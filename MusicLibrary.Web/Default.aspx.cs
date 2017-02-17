using System.Web.UI;

namespace Project.Web
{
    public partial class _Default : Page
    {

    }

    //[PresenterBinding(typeof(BandListPresenter))]
    //public partial class _Default : MvpPage<BandListModel>, IBandListView
    //{
    //    public event EventHandler<BandListEventArgs> LoadBands;
    //    public event EventHandler LoadAllBands;

    //    protected void Page_PreRender(object sender, EventArgs e)
    //    {
    //        this.RepeaterAlphabet.DataSource = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    //        this.RepeaterAlphabet.DataBind();
    //    }

    //    protected void RepeaterAlphabet_ItemCommand(object source, RepeaterCommandEventArgs e)
    //    {
    //        var letter = e.CommandName;

    //        if (LoadBands != null)
    //        {
    //            this.LoadBands(this, new BandListEventArgs { Letter = letter });
    //        }


    //        this.BandGridView.DataSource = this.Model.Bands;
    //        this.BandGridView.DataBind();
    //    }

    //    public IEnumerable<Band> ListViewCategories_GetData()
    //    {
    //        this.LoadAllBands?.Invoke(this, null);

    //        return this.Model.Bands;
    //    }
}
