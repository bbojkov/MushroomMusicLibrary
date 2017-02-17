using MusicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.MVP.Models
{
    public class BandsByGenreDisplayModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public IEnumerable<Band> BandsByGenre { get; set; }

    }
}
