using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicLibrary.Models
{
    public class Band
    {
        public Band()
        {
            this.UserLikes = new HashSet<User>();
        }

        public Guid Id { get; set; }

        public string BandName { get; set; }

        public Guid CountryId { get; set; }

        public virtual Country Country { get; set; }

        public Guid GenreId { get; set; }

        public virtual Genre Genre { get; set; }


        public virtual ICollection<User> UserLikes { get; set; }
    }
}