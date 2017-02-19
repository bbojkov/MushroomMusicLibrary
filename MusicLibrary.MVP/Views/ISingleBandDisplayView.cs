using MusicLibrary.MVP.EventArguments;
using MusicLibrary.MVP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace MusicLibrary.MVP.Views
{
    public interface ISingleBandDisplayView : IView<SingleBandDisplayModel>
    {
        event EventHandler<SingleBandEventArgs> OnFormGetBand;

        event EventHandler<SingleBandEventArgs> AddToFavorites;
    }
}
