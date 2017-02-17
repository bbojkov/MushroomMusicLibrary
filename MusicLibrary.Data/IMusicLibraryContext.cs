using MusicLibrary.Models;
using System.Data.Entity;

namespace MusicLibrary.Data
{
    public interface IMusicLibraryContext : IMusicLibraryBaseContext
    {
        IDbSet<Band> Bands { get; }

        IDbSet<Country> Countries { get; }

        IDbSet<Genre> Genres { get; }
    }
}
