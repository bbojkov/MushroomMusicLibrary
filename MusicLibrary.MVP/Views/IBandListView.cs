using MusicLibrary.MVP.EventArguments;
using MusicLibrary.MVP.Models;
using System;
using WebFormsMvp;

namespace MusicLibrary.MVP.Views
{
    public interface IBandListView : IView<BandListModel>
    {
        event EventHandler<BandListEventArgs> LoadBands;

        event EventHandler LoadAllBands;
    }
}
