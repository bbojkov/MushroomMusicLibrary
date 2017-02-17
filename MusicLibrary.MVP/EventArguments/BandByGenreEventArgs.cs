using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.MVP.EventArguments
{
    public class BandByGenreEventArgs: EventArgs
    {
        public string Genre { get; set; }
    }
}
