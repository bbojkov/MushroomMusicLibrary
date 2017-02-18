using MusicLibrary.MVP.EventArguments;
using MusicLibrary.MVP.Models;
using System;
using WebFormsMvp;

namespace MusicLibrary.MVP.Views
{
    public interface IBandsByGenreDisplayView: IView<BandsByGenreDisplayModel>
    {
        event EventHandler LoadGenres;

        event EventHandler<BandByGenreEventArgs> LoadBandsByGenre;

    }
}
