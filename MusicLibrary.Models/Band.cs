using System;

namespace MusicLibrary.Models
{
    public class Band
    {
        public Guid Id { get; set; }

        public string BandName { get; set; }

        public Guid CountryId { get; set; }

        public virtual Country Country { get; set; }

        public Guid GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}