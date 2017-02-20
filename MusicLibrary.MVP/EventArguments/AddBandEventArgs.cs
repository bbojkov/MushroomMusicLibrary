namespace MusicLibrary.MVP.EventArguments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AddBandEventArgs : EventArgs
    {
        public string BandName { get; set; }
        public int Year { get; set; }
        public string Country { get; set; }
        public string Genre { get; set; }
    }
}
