namespace MusicLibrary.Models.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IBand
    {
        Guid Id { get; set; }

        string BandName { get; set; }

        Guid CountryId { get; set; }

        Country Country { get; set; }

        Guid GenreId { get; set; }

        Genre Genre { get; set; }
        ICollection<User> UserLikes { get; set; }
    }
}
