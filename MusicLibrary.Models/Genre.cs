using MusicLibrary.Models.Contracts;
using System;
using System.Collections.Generic;

namespace MusicLibrary.Models
{
    public class Genre : IGenre
    {
        public Genre()
        {
            this.Bands = new HashSet<Band>();       
        }

        public Guid Id { get; set; }

        public string GenreName { get; set; }

        public virtual ICollection<Band> Bands { get; set; }

    }
}
