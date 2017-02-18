using System;

namespace MusicLibrary.MVP.EventArguments
{
    public class BandByGenreEventArgs: EventArgs
    {
        public string Genre { get; set; }
    }
}
