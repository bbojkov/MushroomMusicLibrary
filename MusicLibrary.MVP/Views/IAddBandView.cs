namespace MusicLibrary.MVP.Views
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WebFormsMvp;

    public interface IAddBandView: IView<AddBandModel>
    {
        event EventHandler NeedGenres;
        event EventHandler NeedCountries;

    }
}
