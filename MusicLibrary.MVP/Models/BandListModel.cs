using MusicLibrary.Models;
using System.Collections.Generic;

namespace MusicLibrary.MVP.Models
{
    public class BandListModel
    {
        public IEnumerable<Band> Bands { get; set; }
    }
}
