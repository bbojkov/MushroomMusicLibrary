namespace MusicLibrary.Models.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IGenre
    {
        Guid Id { get; set; }

        string GenreName { get; set; }

        ICollection<Band> Bands { get; set; }
    }
}
