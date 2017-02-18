using MusicLibrary.Models;
using System.Collections.Generic;

namespace MusicLibrary.MVP.Models
{
    public class BandsByGenreDisplayModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public IEnumerable<Band> BandsByGenre { get; set; }

    }
}
