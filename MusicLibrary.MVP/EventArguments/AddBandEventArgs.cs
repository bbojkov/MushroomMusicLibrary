namespace MusicLibrary.MVP.EventArguments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AddBandEventArgs : EventArgs
    {
        public string BandNameString { get; set; }
        public string YearString { get; set; }
        public string CountryIdString { get; set; }
        public string GenreIdString { get; set; }
        public string GenreNameString { get; set; }

    }
}
