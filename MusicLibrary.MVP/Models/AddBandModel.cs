namespace MusicLibrary.MVP.Models
{
    using MusicLibrary.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AddBandModel
    {
        public IEnumerable<Genre> Genres { get; set; }
    }
}
